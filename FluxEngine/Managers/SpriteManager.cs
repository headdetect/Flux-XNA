using System;
using System.Collections.Generic;
using FluxEngine.Entity;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;

namespace FluxEngine.Managers {

    /// <summary>
    /// Manager for all sprites in the game
    /// </summary>
    public class SpriteManager {


        /// <summary>
        /// Gets or sets the sprites.
        /// </summary>
        /// <value>
        /// The sprites.
        /// </value>
        public List<Sprite> Sprites { get; set; }

        public SpriteManager () {
            Sprites = new List<Sprite>( 255 );
        }

        /// <summary>
        /// Adds the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        public void Add ( Sprite sprite ) {
            Sprites.Add( sprite );
            sprite.ID = Sprites.Count;
            sprite.Init();
        }

        /// <summary>
        /// Removes the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="animation">if set to <c>true</c> [animation].</param>
        public void Remove ( Sprite sprite ) {
            sprite.Destroy( true );
            Sprites.Remove( sprite );
        }

        /// <summary>
        /// Removes the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="animation">if set to <c>true</c> [animation].</param>
        public void Remove ( Sprite sprite, bool animation ) {
            sprite.Destroy( animation );
            Sprites.Remove( sprite );
        }


        /// <summary>
        /// Updates all sprites with a specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        [DebuggerStepThrough]
        public void Update ( GameTime gameTime ) {
            for ( int i = 0; i < Sprites.Count; i++ ) {
                Sprites[ i ].Update( gameTime );
            }
        }

        /// <summary>
        /// Draws all sprites with the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        [DebuggerStepThrough]
        public void Draw ( GameTime gameTime ) {
            foreach ( var sprite in Sprites.OrderBy( x => x.ZIndex ) ) {
                sprite.Draw( gameTime );
            }
        }


    }
}
