using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Flux.Managers;
using FarseerPhysics.Factories;

namespace Flux.Model.Sprites {
    public class WallSprite : Sprite {

        public WallSprite ( FluxGame fluxGame, Rectangle rectangle ) : base (fluxGame) {
            this.Position = new Vector2( rectangle.X, rectangle.Y );
            this.Size = new Vector2( rectangle.Width, rectangle.Height );

            this.Body = BodyFactory.CreateRectangle( Flux.PhysicsWorld, Size.X / Utils.PixelsToMeterRatio, Size.Y / Utils.PixelsToMeterRatio, 1f, Position / Utils.PixelsToMeterRatio );
            this.Body.IsStatic = true;
            this.Body.Restitution = .3f;
            this.Body.Friction = .5f;
            this.Body.BodyType = FarseerPhysics.Dynamics.BodyType.Static;
        }

        internal override void Update ( Microsoft.Xna.Framework.GameTime gameTime ) {
            this.Position = this.Body.Position * Utils.PixelsToMeterRatio;
            this.Rotation = this.Body.Rotation;
        }

        internal override void Init () {
            this.Texture = Flux.TextureManager.WallTexture; 
        }

        internal override void Destroy ( bool animation ) {
            
        }
    }
}
