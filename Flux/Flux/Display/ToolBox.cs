using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Model.Sprites.Shapes;
using Microsoft.Xna.Framework.Input;
using Flux.Managers;
using Microsoft.Xna.Framework;
using Flux.Utils;
using Flux.Model.Sprites.Blocks;

namespace Flux.Display {
    public class ToolBox : IHUDComponent {

        readonly Vector2 Size = new Vector2( 400, 70 );

        FluxGame game;

        public List<Tool> Tools { get; set; }

        public Slot SelectedSlot { get; set; }

        public readonly Slot[] Slots = new Slot[ 6 ];

        private readonly Vector2 screenSize;
        private readonly Vector2 toolPos;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBox"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public ToolBox ( FluxGame game ) {
            this.game = game;

            screenSize = new Vector2( game.HUD.Width, game.HUD.Height );
            toolPos = new Vector2( screenSize.X / 2, screenSize.Y - Size.Y / 2 );


        }

        public ToolBox ( FluxGame game, Slot[] slots ) {
            this.game = game;
            this.Slots = slots;
        }

        public void Init () {
            for ( int i = 0; i < 6; i++ ) {
                Slots[ i ] = new Slot( new EqualTriangleTool( game ), 4 );
                Slots[ i ].Tool.Init();

                float height = Slots[ i ].Tool.Size.Y;
                float width = Slots[ i ].Tool.Size.X;

                Slots[ i ].Tool.Position = toolPos - new Vector2( width * 4 + PAD + PAD / 2, 10 ) + new Vector2( i * ( PAD + width + PAD ), 0 );

            }
        }

        public void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            MouseState state = Mouse.GetState();
            Slot slot = GetSlot( state );


            if ( slot != null ) {

                SelectedSlot = slot;
                slot.IsHoveredOver = true;

                if ( state.LeftButton == ButtonState.Pressed ) {

                    //shouldn't be not null (wat)
                    if ( SelectedSlot.Block == null ) {
                        Block block = GetBlock( SelectedSlot.Tool.BlockForm );
                        game.SpriteManager.Add( block );
                        SelectedSlot.Block = block;
                        block.HasMoveSettingActivated = true;

                        block.Position = game.Camera.Center;
                        slot.Count--;
                    }
                }

            }

        }

        const int PAD = 11;

        public void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            game.SpriteBatch.Begin();

            game.SpriteBatch.Draw( game.TextureManager.ToolBoxTexture, toolPos, null, Color.White, 0f, Size / 2, 1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f );


            for ( int i = 0; i < 6; i++ ) {
                Slot slot = Slots[ i ];
                game.SpriteBatch.Draw( slot.IsHoveredOver ? slot.Tool.TextureHovered : slot.Tool.Texture, slot.Tool.Position, null, Color.White, 0f, Vector2.Zero, 1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f );

                if ( slot.Count > 1 )
                    game.SpriteBatch.DrawString( game.TextureManager.ToolBoxFont, slot.Count.ToString(), slot.Tool.Position - new Vector2( 0, 10 ), Color.White );


            }

            game.SpriteBatch.End();
        }

        Slot GetSlot ( MouseState state ) {
            for ( int i = 0; i < 6; i++ ) {
                Slot slot = Slots[ i ];

                slot.IsHoveredOver = false;

                if ( slot.Tool.IsInBounds( state.X, state.Y ) ) {
                    return slot;
                }
            }
            return null;
        }

        Block GetBlock ( Type type ) {
            if ( type.BaseType != typeof( Block ) ) {
                throw new ArgumentException( "Specified type is not a block" );
            }

            Block block = (Block) Activator.CreateInstance( type, game );

            if ( block == null ) {
                throw new NullReferenceException( "Type does not contain a valid block" );
            }

            return block;
        }

    }

    public class Slot {

        public Tool Tool { get; set; }

        public Block Block { get; set; }

        public int Count { get; set; }

        public bool IsHoveredOver { get; set; }


        public Slot () {
            Count = -1;
        }

        public Slot ( Tool tool ) {
            Count = 1;
            Tool = tool;
        }

        public Slot ( Tool tool, int count ) {
            Count = count;
            Tool = tool;
        }

    }
}
