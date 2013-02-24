using System;
using System.Collections.Generic;
using System.Globalization;
using Flux.Entities.Sprites.Blocks;
using Flux.Entities.Sprites.Tools;
using Flux.Managers;
using FluxEngine.Display;
using FluxEngine.Entity;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Flux.Display {
    public class ToolBox : IHUDComponent {

        readonly FluxGame game;
        readonly Vector2 Size = new Vector2( 400, 70 );
        readonly Vector2 screenSize;
        readonly Vector2 toolPos;

        /// <summary>
        /// Gets or sets the tools.
        /// </summary>
        /// <value>
        /// The tools.
        /// </value>
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// Gets or sets the selected slot.
        /// </summary>
        /// <value>
        /// The selected slot.
        /// </value>
        public Slot SelectedSlot { get; set; }

        /// <summary>
        /// All of the slots in the toolbox (6 slots)
        /// </summary>
        public readonly Slot[] Slots = new Slot[ 6 ];

        /// <summary>
        /// List of active blocks in the playing field
        /// </summary>
        public readonly List<Block> ActiveBlocks;



        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBox"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public ToolBox ( FluxGame game )
            : this( game, new Slot[ 6 ] ) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBox"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="slots">The slots.</param>
        public ToolBox ( FluxGame game, Slot[] slots ) {
            this.game = game;
            this.Slots = slots;

            this.screenSize = new Vector2( game.HUD.Width, game.HUD.Height );
            this.toolPos = new Vector2( screenSize.X / 2, screenSize.Y - Size.Y / 2 );

            this.ActiveBlocks = new List<Block>();
        }

        //Overriden
        public override void Init () {
            ZIndex = 1;

            for ( int i = 0; i < 6; i++ ) {
                Slots[ i ] = new Slot( new EqualTriangleTool( game ), 4 );
                Slots[ i ].Tool.Init();

                float height = Slots[ i ].Tool.Size.Y;
                float width = Slots[ i ].Tool.Size.X;

                Slots[ i ].Tool.Position = toolPos - new Vector2( width * 4 + PAD + PAD / 2, 10 ) + new Vector2( i * ( PAD + width + PAD ), 0 );

            }
        }


        private MouseState lastState;

        //Overriden
        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            MouseState state = Mouse.GetState();
            Slot slot = GetSlot( state );

            if ( slot != null && slot.Count > 0 ) {

                if ( lastState.LeftButton == ButtonState.Released && state.LeftButton == ButtonState.Pressed ) {
                    for ( int i = 0; i < Slots.Length; i++ ) {
                        if ( Slots[ i ] != slot )
                            Slots[ i ].IsHoveredOver = false;
                    }

                    slot.IsHoveredOver = !slot.IsHoveredOver;
                    SelectedSlot = slot.IsHoveredOver ? slot : null;
                }

            }


            if ( lastState.LeftButton == ButtonState.Released && state.LeftButton == ButtonState.Pressed ) {
                if ( slot == null && SelectedSlot != null && SelectedSlot.Count > 0 ) {
                    Block block = GetBlock( SelectedSlot.Tool.BlockForm, state.X, state.Y );
                    ActiveBlocks.Add( block );

                    for ( int i = 0; i < ActiveBlocks.Count; i++ ) {
                        if ( block != ActiveBlocks[ i ] ) {
                            ActiveBlocks[ i ].HasMoveSettingActivated = false;
                            ActiveBlocks[ i ].HasRotationSettingActivated = false;
                        }
                    }

                    block.HasMoveSettingActivated = true;

                    SelectedSlot.Count--;
                    SelectedSlot.Block = block;
                    SelectedSlot.IsHoveredOver = false;
                    SelectedSlot = null;

                    game.SpriteManager.Add( block );

                }
            }

            lastState = state;
        }

        const int PAD = 11;

        //Overriden
        public override void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            game.SpriteBatch.Begin();

            game.SpriteBatch.Draw( ContentManager.ToolBoxTexture, toolPos, null, Color.White, 0f, Size / 2, 1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f );


            for ( int i = 0; i < 6; i++ ) {
                Slot slot = Slots[ i ];

                if ( slot.Count > 0 ) {
                    game.SpriteBatch.Draw( slot.IsHoveredOver ? slot.Tool.TextureHovered : slot.Tool.Texture, slot.Tool.Position, null, Color.White, 0f, Vector2.Zero, 1f,
                                            Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f );

                    if ( slot.Count > 1 )
                        game.SpriteBatch.DrawString( ContentManager.ToolBoxFont, slot.Count.ToString( CultureInfo.InvariantCulture ),
                                                      slot.Tool.Position - new Vector2( 0, 10 ), Color.White );
                }

            }

            game.SpriteBatch.End();
        }

        internal Slot GetSlot ( MouseState state ) {
            for ( int i = 0; i < 6; i++ ) {
                Slot slot = Slots[ i ];

                if ( slot.Tool.IsInBounds( state.X, state.Y ) ) {
                    return slot;
                }
            }
            return null;
        }

        internal Block GetBlock ( Type type, float x, float y ) {
            if ( type.BaseType != typeof( Block ) ) {
                throw new ArgumentException( "Specified type is not a block" );
            }

            Block block = (Block) Activator.CreateInstance( type, game, new Vector2( x, y ) );

            if ( block == null ) {
                throw new NullReferenceException( "Type does not contain a valid block" );
            }

            return block;
        }

    }

    /// <summary>
    /// Class contaning info on slots.
    /// </summary>
    public class Slot {

        /// <summary>
        /// Gets or sets the tool.
        /// </summary>
        /// <value>
        /// The tool.
        /// </value>
        public Tool Tool { get; set; }

        /// <summary>
        /// Gets or sets the block.
        /// </summary>
        /// <value>
        /// The block.
        /// </value>
        public Block Block { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is hovered over.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is hovered over; otherwise, <c>false</c>.
        /// </value>
        public bool IsHoveredOver { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Slot"/> class.
        /// </summary>
        public Slot () {
            Count = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Slot"/> class.
        /// </summary>
        /// <param name="tool">The tool.</param>
        public Slot ( Tool tool ) {
            Count = 1;
            Tool = tool;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Slot"/> class.
        /// </summary>
        /// <param name="tool">The tool.</param>
        /// <param name="count">The count.</param>
        public Slot ( Tool tool, int count ) {
            Count = count;
            Tool = tool;
        }

    }
}
