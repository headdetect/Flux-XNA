using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Common;
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
        /// Gets or sets the vertices all in simulation display.
        /// </summary>
        /// <value>
        /// The vertices.
        /// </value>
        public Vertices Vertices { get; set; }

        public new Vector2 Position {
            get { return Body != null ? ConvertUnits.ToDisplayUnits( Body.Position ) : base.Position; }
            set { if ( Body != null ) Body.Position = ConvertUnits.ToSimUnits( value ); }
        }

        public new float Rotation {
            get { return Body != null ? ConvertUnits.ToDisplayUnits( Body.Rotation ) : base.Rotation; }
            set { if ( Body != null ) Body.Rotation = ConvertUnits.ToSimUnits( value ); }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        protected PhysicsSprite ( FluxGame game, Vector2 size, Vector2 position )
            : base( game, size, position ) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        protected PhysicsSprite ( FluxGame game, Vector2 size ) : this( game, size, Vector2.Zero ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        protected PhysicsSprite ( FluxGame game ) : this( game, Vector2.Zero, Vector2.Zero ) { }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update ( GameTime gameTime ) {

            //The getters and setters are overridden. 
            
            base.Position = Position;
            base.Rotation = Rotation;
        }

        /// <summary>
        /// Determines whether the points are in the bounds of the sprite
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the points are in the bounds of the sprite; otherwise, <c>false</c>.
        /// </returns>
        public new bool IsInBounds ( Vector2 point ) {
            return IsInBounds( point.X, point.Y );
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

            if ( Vertices != null ) {
                return IsInPolygonBounds( x, y );
            }

            Rectangle tangle = VectorUtils.VectorsToRectangle( ConvertUnits.ToDisplayUnits( Body.Position ), Size );

            return !tangle.IsEmpty && tangle.Contains( (int) x, (int) y );
        }

        public bool IsInPolygonBounds ( Vector2 point ) {
            return IsInPolygonBounds( point.X, point.Y );
        }

        public bool IsInPolygonBounds ( float X, float Y ) {
            if ( Vertices == null ) {
                return false;
            }

            X = ConvertUnits.ToSimUnits( X );
            Y = ConvertUnits.ToSimUnits( Y );

            Vertices verts = VectorUtils.AddVertices( Vertices, Position );

            int i;
            int j;
            bool result = false;
            for ( i = 0, j = verts.Count - 1; i < verts.Count; j = i++ ) {
                if ( ( verts[ i ].Y > Y ) != ( verts[ j ].Y > Y ) &&
                    ( X < ( verts[ j ].X - verts[ i ].X ) * ( Y - verts[ i ].Y ) / ( verts[ j ].Y - verts[ i ].Y ) + verts[ i ].X ) ) {
                    result = !result;
                }
            }
            return result;
        }
    }
}
