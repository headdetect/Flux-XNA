﻿using Microsoft.Xna.Framework.Graphics;

namespace Flux.Managers {
    public class ContentManager {

        #region Textures

        public static Texture2D BallTexture;

        public static Texture2D WallTexture;

        public static Texture2D CursorTexture;

        public static Texture2D ToolBoxTexture;

        public static Texture2D TriangleTexture;

        public static Texture2D TriangleTexture_Hover;

        public static Texture2D RotationOverlay;

        public static Texture2D MoveOverlay;

        #endregion

        #region Fonts

        //TODO: Rename to actual font name

        public static SpriteFont FPSFont;

        public static SpriteFont ToolBoxFont; 

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
