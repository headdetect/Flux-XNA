using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Flux.Managers;

namespace Flux.Model.Sprites {
    public class Background : Sprite {

        internal Background ( FluxGame gaem )
            : base ( gaem ) {

            
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {

            this.Position = Flux.Camera.Position - Origin; 
        }

        public override void Init () {
            this.Size = new Vector2 ( Flux.GraphicsDevice.Viewport.Width, Flux.GraphicsDevice.Viewport.Height );
            this.Origin = Size / 2;
        }

        public override void Draw ( GameTime gameTime ) {
            Flux.SpriteBatch.Draw ( Texture, Position, new Rectangle ( 0, 0, (int) Size.X * 2, (int) Size.Y * 2 ), Color.White, Flux.Camera.Rotation, Origin, ZoomScale, SpriteEffects.None, 1f );
        }


        public override void Destroy ( bool animation ) {

        }

        public void ChangeBackground ( string contentName, string theme = "Wood" ) {
            Texture = Flux.Content.Load<Texture2D> ( theme + "/Textures/" + contentName );
        }
    }
}
