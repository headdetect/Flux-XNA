using Microsoft.Xna.Framework.Graphics;

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

        public ContentManager ( FluxGame fluxGame ) {
            BallTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/BallTexture" );
            WallTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/WallTexture" );
            CursorTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/CursorTexture" );
            ToolBoxTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/ToolBoxTexture" );
            TriangleTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/TriangleTexture" );
            TriangleTexture_Hover = fluxGame.Content.Load<Texture2D>( "Wood/Textures/TriangleTexture_Hover" );
            RotationOverlay = fluxGame.Content.Load<Texture2D>( "Wood/Textures/RotationOverlay" );
            MoveOverlay = fluxGame.Content.Load<Texture2D>( "Wood/Textures/MoveOverlay" );


            FPSFont = fluxGame.Content.Load<SpriteFont>( "Fonts/fpsfont" );
            ToolBoxFont = fluxGame.Content.Load<SpriteFont>( "Fonts/ToolBoxFont" );
        }

        public ContentManager ( FluxGame fluxGame, string theme ) {
            BallTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/BallTexture" );
            WallTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/WallTexture" );
            CursorTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/CursorTexture" );
            ToolBoxTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/ToolBoxTexture" );
            TriangleTexture = fluxGame.Content.Load<Texture2D>( "Wood/Textures/TriangleTexture" );
            TriangleTexture_Hover = fluxGame.Content.Load<Texture2D>( "Wood/Textures/TriangleTexture_Hover" );
            RotationOverlay = fluxGame.Content.Load<Texture2D>( "Wood/Textures/RotationOverlay" );
            MoveOverlay = fluxGame.Content.Load<Texture2D>( "Wood/Textures/MoveOverlay" );


            FPSFont = fluxGame.Content.Load<SpriteFont>( "Fonts/fpsfont" );
            ToolBoxFont = fluxGame.Content.Load<SpriteFont>( "Fonts/ToolBoxFont" );
        }
    }
}
