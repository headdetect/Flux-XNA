using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using FarseerPhysics;
using Flux.Managers;
using FluxEngine.Display;
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

        public override void Update ( GameTime gameTime ) {
            state = Mouse.GetState();
        }

        public override void Draw ( GameTime gameTime ) {

            string fps = string.Format( "X= {0} (SIM={2}) \nY= {1} (SIM={3})\nCameraSim={4}", state.X, state.Y, ConvertUnits.ToSimUnits( state.X ), ConvertUnits.ToSimUnits( state.Y ), _game.Camera.ConvertScreenLocationToWorldLocation( new Vector2( state.X, state.Y ) ) );

            _game.SpriteBatch.Begin();

            /* Shadow */
            _game.SpriteBatch.DrawString( ContentManager.FPSFont, fps, _position + Vector2.One, Color.Black );

            /* Forground */
            _game.SpriteBatch.DrawString( ContentManager.FPSFont, fps, _position, Color.White );


            _game.SpriteBatch.End();
        }


        public override void Init () {
        }
    }
}
