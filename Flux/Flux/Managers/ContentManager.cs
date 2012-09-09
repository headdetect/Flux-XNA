using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Flux.Managers {
    public class ContentManager {

        #region Textures

        public readonly Texture2D BallTexture;

        public readonly Texture2D WallTexture;

        public readonly Texture2D CursorTexture;

        #endregion

        #region Fonts

        public readonly SpriteFont FPSFont;

        #endregion

        public ContentManager ( FluxGame fluxGame ) {
            BallTexture = fluxGame.Content.Load<Texture2D>( "Textures/BallTexture" );
            WallTexture = fluxGame.Content.Load<Texture2D>( "Textures/WallTexture" );
            CursorTexture = fluxGame.Content.Load<Texture2D>( "Textures/CursorTexture" );

            FPSFont = fluxGame.Content.Load<SpriteFont>( "Fonts/fpsfont" );
        }
    }
}
