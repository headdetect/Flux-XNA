using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flux.Entities.Sprites {
    public class Prefabs {

        /// <summary>
        /// Gets the move overlay sprite.
        /// </summary>
        public static MoveOverlaySprite MoveOverlaySprite { get; private set; }

        /// <summary>
        /// Gets the rotation overlay sprite.
        /// </summary>
        public static RotationOverlaySprite RotationOverlaySprite { get; private set; }

        /// <summary>
        /// Creates the prefabs.
        /// </summary>
        /// <param name="game">The game.</param>
        public static void CreatePrefabs ( FluxGame game ) {

            MoveOverlaySprite = new MoveOverlaySprite( game );
            RotationOverlaySprite = new RotationOverlaySprite( game );


            game.SpriteManager.Add( MoveOverlaySprite );
            game.SpriteManager.Add( RotationOverlaySprite );

        }
    }
}
