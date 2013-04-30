using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics;
using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        /// Gets the size from shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <returns></returns>
        public static Vector2 GetSizeFromShape ( Shape shape ) {
            switch ( shape.ShapeType ) {
                case ShapeType.Circle:
                    return new Vector2( shape.Radius );
                case ShapeType.Polygon:
                    return GetSizeFromVertices( ( (PolygonShape)shape ).Vertices );
                default:
                    return Vector2.Zero;
            }
        }

        /// <summary>
        /// Gets the size from vertices.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <returns></returns>
        public static Vector2 GetSizeFromVertices ( Vertices vertices ) {
            Vertices verts = new Vertices( vertices );
            Vector2 scale = ConvertUnits.ToDisplayUnits( Vector2.One );
            verts.Scale( ref scale );
            AABB vertsBounds = verts.GetAABB();
            verts.Translate( -vertsBounds.Center );
            return new Vector2( vertsBounds.UpperBound.X - vertsBounds.LowerBound.X,
                                            vertsBounds.UpperBound.Y - vertsBounds.LowerBound.Y );
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
            return new Point( (int)vector.X, (int)vector.Y );
        }

        /// <summary>
        /// Adds the vertices.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="position">The position.</param>
        /// <returns>the combined vertices</returns>
        public static Vertices AddVectorToVertices ( Vertices vertices, Vector2 position ) {
            Vertices verts = new Vertices( vertices.Count );
            for ( int i = 0; i < vertices.Count; i++ ) {
                verts.Add( vertices[ i ] + ConvertUnits.ToSimUnits( position ) );
            }
            return verts;
        }

        /// <summary>
        /// Adds the rectangles.
        /// </summary>
        /// <param name="rectOne">The rect one.</param>
        /// <param name="rectTwo">The rect two.</param>
        /// <returns>the combined rectangle</returns>
        public static Rectangle AddRectanglesAsPadding ( Rectangle rectOne, Rectangle rectTwo ) {
            return new Rectangle( rectOne.X - rectTwo.X, rectOne.Y - rectTwo.Y, rectOne.Width + rectTwo.Width, rectOne.Height + rectTwo.Height );
        }
    }
}