using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry.Shapes
{
    public class Polygon
    {
        private List<Point2D> vertices;

        public Polygon(List<Point2D> vertices)
        {
            this.Vertices = vertices;
        }

        public List<Point2D> Vertices
        {
            get => vertices;
            set
            {
                if (value.Count < 3)
                {
                    throw new ArgumentOutOfRangeException("Three or more vertices required for polygon.");
                }
                vertices = value;
            }
        }

        /// <summary>
        /// Returns area of <see cref="Polygon"/>.
        /// </summary>
        /// <remarks>Assumes non-intersecting polygon edges.</remarks>
        /// <returns>Area of <see cref="Polygon"/></returns>
        public double Area()
        {
            double sum = 0;
            int next = 0;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                next = GetNextIndex(i);

                sum += (vertices[i].x * vertices[next].y) - (vertices[next].x * vertices[i].y);
            }

            return Math.Abs(0.5 * sum);
        }

        /// <summary>
        /// Returns <see cref="Point2D"/> representing the centroid of <see cref="Polygon"/> area
        /// </summary>
        /// <returns>Polygon centroid</returns>
        public Point2D Centroid()
        {
            double Cx = 0;
            double Cy = 0;
            
            int next = 0;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                next = GetNextIndex(i);

                Cx += (vertices[i].x + vertices[next].x) * (vertices[i].x * vertices[next].y - vertices[next].x * vertices[i].y);
                Cy += (vertices[i].y + vertices[next].y) * (vertices[i].x * vertices[next].y - vertices[next].x * vertices[i].y);
            }

            double divisor = 6.0 * Area();
            return new Point2D(Cx / divisor, Cy / divisor);
        }

        /// <summary>
        /// Returns the next index for area and centroid calculations, accounting for wrap-around
        /// if the initial vertex is not repeated at the end of the list to close out the polygon.
        /// </summary>
        /// <param name="i">List index</param>
        /// <returns>Next list index</returns>
        private int GetNextIndex(int i)
        {
            int next;
            if (i == vertices.Count - 1 && vertices[0] != vertices[vertices.Count - 1])
            {
                next = 0;
            }
            else
            {
                next = i + 1;
            }

            return next;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Polygon);
        }

        public bool Equals(Polygon other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Vertices.SequenceEqual(other.Vertices);            
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(vertices, Vertices);
        }
    }
}
