using FarseerPhysics;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Flux.Managers;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;

namespace Flux.Entities.Sprites.Blocks {
    public class EqualTriangleBlock : Block {

        private static readonly Vector2 DEFAULT_SIZE = new Vector2( 39, 35 );


        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public EqualTriangleBlock ( FluxGame game, Vector2 size, Vector2 position )
            : base( game, position ) {

            float width = ConvertUnits.ToSimUnits( size.X );
            float height = ConvertUnits.ToSimUnits( size.Y );
            float halfWidth = width * 0.5f;
            float halfHeight = height * 0.5f;

            float top = -halfHeight;
            float bottom = halfHeight;
            float left = -halfHeight;
            const float centerX = 0;
            float right = halfWidth;

            Vector2[] vertices = { new Vector2( centerX, top ), new Vector2( right, bottom ), new Vector2( left, bottom ) };
            Vertices = new Vertices( vertices );

            Body = BodyFactory.CreatePolygon( game.PhysicsWorld, Vertices, 1f, game.Camera.ConvertScreenLocationToWorldLocation( position ) );
            Body.BodyType = BodyType.Static;

            Origin = size / 2f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="position">The position.</param>
        public EqualTriangleBlock ( FluxGame game, Vector2 position )
            : this( game, DEFAULT_SIZE, position ) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public EqualTriangleBlock ( FluxGame game )
            : this( game, DEFAULT_SIZE ) {
        }


        public override void Init () {
            Texture = ContentManager.TriangleTexture;
            Size = new Vector2( Texture.Width, Texture.Height );
        }


        public override void Destroy ( bool animation ) {
        }
    }
}
