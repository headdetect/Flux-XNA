using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Flux.Managers;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework.Graphics;
using Flux.Utils;

namespace Flux.Model.Sprites {
    public class WallSprite : PhysicsSprite {

        private const int WALL_SIZE = 30;

        public WallSprite ( FluxGame fluxGame, Vector2 position, int width, int height )
            : base( fluxGame, new Vector2( width, height ), position ) {

                this.Body = BodyFactory.CreateRectangle( Flux.PhysicsWorld, width / PhysicsUtils.PixelsToMeterRatio, height / PhysicsUtils.PixelsToMeterRatio, 1f, position / PhysicsUtils.PixelsToMeterRatio );
                //this.Origin = Vector2.Zero;
        }


        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            base.Update( gameTime );
        }

        public override void Init () {
            Texture = Flux.TextureManager.WallTexture;
        }

        public override void Draw ( GameTime gameTime ) {
            Flux.SpriteBatch.Draw( Texture, Position, new Rectangle( 0, 0, Math.Max( (int) ( Size.X - ( Size.X % WALL_SIZE ) ), WALL_SIZE ), Math.Max( (int) ( Size.Y - ( Size.Y % WALL_SIZE ) ), WALL_SIZE ) ), Color.White, Convert.ToSingle( Rotation * ( Math.PI / 180 ) ), Origin, ZoomScale, SpriteEffect, ZIndex );
        }

        public override void Destroy ( bool animation ) {

        }
    }
}
