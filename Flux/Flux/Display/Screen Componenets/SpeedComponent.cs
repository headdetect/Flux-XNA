using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Entities.Sprites;
using Flux.Managers;
using FluxEngine.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Common;

namespace Flux.Display {
    public class SpeedComponent : IHUDComponent {

        private readonly FluxGame _game;
        private readonly Vector2 _position;
        private int updateCount;

        float oldRot = 0;
        float curRot = 0;

        public SpeedComponent ( FluxGame game ) {
            this._game = game;
            this._position = new Vector2( game.HUD.Width - ContentManager.FPSFont.MeasureString( "ABCDE" ).X - 4,
                                          game.HUD.Height - ContentManager.FPSFont.MeasureString( "|" ).Y - 4 );
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            oldRot = curRot;
            curRot = ( (BallSprite) _game.Player.Sprite ).spinIterations;

        }

        private const string format = "{0}k RPM";

        public override void Draw ( Microsoft.Xna.Framework.GameTime gameTime ) {
            updateCount++;

            float speed = Math.Abs( curRot );

            string text = string.Format( format, (int) speed );

            Vector2 size = ContentManager.FPSFont.MeasureString( text );


            _game.SpriteBatch.Begin();

            /* Shadow */
            _game.SpriteBatch.DrawString( ContentManager.FPSFont, text, _position - size + Vector2.One, Color.Black );

            /* Forground */
            _game.SpriteBatch.DrawString( ContentManager.FPSFont, text, _position - size, Color.White );


            _game.SpriteBatch.End();
        }

        public override void Init () {
        }
    }
}
