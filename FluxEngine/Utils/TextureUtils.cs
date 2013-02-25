using System;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Diagnostics;

namespace FluxEngine.Utils {
    public class TextureUtils {

        /// <summary>
        /// Creates a rectangle texture from a specified color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Texture2D CreateFromColor ( BaseFluxGame game, Microsoft.Xna.Framework.Color color, int width, int height ) {
            var texture = new Texture2D ( game.GraphicsDevice, width, height, true, SurfaceFormat.Color );

            Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[ (int) ( width * height ) ];
            for ( int i = 0; i < colors.Length; i++ ) {
                colors[ i ] = color;
            }

            texture.SetData ( colors );

            return texture;
        }


        public static Texture2D CreateFromGradient ( BaseFluxGame game, Microsoft.Xna.Framework.Color top, Microsoft.Xna.Framework.Color bottom, int width, int height ) {
            var texture = new Texture2D ( game.GraphicsDevice, width, height, true, SurfaceFormat.Color );

            Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[ width * height ];
            for ( int y = 0; y < height; y++ ) {
                for ( int x = 0; x < width; x++ ) {
                    int a = 0xFF; //top.A * ( index / height ) + bottom.A * ( ( index / height ) - 1 );
                    int r = (int) ( top.R * (float) ( (float) y / (float) height ) + bottom.R * ( (float) ( (float) y / (float) height ) - 1 ) );
                    int g = (int) ( top.G * (float) ( (float) y / (float) height ) + bottom.G * ( (float) ( (float) y / (float) height ) - 1 ) );
                    int b = (int) ( top.B * (float) ( (float) y / (float) height ) + bottom.B * ( (float) ( (float) y / (float) height ) - 1 ) );



                    colors[ x ] = new Microsoft.Xna.Framework.Color ( Math.Abs ( r ), Math.Abs ( g ), Math.Abs ( b ), Math.Abs ( a ) );
                }
            }

            texture.SetData ( colors );

            return texture;
        }


        /// <summary>
        /// Returns a bitmap from a texture.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <returns></returns>
        public static Bitmap TextureToBitmap ( Texture2D texture ) {

            byte[] textureData = new byte[ 4 * texture.Width * texture.Height ];
            texture.GetData<byte> ( textureData );

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap (
                           texture.Width, texture.Height,
                           System.Drawing.Imaging.PixelFormat.Format32bppArgb
                         );

            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits (
                           new System.Drawing.Rectangle ( 0, 0, texture.Width, texture.Height ),
                           System.Drawing.Imaging.ImageLockMode.WriteOnly,
                           System.Drawing.Imaging.PixelFormat.Format32bppArgb
                         );

            IntPtr safePtr = bmpData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy ( textureData, 0, safePtr, textureData.Length );
            bmp.UnlockBits ( bmpData );

            return bmp;

        }


    }
}
