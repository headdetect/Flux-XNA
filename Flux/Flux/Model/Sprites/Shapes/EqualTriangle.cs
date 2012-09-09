using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;

namespace Flux.Model.Sprites.Shapes {
    public class EqualTriangle : Shape {

        readonly Vector2[] VERTS = {
            Vector2.Zero,
            new Vector2(-1, 1),
            Vector2.One
        };

        public EqualTriangle ( FluxGame game ) : base(game) {
            this.Body = BodyFactory.CreatePolygon( game.PhysicsWorld, new Vertices( VERTS ), 1f );
            this.Body.CreateFixture( new FarseerPhysics.Collision.Shapes.PolygonShape( new Vertices( VERTS ), 1f ) );
            this.Body.FixtureList[ 0 ].Restitution = .5f;
        }

        public override void Init () {

        }

        public override void Destroy ( bool animate ) {
            if ( animate ) {
            }
        }


        public override string Name {
            get {
                return "Triangle";
            }
        }
    }
}
