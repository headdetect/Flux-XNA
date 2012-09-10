using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Model.Sprites.Shapes;
using Microsoft.Xna.Framework.Input;
using Flux.Managers;
using Microsoft.Xna.Framework;
using Flux.Utils;

namespace Flux.Display {
    public class ToolBox : IHUDComponent {

        readonly Vector2 Size = new Vector2( 400, 70 );

        FluxGame game;

        public List<Tool> Tools { get; set; }

        public Tool SelectedTool { get; set; }

        public Slot[] Slots = new Slot[ 6 ];

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolBox"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public ToolBox ( FluxGame game ) {
            this.game = game;

            for ( int i = 0; i < 6; i++ ) {
                Slots[ i ] = new Slot( new EqualTriangle( game ), 4 );

            }
        }

        public ToolBox ( FluxGame game, Slot[] slots ) {
            this.game = game;
            this.Slots = slots;
        }

        public void Init () {
            for ( int i = 0; i < 6; i++ ) {
                Slots[ i ].Tool.Init();
            }
        }

        public void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            MouseState state = Mouse.GetState();

            Tool tool = GetTool( state );

            if ( tool != null ) {

                SelectedTool = tool;

                return;
            }
            if ( state.LeftButton == ButtonState.Pressed ) {
                if ( SelectedTool != null ) {
                    game.SpriteManager.Add( SelectedTool );
                    SelectedTool = null;
                }
            }


        }

        const int PAD = 11;

        public void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            int width = game.TextureManager.TriangleTexture.Width;
            int height = game.TextureManager.TriangleTexture.Height;

            var screen = new Vector2( game.HUD.Width, game.HUD.Height );
            var pos = new Vector2( screen.X / 2, screen.Y - Size.Y / 2 );
            var startPos = new Vector2( PAD + PAD, height / 2 );


            game.SpriteBatch.Begin();

            game.SpriteBatch.Draw( game.TextureManager.ToolBoxTexture, pos, null, Color.White, 0f, Size / 2, 1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f );


            for ( int i = 0; i < 6; i++ ) {
                Slot slot = Slots[ i ];
                game.SpriteBatch.Draw( slot.IsHoveredOver ? slot.Tool.TextureHovered : slot.Tool.Texture, pos + startPos + new Vector2( i * ( PAD + width + PAD ), 0 ), null, Color.White, 0f, Size / 2, 1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f );

                if ( slot.Count > 1 )
                    game.SpriteBatch.DrawString( game.TextureManager.ToolBoxFont, slot.Count.ToString(), startPos + new Vector2( pos.X / 2 + width - PAD, pos.Y ) + new Vector2( i * ( PAD + width + PAD ), -height - 10 ), Color.White );


            }

            game.SpriteBatch.End();
        }

        Tool GetTool ( MouseState state ) {


            for ( int i = 0; i < 6; i++ ) {
                Slot slot = Slots[ i ];

                slot.IsHoveredOver = slot.Tool.IsInBounds( slot.Tool.Position + Vector2.One );


            }

            //return stuff

            return null;

        }

    }

    public class Slot {

        public Tool Tool { get; set; }

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
