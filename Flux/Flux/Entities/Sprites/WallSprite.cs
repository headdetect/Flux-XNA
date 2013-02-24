using System;
using FarseerPhysics.Common;
using Flux.Managers;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using FarseerPhysics.Factories;
using FarseerPhysics;

namespace Flux.Entities.Sprites {
    public class WallSprite : PhysicsSprite {

        private const int WALL_SIZE = 30;

        public WallSprite ( FluxGame fluxGame, Vector2 position, float width, float height )
            : base( fluxGame, new Vector2( width, height ), position ) {

            this.Body = BodyFactory.CreateRectangle( Game.PhysicsWorld, ConvertUnits.ToSimUnits( Size.X ), ConvertUnits.ToSimUnits( Size.Y ), 1f, ConvertUnits.ToSimUnits( position ) );

            Origin = new Vector2( width / 2f, height / 2f );
        }


        public override void Init () {
            Texture = ContentManager.WallTexture;
        }

        public override void Draw ( GameTime gameTime ) {
            Game.SpriteBatch.Draw( Texture, Position, new Rectangle( 0, 0, Math.Max( (int) ( Size.X - ( Size.X % WALL_SIZE ) ), WALL_SIZE ), Math.Max( (int) ( Size.Y - ( Size.Y % WALL_SIZE ) ), WALL_SIZE ) ), Color.White, Convert.ToSingle( Rotation * ( Math.PI / 180 ) ), Origin, ZoomScale, SpriteEffect, ZIndex );
        }

        public override void Destroy ( bool animation ) { }
    }
}
