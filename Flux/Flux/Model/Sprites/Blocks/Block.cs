using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics;
using Flux.Utils;

namespace Flux.Model.Sprites.Blocks {

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
                } else {
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

                if ( value ) {
                    Flux.SpriteManager.MoveOverlay.HoverBounds = VectorUtils.VectorsToRectangle ( ConvertUnits.ToDisplayUnits ( Body.Position ) - ConvertUnits.ToDisplayUnits ( Body.Position ) * 2, Size + Size * 2 );
                } else {
                    Flux.SpriteManager.MoveOverlay.HoverBounds = new Rectangle(-1, -1, -1, -1);
                }
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
        /// <param name="collidingFixture">The colliding fixture.</param>
        /// <param name="contact">The contact.</param>
        public virtual bool OnCollision ( Fixture collidingFixture, Contact contact ) {
            if ( !IsPlaced )
                return false;

            //Do some collision stuff

            return true;
        }

        public override void Update ( GameTime gameTime ) {
            MouseState state = Mouse.GetState ();

            if ( state.LeftButton == ButtonState.Pressed ) {

                if ( IsInBounds ( state.X, state.Y ) ) {
                    if ( !HasMoveSettingActivated ) {
                        HasMoveSettingActivated = true;
                    } else {
                        Body.Position = ConvertUnits.ToSimUnits ( new Vector2 ( state.X, state.Y ) );
                    }
                }
            }

            base.Update ( gameTime );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public Block ( FluxGame game, Vector2 size, Vector2 position ) : base ( game, size, position ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public Block ( FluxGame game, Vector2 size ) : base ( game, size ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public Block ( FluxGame game ) : base ( game ) { }

    }
}
