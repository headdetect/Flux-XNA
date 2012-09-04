using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Flux.Managers;

namespace Flux.Model.Sprites {
    public class Background : Sprite {

        internal Background ( FluxGame gaem ) : base (gaem) {
            SpriteManager.Add( this );
        }

        internal override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            
        }

        internal override void Init () {
            //this.ZIndex = -1;
            this.Position = Vector2.Zero;
            this.Size = new Vector2( Flux.GraphicsDevice.Viewport.Width, Flux.GraphicsDevice.Viewport.Height );
        }

        internal override void Destroy ( bool animation ) {
            
        }

        public void ChangeBackground ( string contentName ) {
            Texture = Flux.Content.Load<Texture2D>( contentName );
        }
    }
}
