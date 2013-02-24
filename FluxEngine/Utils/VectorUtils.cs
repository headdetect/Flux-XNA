using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;

namespace FluxEngine.Utils {
    public static class VectorUtils {

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
        /// Performs an conversion from <see cref="Microsoft.Xna.Framework.Point"/> to <see cref="Microsoft.Xna.Framework.Vector2"/>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static Vector2 ToVector ( this Point point ) {
            return new Vector2( point.X, point.Y );
        }

        /// <summary>
        /// Performs an conversion from <see cref="Microsoft.Xna.Framework.Vector2"/> to <see cref="Microsoft.Xna.Framework.Point"/>.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static Point ToPoint ( this Vector2 vector ) {
            return new Point( (int) vector.X, (int) vector.Y );
        }

        public static Vertices AddVertices ( Vertices vertices, Vector2 position ) {
            Vertices verts = new Vertices( vertices.Count );
            for ( int i = 0; i < vertices.Count; i++ ) {
                verts.Add( vertices[ i ] + ConvertUnits.ToSimUnits(position) );
            }
            return verts;
        }
    }
}
