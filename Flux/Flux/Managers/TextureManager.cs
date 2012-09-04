using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Flux.Managers {
    public class TextureManager {

        public readonly Texture2D BallTexture;

        public readonly Texture2D WallTexture;

        public TextureManager ( FluxGame fluxGame ) {
            BallTexture = fluxGame.Content.Load<Texture2D>( "BallTexture" );
            WallTexture = fluxGame.Content.Load<Texture2D>( "WallTexture" );
        }
    }
}
