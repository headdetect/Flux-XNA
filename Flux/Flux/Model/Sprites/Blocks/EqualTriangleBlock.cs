using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;
using Flux.Utils;
using Microsoft.Xna.Framework.Input;

namespace Flux.Model.Sprites.Blocks {
    public class EqualTriangleBlock : Block {

        private static readonly Vector2 DEFAULT_SIZE = new Vector2( 39, 35 );

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public EqualTriangleBlock ( FluxGame game, Vector2 size, Vector2 position )
            : base( game) {

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
            Vertices = new Vertices ( vertices );

            Body = BodyFactory.CreatePolygon( game.PhysicsWorld, Vertices, 1f );
            Body.BodyType = FarseerPhysics.Dynamics.BodyType.Dynamic;

            this.Position = position;
            this.Size = size;
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
            Texture = Flux.TextureManager.TriangleTexture;
        }


        public override void Destroy ( bool animation ) {
        }
    }
}
