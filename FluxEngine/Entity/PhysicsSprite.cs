using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FluxEngine.Utils;
using Microsoft.Xna.Framework;
using FarseerPhysics;

namespace FluxEngine.Entity {

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

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public override Vector2 Position {
            get { return Body != null ? ConvertUnits.ToDisplayUnits( Body.Position ) : Vector2.Zero; }
            set { if ( Body != null ) Body.Position = ConvertUnits.ToSimUnits( value ); }
        }

        /// <summary>
        /// Gets or sets the rotation. Rotation goes from 0 - 359 degrees.
        /// </summary>
        /// <value>
        /// The rotation.
        /// </value>
        public override float Rotation {
            get { return Body != null ? ConvertUnits.ToDisplayUnits( Body.Rotation ) : 0; }
            set { if ( Body != null ) Body.Rotation = ConvertUnits.ToSimUnits( value ); }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        protected PhysicsSprite ( BaseFluxGame game, Vector2 size, Vector2 position ) : base( game, size, position ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="position">The position.</param>
        protected PhysicsSprite ( BaseFluxGame game, Vector2 position ) : this( game, Vector2.Zero, position ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicsSprite"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        protected PhysicsSprite ( BaseFluxGame game ) : this( game, Vector2.Zero, Vector2.Zero ) { }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update ( GameTime gameTime ) { }

        /// <summary>
        /// Determines whether the points are in the bounds of the sprite
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the points are in the bounds of the sprite; otherwise, <c>false</c>.
        /// </returns>
        public new bool IsInBounds ( Vector2 point ) {
            if ( Body == null ) {
                return false;
            }

            Fixture fix = Game.PhysicsWorld.TestPoint( Game.Camera.ConvertScreenLocationToWorldLocation( point ) );

            return fix != null && fix.Body == Body;
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
            return IsInBounds( new Vector2( x, y ) );
        }

    }
}
