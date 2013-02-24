using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Managers;
using FluxEngine.Display;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Flux.Display {
    public class CursorComponent : IHUDComponent  {

        float X;
        float Y;

        readonly FluxGame _game;

        public CursorComponent ( FluxGame game ) {
            this._game = game;
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            MouseState state = Mouse.GetState();
            this.X = state.X;
            this.Y = state.Y;

        }

        public override void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            _game.SpriteBatch.Begin();

            _game.SpriteBatch.Draw( ContentManager.CursorTexture, new Vector2( X, Y ), Color.White );

            _game.SpriteBatch.End();
        }

        public override void Init () {
            ZIndex = 1000;
        }
    }
}
