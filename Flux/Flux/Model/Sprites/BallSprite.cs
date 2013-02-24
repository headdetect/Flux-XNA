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
using Flux.Utils;
using FarseerPhysics;

namespace Flux.Model.Sprites {

    public class BallSprite : PhysicsSprite {

        readonly static Vector2 DEFAULT_SIZE = new Vector2 ( 25f );

        readonly Vector2 spawnPos;



        public BallSprite ( FluxGame fluxGame )
            : this ( fluxGame, DEFAULT_SIZE ) { }

        public BallSprite ( FluxGame fluxGame, Vector2 spawnPos )
            : base ( fluxGame, DEFAULT_SIZE, spawnPos ) {

            this.spawnPos = spawnPos;
            this.Body = BodyFactory.CreateCircle ( Flux.PhysicsWorld, ConvertUnits.ToSimUnits ( Size.X ), 1f, ConvertUnits.ToSimUnits ( Position ) );
            this.Body.CreateFixture ( new CircleShape ( ConvertUnits.ToSimUnits ( Size.X ), 2f ) );
            this.Body.FixtureList[ 0 ].Restitution = .2f;
            this.Body.BodyType = BodyType.Dynamic;

            this.Body.AngularDamping = 25f;
            this.Body.Friction = 25f;

            this.Origin = Size;
            this.ZoomScale = Size.X / 25f;
        }

        public float spinIterations = 0;
        bool wasActivated = false;


        public override void Update ( GameTime gameTime ) {
            KeyboardState state = Keyboard.GetState ();



            if ( state.IsKeyDown ( Keys.Enter ) ) {
                this.Body.ResetDynamics ();
                this.Position = spawnPos ;
                this.spinIterations = 0;
                this.Rotation = 0;
                base.Update ( gameTime );
                return;
            }

            int speedModifier = state.IsKeyDown ( Keys.LeftShift ) ? 3 : 1;

            if ( state.IsKeyDown ( Keys.Space ) ) {
                wasActivated = true;
                spinIterations += .6f;
                if ( spinIterations > 100 ) {
                    spinIterations = 100;
                }

            } else {

                //Slow down the rotations
                if ( (int) spinIterations > 0 ) {
                    spinIterations -= 1.1f;
                } else if ( (int) spinIterations < 0 ) {
                    spinIterations += 1.1f;
                } else {
                    spinIterations = 0;
                }

                if ( wasActivated ) {
                    wasActivated = false;

                    this.Body.ApplyForce ( new Vector2 ( 150 * spinIterations, 0 ), new Vector2 ( this.Body.Position.X, this.Body.Position.Y / 2 ) );

                    return;
                }
            }



            if ( state.IsKeyDown ( Keys.A ) ) {
                this.spinIterations = -3.5f * speedModifier;
                this.Body.ApplyForce ( new Vector2 ( -20f * speedModifier, 0f ), new Vector2 ( this.Body.Position.X, this.Body.Position.Y / 2 ) );
            } else if ( state.IsKeyDown ( Keys.D ) ) {
                this.spinIterations = 3.5f * speedModifier;
                this.Body.ApplyForce ( new Vector2 ( 20f * speedModifier, 0f ), new Vector2 ( this.Body.Position.X, this.Body.Position.Y / 2 ) );
            }



            this.Rotation += spinIterations;

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
