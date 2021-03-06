﻿using System;
using Flux.Entities.Sprites.Blocks;
using Flux.Managers;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;

namespace Flux.Entities.Sprites.Tools {
    public class EqualTriangleTool : Tool {

        public EqualTriangleTool ( FluxGame game ) : base(game) {
        }

        public override void Init () {
            Texture = ContentManager.TriangleTexture;
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
            get { return ContentManager.TriangleTexture_Hover; }
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
