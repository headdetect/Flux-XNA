using Flux.Entities.Sprites;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using Flux.Display;

namespace Flux.Entities {
    public class Player {

        /// <summary>
        /// Gets or sets the sprite.
        /// </summary>
        /// <value>
        /// The sprite.
        /// </value>
        public Sprite Sprite { get; set; }

        FluxGame game;

        public Player ( FluxGame game ) {
            this.game = game;

            Sprite = new BallSprite( game, new Vector2( game.HUD.Width / 4f, game.HUD.Height / 4f ) );
            game.HUD.HUDObjects.Add( new SpeedComponent( game ) );
            game.SpriteManager.Add(Sprite);
        }
    }
}
