using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FluxEngine;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Input;

namespace Flux.Entities.Sprites.Blocks {

    /// <summary>
    /// Structure for making a block.
    /// </summary>
    public abstract class Block : PhysicsSprite {
        private bool _rotActivated;
        private bool _moveActivated;


        /// <summary>
        /// Gets or sets a value indicating whether this instance has the rotation setting activated.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has the rotation setting activated; otherwise, <c>false</c>.
        /// </value>
        public bool HasRotationSettingActivated {
            get { return _rotActivated; }
            set {
                _rotActivated = value;
                IsPlaced = !value;

                if ( value ) {
                    //TODO: show rotate block option
                }
                else {
                    //TODO: hide rotate block option
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has the move setting activated.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has the move setting activated; otherwise, <c>false</c>.
        /// </value>
        public bool HasMoveSettingActivated {
            get { return _moveActivated; }
            set {
                _moveActivated = value;
                IsPlaced = !value;

                //Prefabs.MoveOverlaySprite.SetBoundsWithBody ( value ? Body : null );
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is placed on the map.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is placed on the map; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlaced { get; set; }


        /// <summary>
        /// Called when a collision is made
        /// </summary>
        /// <param name="other">The other fixture.</param>
        /// <param name="thisFixture">This sprite's fixture.</param>
        /// <param name="contact">The contact.</param>
        /// <returns>true generally.</returns>
        public virtual bool OnCollision ( Fixture other, Fixture thisFixture, Contact contact ) {
            if ( IsPlaced ) {
                thisFixture.IgnoreCollisionWith ( other );
            } 

            return true;
        }

        private bool hasHold;
        private MouseState lastState;
        public override void Update ( GameTime gameTime ) {
            MouseState state = Mouse.GetState();

            if ( state.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released ) {
                if ( IsInBounds( state.X, state.Y ) ) {
                    if ( !HasMoveSettingActivated ) {
                        HasMoveSettingActivated = true;
                    }
                    hasHold = true;

                }
            }
            else if ( state.LeftButton == ButtonState.Released ) {
                hasHold = false;
            }

            if ( hasHold ) {

                // Conversion from display to sim will be undone by setting the Position.
                // /r/explainlikeimfive/
                // Position converts to sim, we must convert to display so it unconverts. Mess it up, so Position will revert it.
                Position = ConvertUnits.ToDisplayUnits( Game.Camera.ConvertScreenLocationToWorldLocation( new Vector2( state.X, state.Y ) ) );
            }

            lastState = state;

            base.Update( gameTime );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="position">The position.</param>
        protected Block ( BaseFluxGame game, Vector2 position )
            : base( game, position ) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        protected Block ( BaseFluxGame game ) : base( game ) { }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public new Body Body {
            get { return base.Body; }
            set {
                base.Body = value;
                base.Body.OnCollision += ( a, b, z ) => {

                    Fixture other = a;

                    if ( a.Body == base.Body )
                        other = b;

                    else if ( b.Body == base.Body )
                        other = a;

                    else return false;

                    return OnCollision( other, b, z );
                };
            }
        }

    }
}
