using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Common;
using FarseerPhysics;

namespace FluxEngine.Utils {
    public class PhysicsUtils {

        /// <summary>
        /// Vector 2D at which is the downward acceleration of average earth force.
        /// </summary>
        public static readonly Vector2 EarthGravity = new Vector2 ( 0, 9.81f );


        /// <summary>
        /// Creates a polygon.
        /// </summary>
        /// <param name="n">The number of sides.</param>
        /// <param name="r">The radius size.</param>
        /// <param name="convertUnits">Convert units to physics sim units</param>
        /// <returns>An array of Vector2s</returns>
        public static Vertices CreatePolygon ( int n, float r, bool convertUnits = true ) {
            if ( n < 2 ) {
                throw new ArithmeticException ( "Number of sides must be greater than 2" );
            }

            Vector2[] verts = new Vector2[ n ];
            for ( int i = 0; i < n; i++ ) {
                if ( convertUnits ) {
                    verts[ i ] = ConvertUnits.ToSimUnits ( new Vector2 ( r * (float) Math.Cos ( 2 * Math.PI * i / n ), r * (float) Math.Sin ( 2 * Math.PI * i / n ) ) );
                } else {
                    verts[ i ] = new Vector2 ( r * (float) Math.Cos ( 2 * Math.PI * i / n ), r * (float) Math.Sin ( 2 * Math.PI * i / n ) );
                }
            }

            return new Vertices ( verts );
        }
    }
}
