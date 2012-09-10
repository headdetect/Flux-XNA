using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using Flux.Utils;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Dynamics;

namespace Flux.Model.Sprites.Shapes {
    public class EqualTriangle : Tool {


        public EqualTriangle ( FluxGame game ) : base(game) {
        }

        public override void Init () {
            Texture = Flux.TextureManager.TriangleTexture;
            uint[] data = new uint[ Texture.Width * Texture.Height ];
            Texture.GetData<uint>( data );

            Vertices textureVertices = PolygonTools.CreatePolygon( data, Texture.Width, false );

            Vector2 centroid = -textureVertices.GetCentroid();
            textureVertices.Translate( ref centroid );

            Origin = -centroid;

            textureVertices = SimplifyTools.ReduceByDistance( textureVertices, Texture.Height );

            //Body = BodyFactory.CreatePolygon( Flux.PhysicsWorld, textureVertices, 1f, BodyType.Static );

            //Body = BodyFactory.CreatePolygon(Flux.PhysicsWorld, new Vertices(PhysicsUtils.CreatePolygon( 3, Texture.Width / 64f ) ), 1f);
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

        public override Microsoft.Xna.Framework.Graphics.Texture2D TextureHovered {
            get { return Flux.TextureManager.TriangleTexture_Hover; }
        }

        public override void Update ( GameTime gameTime ) {
            
        }
    }
}
