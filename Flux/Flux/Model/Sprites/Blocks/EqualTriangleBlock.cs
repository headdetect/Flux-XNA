using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;
using Flux.Utils;
using Microsoft.Xna.Framework.Input;

namespace Flux.Model.Sprites.Blocks {
    public class EqualTriangleBlock : Block {

        private readonly Vector2 DEFAULT_SIZE = new Vector2( 35, 40 );

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public EqualTriangleBlock ( FluxGame game, Vector2 size, Vector2 position ) : base( game, size, position ) {
            Body = BodyFactory.CreatePolygon( game.PhysicsWorld, PhysicsUtils.CreatePolygon( 3, size.Y ), 1f );
            Body.BodyType = FarseerPhysics.Dynamics.BodyType.Static;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="size">The size.</param>
        public EqualTriangleBlock ( FluxGame game, Vector2 size ) : base( game, size ) {
            Body = BodyFactory.CreatePolygon( game.PhysicsWorld, PhysicsUtils.CreatePolygon( 3, size.Y ), 1f );
            Body.BodyType = FarseerPhysics.Dynamics.BodyType.Static;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualTriangleBlock"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public EqualTriangleBlock ( FluxGame game ) : base( game ) {
            Size = DEFAULT_SIZE;
            Body = BodyFactory.CreatePolygon( game.PhysicsWorld, PhysicsUtils.CreatePolygon( 3, Size.Y ), 1f );
            Body.BodyType = FarseerPhysics.Dynamics.BodyType.Static;
        }


        public override void Init () {
            Texture = Flux.TextureManager.TriangleTexture;
        }

        public override void Destroy ( bool animation ) {
        }
    }
}
