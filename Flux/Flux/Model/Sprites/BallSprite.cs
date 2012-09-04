using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Factories;

namespace Flux.Model.Sprites {

    public class BallSprite : Sprite {

        readonly static Vector2 DEFAULT_SIZE = new Vector2( 50, 50 );

        private readonly Vector2 spawnPos;

        public BallSprite ( FluxGame fluxGame )
            : base( fluxGame, DEFAULT_SIZE ) { }

        public BallSprite ( FluxGame fluxGame, Vector2 spawnPos )
            : base( fluxGame, DEFAULT_SIZE, spawnPos ) {
                this.spawnPos = spawnPos;
                this.Body = BodyFactory.CreateCircle( Flux.PhysicsWorld, 50 / Utils.PixelsToMeterRatio, 1f, spawnPos / Utils.PixelsToMeterRatio );
                this.Body.BodyType = FarseerPhysics.Dynamics.BodyType.Dynamic;

        }

        private float spinIterations = 0;

        internal override void Update ( GameTime gameTime ) {
            KeyboardState state = Keyboard.GetState();

            /*if ( state.IsKeyDown( Keys.Enter ) ) {
                this.Position = spawnPos;
                this.spinIterations = 0;
                this.Rotation = 0;
                return;
            }

            int speedModifier = state.IsKeyDown( Keys.LeftShift ) ? 3 : 1;

            if ( state.IsKeyDown( Keys.W ) ) {
                this.Position -= new Vector2( 0, 3 * speedModifier );
            }
            else if ( state.IsKeyDown( Keys.S ) ) {
                this.Position += new Vector2( 0, 3 * speedModifier );
            }
            else if ( state.IsKeyDown( Keys.A ) ) {
                this.Position -= new Vector2( 3 * speedModifier, 0 );
                this.Rotation -= 5 * speedModifier;
            }
            else if ( state.IsKeyDown( Keys.D ) ) {
                this.Position += new Vector2( 3 * speedModifier, 0 );
                this.Rotation += 5 * speedModifier;
            }

            if ( state.IsKeyDown( Keys.Space ) ) {
                spinIterations += .3f;
                if ( spinIterations > 80 ) {
                    spinIterations = 80;
                }
            }
            else {
                spinIterations -= .5f;
                if ( spinIterations < 0 ) {
                    spinIterations = 0;
                }

                this.Position += new Vector2( spinIterations / 2, 0 );
            }

            Rotation += spinIterations;*/

            this.Rotation = Body.Rotation;
            this.Position = Body.Position * Utils.PixelsToMeterRatio;

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
