using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Flux.Managers;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework.Graphics;

namespace Flux.Model.Sprites {
    public class WallSprite : PhysicsSprite {

        public WallSprite ( FluxGame fluxGame, Vector2 position, int width, int height )
            : base( fluxGame, new Vector2( width, height ), position ) {

            this.Body = BodyFactory.CreateRectangle( Flux.PhysicsWorld, Size.X / 64, Size.Y / 64, 1f, position / 64 );
            // this.Body.Friction = 64f;
            this.Body.BodyType = FarseerPhysics.Dynamics.BodyType.Static;
        }

        public override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            base.Update( gameTime );
        }

        public override void Init () {
            //Texture = Flux.TextureManager.WallTexture;
            Texture = new Texture2D( Flux.GraphicsDevice, (int)Size.X, (int)Size.Y, true, SurfaceFormat.Color );

            Color[] colors = new Color[ (int)(Size.X * Size.Y) ];
            for ( int i = 0; i < colors.Length; i++ ) {
                colors[ i ] = Color.White;
            }

            Texture.SetData( colors );
        }

        public override void Destroy ( bool animation ) {

        }
    }
}
