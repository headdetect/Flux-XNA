using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Flux.Model.Sprites;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Flux.Utils {
    public class TextureUtils {

        /// <summary>
        /// Creates a rectangle texture from a specified color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static Texture2D CreateFromColor ( FluxGame game, Microsoft.Xna.Framework.Color color, int width, int height ) {
            var texture = new Texture2D( game.GraphicsDevice, width, height, true, SurfaceFormat.Color );

            Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[ (int) ( width * height ) ];
            for ( int i = 0; i < colors.Length; i++ ) {
                colors[ i ] = color;
            }

            texture.SetData( colors );

            return texture;
        }


        /// <summary>
        /// Returns a bitmap from a texture.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <returns></returns>
        public static Bitmap TextureToBitmap ( Texture2D texture ) {

            byte[] textureData = new byte[ 4 * texture.Width * texture.Height ];
            texture.GetData<byte>( textureData );

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(
                           texture.Width, texture.Height,
                           System.Drawing.Imaging.PixelFormat.Format32bppArgb
                         );

            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(
                           new System.Drawing.Rectangle( 0, 0, texture.Width, texture.Height ),
                           System.Drawing.Imaging.ImageLockMode.WriteOnly,
                           System.Drawing.Imaging.PixelFormat.Format32bppArgb
                         );

            IntPtr safePtr = bmpData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy( textureData, 0, safePtr, textureData.Length );
            bmp.UnlockBits( bmpData );

            return bmp;

        }


    }
}
