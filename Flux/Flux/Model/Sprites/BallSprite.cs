using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Audio;

namespace Flux.Model.Sprites {

    public class BallSprite : PhysicsSprite {

        readonly static Vector2 DEFAULT_SIZE = new Vector2 ( 50, 50 );

        readonly Vector2 spawnPos;



        public BallSprite ( FluxGame fluxGame )
            : base ( fluxGame, DEFAULT_SIZE ) { }

        public BallSprite ( FluxGame fluxGame, Vector2 spawnPos )
            : base ( fluxGame, DEFAULT_SIZE, spawnPos ) {
            this.spawnPos = spawnPos;
            this.Body = BodyFactory.CreateCircle ( Flux.PhysicsWorld, 50 / Utils.PixelsToMeterRatio, 1f, spawnPos / Utils.PixelsToMeterRatio );
            this.Body.CreateFixture ( new CircleShape ( 50 / Utils.PixelsToMeterRatio, 2f ) );
            this.Body.FixtureList[ 0 ].Restitution = .3f;
            this.Body.BodyType = FarseerPhysics.Dynamics.BodyType.Dynamic;
            this.Body.AngularDamping = 9f;
            this.Body.Friction = 20f;

        }

        float spinIterations = 0;
        bool wasActivated = false;


        public override void Update ( GameTime gameTime ) {
            KeyboardState state = Keyboard.GetState ();

            if ( state.IsKeyDown ( Keys.Enter ) ) {
                this.Body.ResetDynamics ();
                this.Body.Position = spawnPos / 64;
                this.spinIterations = 0;
                this.Body.Rotation = 0;
                base.Update ( gameTime );
                return;
            }

            /* Boundry Checks */
            if ( this.Body.Position.X < -50 / 64f ) {
                this.Body.SetTransform ( spawnPos / 64, this.Body.Rotation );
            }

            int speedModifier = state.IsKeyDown ( Keys.LeftShift ) ? 3 : 1;

            if ( state.IsKeyDown ( Keys.Space ) ) {
                wasActivated = true;
                spinIterations += .3f;
                if ( spinIterations > 80 ) {
                    spinIterations = 80;
                }

            } else {

                //Slow down the rotations
                if ( (int)spinIterations > 0 ) {
                    spinIterations -= .4f;
                } else if ( (int) spinIterations < 0 ) {
                    spinIterations += .4f;
                } else {
                    spinIterations = 0;
                }

                if ( wasActivated ) {
                    wasActivated = false;

                    this.Body.ApplyForce ( new Vector2 ( 300 * spinIterations, 0 ), new Vector2 ( this.Body.Position.X, this.Body.Position.Y / 2 ) );

                    return;
                }
            }



            if ( state.IsKeyDown ( Keys.A ) ) {
                this.spinIterations -= 1f;
                if ( this.spinIterations < -40f ) {
                    this.spinIterations = -40f;
                }
                this.Body.ApplyForce ( new Vector2 ( -40, 0f ), new Vector2 ( this.Body.Position.X, this.Body.Position.Y / 2 ) );
            } else if ( state.IsKeyDown ( Keys.D ) ) {
                this.spinIterations += 1f;
                if ( this.spinIterations > 40f ) {
                    this.spinIterations = 40f;
                }
                this.Body.ApplyForce ( new Vector2 ( 40, 0f ), new Vector2 ( this.Body.Position.X, this.Body.Position.Y / 2 ) );
            } 



            this.Body.Rotation += spinIterations;

            base.Update ( gameTime );

        }

        public override void Init () {
            Texture = Flux.TextureManager.BallTexture;
        }

        public override void Destroy ( bool animation ) {
            if ( animation ) {
            }
        }

    }

}
