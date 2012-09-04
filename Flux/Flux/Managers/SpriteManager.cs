using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flux.Model.Sprites;
using Microsoft.Xna.Framework;

namespace Flux.Managers {

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
        public static List<Sprite> Sprites { get; set; }

        static SpriteManager () {
            Sprites = new List<Sprite>( 255 );
            KeyboardManager.KeyPressEvent += new EventHandler<KeyEventArgs>( KeyInvoked );
        }

        /// <summary>
        /// Adds the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        public static void Add ( Sprite sprite ) {
            Sprites.Add( sprite );
            sprite.ID = Sprites.Count;
            sprite.Init();
        }

        /// <summary>
        /// Removes the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="animation">if set to <c>true</c> [animation].</param>
        public static void Remove ( Sprite sprite, bool animation = true ) {
            sprite.Destroy( animation );
            Sprites.Remove( sprite );
        }

        /// <summary>
        /// Updates all sprites with a specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        internal static void Update ( GameTime gameTime ) {
            for ( int i = 0; i < Sprites.Count; i++ ) {
                Sprites[ i ].Update( gameTime );
            }
        }

        /// <summary>
        /// Draws all sprites with the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        internal static void Draw ( GameTime gameTime ) {
            for ( int i = 0; i < Sprites.Count; i++ ) {
                Sprites[ i ].Draw( gameTime );
            }
        }


        /// <summary>
        /// Invokes a key listener on all of the sprites
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="Flux.Managers.KeyEventArgs"/> instance containing the event data.</param>
        internal static void KeyInvoked ( object sender, KeyEventArgs eventArgs ) {
            for ( int i = 0; i < Sprites.Count; i++ ) {
                Sprites[ i ].KeyEvent( eventArgs );
            }
        }

    }
}
