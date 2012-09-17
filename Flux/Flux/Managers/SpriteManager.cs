using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Model.Sprites;
using Microsoft.Xna.Framework;
using Flux.Utils;
using System.Diagnostics;

namespace Flux.Managers {

    /// <summary>
    /// Manager for all sprites in the game
    /// </summary>
    public class SpriteManager {

        public Sprite BackgroundSprite;

        public readonly RotationOverlaySprite RotationOverlay;

        public readonly MoveOverlaySprite MoveOverlay;

        /// <summary>
        /// Gets or sets the sprites.
        /// </summary>
        /// <value>
        /// The sprites.
        /// </value>
        public List<Sprite> Sprites { get; set; }

        public SpriteManager ( FluxGame game ) {
            Sprites = new List<Sprite> ( 255 );
            BackgroundSprite = game.Background;
            BackgroundSprite.Init ();

            RotationOverlay = new RotationOverlaySprite ( game );
            MoveOverlay = new MoveOverlaySprite ( game );

            RotationOverlay.Init ();
            MoveOverlay.Init ();
        }

        /// <summary>
        /// Adds the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        public void Add ( Sprite sprite ) {
            Sprites.Add ( sprite );
            sprite.ID = Sprites.Count;
            sprite.Init ();
        }

        /// <summary>
        /// Removes the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="animation">if set to <c>true</c> [animation].</param>
        public void Remove ( Sprite sprite, bool animation = true ) {
            sprite.Destroy ( animation );
            Sprites.Remove ( sprite );
        }

        /// <summary>
        /// Updates all sprites with a specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        [DebuggerStepThrough]
        internal void Update ( GameTime gameTime ) {
            BackgroundSprite.Update ( gameTime );
            RotationOverlay.Update ( gameTime );
            MoveOverlay.Update ( gameTime );

            for ( int i = 0; i < Sprites.Count; i++ ) {
                Sprites[ i ].Update ( gameTime );
            }
        }

        /// <summary>
        /// Draws all sprites with the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
       [DebuggerStepThrough]
        internal void Draw ( GameTime gameTime ) {
            BackgroundSprite.Draw ( gameTime );
            RotationOverlay.Draw ( gameTime );
            MoveOverlay.Draw ( gameTime );

            for ( int i = 0; i < Sprites.Count; i++ ) {
                Sprites[ i ].Draw ( gameTime );
            }
        }


    }
}
