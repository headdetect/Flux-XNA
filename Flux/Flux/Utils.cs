using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Flux {
    public class Utils {

        /// <summary>
        /// Turns to Vectors into a single rectangle
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        public static Rectangle VectorsToRectangle ( Vector2 start, Vector2 end ) {
            return new Rectangle( Convert.ToInt32( start.X ), Convert.ToInt32( start.Y ), Convert.ToInt32( end.X ), Convert.ToInt32( end.Y ) );
        }

        /// <summary>
        /// Vector 2D at which is the downward acceleration of average earth force.
        /// </summary>
        public static readonly Vector2 EarthGravity = new Vector2( 0, 9.81f );

        /// <summary>
        /// Pixels to meter ration in XNA, Value = 64f
        /// </summary>
        public const float PixelsToMeterRatio = 64f;


        /// <summary>
        /// Creates a polygon.
        /// </summary>
        /// <param name="n">The number of sides.</param>
        /// <param name="r">The radius size.</param>
        /// <returns>An array of Vector2s</returns>
        public static Vector2[] CreatePolygon ( int n, float r ) {
            if ( n < 5 ) {
                throw new ArithmeticException( "Number of sides must be greater than 4" );
            }

            Vector2[] verts = new Vector2[ n  ];
            for ( int i = 0; i < n; i++ ) {
                verts[ i ] = new Vector2( r * (float) Math.Cos( 2 * Math.PI * i / n ), r * (float) Math.Sin( 2 * Math.PI * i / n ) );
            }
            return verts;
        }
    }

}
