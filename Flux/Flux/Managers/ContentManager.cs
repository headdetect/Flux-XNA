using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Flux.Utils;
using Microsoft.Xna.Framework;

namespace Flux.Managers {
    public class ContentManager {

        #region Textures

        public Texture2D BallTexture;

        public Texture2D WallTexture;

        public Texture2D CursorTexture;

        public Texture2D ToolBoxTexture;

        public Texture2D TriangleTexture;

        public Texture2D TriangleTexture_Hover;

        public Texture2D RotationOverlay;

        public Texture2D MoveOverlay;

        #endregion

        #region Fonts

        public SpriteFont FPSFont;

        public SpriteFont ToolBoxFont; 

        #endregion

        public ContentManager ( FluxGame fluxGame, string theme = "Wood" ) {
            BallTexture = fluxGame.Content.Load<Texture2D>( theme + "/Textures/BallTexture" );
            WallTexture = fluxGame.Content.Load<Texture2D>( theme + "/Textures/WallTexture" );
            CursorTexture = fluxGame.Content.Load<Texture2D>( theme + "/Textures/CursorTexture" );
            ToolBoxTexture = fluxGame.Content.Load<Texture2D>( theme + "/Textures/ToolBoxTexture" );
            TriangleTexture = fluxGame.Content.Load<Texture2D>( theme + "/Textures/TriangleTexture" );
            TriangleTexture_Hover = fluxGame.Content.Load<Texture2D>( theme + "/Textures/TriangleTexture_Hover" );
            RotationOverlay = fluxGame.Content.Load<Texture2D>( theme + "/Textures/RotationOverlay" );
            MoveOverlay = fluxGame.Content.Load<Texture2D>( theme + "/Textures/MoveOverlay" );


            FPSFont = fluxGame.Content.Load<SpriteFont>( "Fonts/fpsfont" );
            ToolBoxFont = fluxGame.Content.Load<SpriteFont>( "Fonts/ToolBoxFont" );
        }
    }
}
