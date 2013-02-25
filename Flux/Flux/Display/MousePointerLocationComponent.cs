using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Flux.Display {
    public class MousePointerLocationComponent : IHUDComponent {

        private readonly FluxGame _game;
        private Vector2 _position;

        private string text;

        public MousePointerLocationComponent ( FluxGame fluxGame ) {
            this._game = fluxGame;
        }


        public void Init () {
            this._position = new Vector2 (_game.TextureManager.FPSFont.MeasureString ( "ABCDE" ).X - 4,
                                          _game.HUD.Height - _game.TextureManager.FPSFont.MeasureString ( "|" ).Y - 4 );
        }

        private MouseState state;
        public void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            state = Mouse.GetState ();
            text = string.Format ( "X:{0}\nY:{1}\nCX:{2}\nCY:{3}", state.X, state.Y, (int)_game.Camera.Position.X, (int)_game.Camera.Position.Y );
        }

        public void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            Vector2 size = _game.TextureManager.FPSFont.MeasureString ( text );


            _game.SpriteBatch.Begin ();

            /* Shadow */
            _game.SpriteBatch.DrawString ( _game.TextureManager.FPSFont, text, _position - size + Vector2.One, Color.Black );

            /* Forground */
            _game.SpriteBatch.DrawString ( _game.TextureManager.FPSFont, text, _position - size, Color.White );


            _game.SpriteBatch.End ();
        }

    }
}
