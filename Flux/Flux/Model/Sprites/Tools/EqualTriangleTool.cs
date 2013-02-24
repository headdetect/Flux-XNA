using System;
using Microsoft.Xna.Framework;
using Flux.Model.Sprites.Blocks;

namespace Flux.Model.Sprites.Tools {
    public class EqualTriangleTool : Tool {


        public EqualTriangleTool ( FluxGame game ) : base(game) {
        }

        public override void Init () {
            Texture = Flux.TextureManager.TriangleTexture;
            Size = new Vector2 ( (float) Texture.Width, (float) Texture.Height );
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

        public override Type BlockForm {
            get {
                return typeof ( EqualTriangleBlock );
            }
        }
    }
}
