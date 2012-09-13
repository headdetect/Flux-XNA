using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Flux.Utils;
using FarseerPhysics;

namespace Flux.Model.Sprites {
    public abstract class PhysicsSprite : Sprite {

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public Body Body { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public PhysicsSprite ( FluxGame game, Vector2 size, Vector2 position )
            : base ( game, size, position ) {
                this.Body = new Body ( game.PhysicsWorld );
                this.Body.Position = ConvertUnits.ToSimUnits ( position );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public PhysicsSprite ( FluxGame game, Vector2 size ) : this ( game, size, Vector2.Zero ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public PhysicsSprite ( FluxGame game ) : this ( game, Vector2.Zero, Vector2.Zero ) { }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update ( GameTime gameTime ) {
            if ( Body == null )
                return;

            this.Position = ConvertUnits.ToDisplayUnits ( Body.Position );
            this.Rotation = Body.Rotation;
        }

        /// <summary>
        /// Determines whether the points are in the bounds of the sprite
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the points are in the bounds of the sprite; otherwise, <c>false</c>.
        /// </returns>
        public new bool IsInBounds ( Vector2 point ) {
            return IsInBounds ( point.X, point.Y );
        }

        /// <summary>
        /// Determines whether the points are in the bounds of the sprite.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        ///   <c>true</c> if the points are in the bounds of the sprite; otherwise, <c>false</c>.
        /// </returns>
        public new bool IsInBounds ( float x, float y ) {
            if ( Body == null ) {
                return false;
            }

            Rectangle tangle = VectorUtils.VectorsToRectangle ( FarseerPhysics.ConvertUnits.ToDisplayUnits ( Body.Position ), Size );

            if ( tangle.IsEmpty )
                return false;

            return tangle.Contains ( (int) x, (int) y );
        }
    }
}
