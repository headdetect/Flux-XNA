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

        public const float PixelsToMeterRatio = 64f;

    }

}
