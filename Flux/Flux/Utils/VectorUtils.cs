using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Flux.Utils {
    public class VectorUtils {

        /// <summary>
        /// Turns to Vectors into a single rectangle
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        public static Rectangle VectorsToRectangle ( Vector2 start, Vector2 end ) {
            return new Rectangle( Convert.ToInt32( start.X ), Convert.ToInt32( start.Y ), Convert.ToInt32( end.X ), Convert.ToInt32( end.Y ) );
        }
    }
}
