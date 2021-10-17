using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    /// <summary>
    /// Represents a 2-dimensional cartesean coordinate point.
    /// </summary>
    public class Point2D
    {
        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double x { get; set; }
        public double y { get; set; }

        /// <summary>
        /// Creates new <see cref="Point2D"/> that is displaced by a <see cref="Vector2D"/> a given
        /// number of times
        /// </summary>
        /// <param name="vector">Displacemdnt vector</param>
        /// <param name="timesDisplaced">Number of times to apply displacement vector</param>
        /// <returns>Displaced <see cref="Point2D"/></returns>
        public Point2D DisplacedBy(Vector2D vector, double timesDisplaced = 1)
        {
            Vector2D scaledVector = vector.ScaledBy(timesDisplaced);
            return new Point2D(x + scaledVector.i, y + scaledVector.j);
        }

        /// <summary>
        /// Calculates the distance to a given <see cref="Point2D"/> object.
        /// </summary>
        /// <param name="other"><see cref="Point2D"/> object to find distance to</param>
        /// <returns>Distance between two <see cref="Point2D"/> objects</returns>
        public double DistanceTo(Point2D other)
        {
            double deltaX = other.x - this.x;
            double deltaY = other.y - this.y;
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Point2D);
        }

        public bool Equals(Point2D other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return DoubleCompare.AreEqual(x, other.x) && DoubleCompare.AreEqual(y, other.y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }

        /// <summary>
        /// Returns <see cref="Vector2D"/> between two <see cref="Point2D"/> objects
        /// </summary>
        /// <param name="left">End point of <see cref="Vector2D"/></param>
        /// <param name="right">Start point of <see cref="Vector2D"/></param>
        /// <returns></returns>
        public static Vector2D operator -(Point2D left, Point2D right)
        {
            return new Vector2D(left.x - right.x, left.y - right.y);
        }

        public static bool operator ==(Point2D left, Point2D right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                if (Object.ReferenceEquals(right, null))
                {
                    return true;
                }

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Point2D left, Point2D right)
        {
            return !(left.Equals(right));
        }
    }
}
