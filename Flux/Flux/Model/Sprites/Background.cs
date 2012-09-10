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
            : base( gaem ) {

            SpriteManager.Sprites.Insert( 0, this );
            ID = SpriteManager.Sprites.Count;
            Init();
            Origin = Size / 2f;
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            this.Position = Flux.Camera.Position - Origin / 2 + new Vector2( 10 );
        }

        public override void Init () {
            this.ZIndex = 0;
            this.Size = new Vector2( Flux.GraphicsDevice.Viewport.Width, Flux.GraphicsDevice.Viewport.Height );
        }

        public override void Draw ( GameTime gameTime ) {
            Flux.SpriteBatch.Draw( Texture, Position, new Rectangle(0, 0, (int)Size.X, (int)Size.Y), Color.White, Convert.ToSingle( Rotation * ( Math.PI / 180 ) ), Origin, ZoomScale, SpriteEffect, ZIndex );
        }


        public override void Destroy ( bool animation ) {

        }

        public void ChangeBackground ( string contentName, string theme = "Wood" ) {
            Texture = Flux.Content.Load<Texture2D>( theme + "/Textures/" + contentName );
        }
    }
}
