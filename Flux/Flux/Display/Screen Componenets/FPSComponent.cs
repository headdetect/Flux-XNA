using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Flux.Managers;
using FluxEngine.Display;
using Microsoft.Xna.Framework;

namespace Flux.Display {
    public class FPSComponent : IHUDComponent {

        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private NumberFormatInfo _format;
        private int _frameCounter;
        private int _frameRate;
        private Vector2 _position;
        private FluxGame _game;

        public FPSComponent ( FluxGame game ) {
            this._game = game;
            this._format = new NumberFormatInfo() {
                NumberDecimalSeparator = "."
            };

#if XBOX
            this._position = new Vector2(55, 35);
#else
            this._position = new Vector2( 30, 25 );
#endif

        }

        public override void Update ( GameTime gameTime ) {
            _elapsedTime += gameTime.ElapsedGameTime;

            if ( _elapsedTime <= TimeSpan.FromSeconds( 1 ) ) return;

            _elapsedTime -= TimeSpan.FromSeconds( 1 );
            _frameRate = _frameCounter;
            _frameCounter = 0;
        }

        public override void Draw ( GameTime gameTime ) {
            _frameCounter++;

            string fps = string.Format( _format, "{0} FPS", _frameRate );

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
