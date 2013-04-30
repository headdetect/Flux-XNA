using FluxEngine.Entity;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Flux.Entities.Sprites {
    public class Background : Sprite {

        public override Vector2 Position { get; set; }
        public override float Rotation { get; set; }

        internal Background ( FluxGame gaem )
            : base ( gaem ) {
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {

            this.Position = Game.Camera.Position - Origin; 
        }

        public override void Init () {
            this.Size = new Vector2 ( Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height );
            this.Origin = Size / 2;
            this.ZIndex = -1;
        }

        public override void Draw ( GameTime gameTime ) {
            Game.SpriteBatch.Draw ( Texture, Position, new Rectangle ( 0, 0, (int) Size.X * 2, (int) Size.Y * 2 ), Color.White, Game.Camera.Rotation, Origin, ZoomScale, SpriteEffects.None, 1f );
        }


        public override void Destroy ( bool animation ) {

        }

        public void ChangeBackground ( string contentName ) {
            Texture = Game.Content.Load<Texture2D> ( "Wood/Textures/" + contentName );
        }
    }
}
