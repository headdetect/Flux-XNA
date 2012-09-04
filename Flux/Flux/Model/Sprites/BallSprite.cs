using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flux.Model.Sprites {

    public class BallSprite : Sprite {

        readonly static Vector2 DEFAULT_SIZE = new Vector2( 50, 50 );


        public BallSprite ( FluxGame fluxGame )
            : base( fluxGame, DEFAULT_SIZE ) { }

        public BallSprite ( FluxGame fluxGame, Vector2 spawnPos )
            : base( fluxGame, DEFAULT_SIZE, spawnPos ) { }

        internal override void Update ( GameTime gameTime ) {
            if ( Keyboard.GetState().IsKeyDown( Keys.W ) ) {
                this.Position -= new Vector2( 0, 3 );
            }

            Rotation *= 2;
            Rotation++;
        }

        internal override void Init () {
            Texture = Flux.TextureManager.BallTexture;
        }

        internal override void Destroy ( bool animation ) {
            if ( animation ) {
            }
        }

    }

}
