using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using FarseerPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Flux.Display {
    public class CursorLocationComponent : IHUDComponent {

        private readonly Vector2 _position;
        private readonly FluxGame _game;
        private MouseState state;

        public CursorLocationComponent ( FluxGame game ) {
            this._game = game;

#if XBOX
            this._position = new Vector2(55, 35);
#else
            this._position = new Vector2( 30, game.HUD.Height - 65 );
#endif

        }

        public void Update ( GameTime gameTime ) {
            state = Mouse.GetState ();
        }

        public void Draw ( GameTime gameTime ) {

            string fps = string.Format("X= {0} ({2})\nY= {1} ({3})", state.X, state.Y, ConvertUnits.ToSimUnits(state.X), ConvertUnits.ToSimUnits(state.Y) );

            _game.SpriteBatch.Begin();

            /* Shadow */
            _game.SpriteBatch.DrawString( _game.TextureManager.FPSFont, fps, _position + Vector2.One, Color.Black );

            /* Forground */
            _game.SpriteBatch.DrawString( _game.TextureManager.FPSFont, fps, _position, Color.White );


            _game.SpriteBatch.End();
        }


        public void Init () {
        }
    }
}
