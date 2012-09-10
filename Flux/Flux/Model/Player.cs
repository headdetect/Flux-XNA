using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Model.Sprites;
using Microsoft.Xna.Framework;
using Flux.Managers;
using Flux.Display;

namespace Flux.Model {
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

            Sprite = new BallSprite( game, new Vector2( game.GraphicsDevice.Viewport.Bounds.Width / 2, game.GraphicsDevice.Viewport.Bounds.Height / 2 ) );
            game.HUD.HUDObjects.Add( new SpeedComponent( game ) );
            game.SpriteManager.Add(Sprite);
        }
    }
}
