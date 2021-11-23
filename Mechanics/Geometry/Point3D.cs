using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    public class Point3D
    {
        public Point3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Point3D(double x ,double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D(Point2D point, double z)
        {
            x = point.x;
            y = point.y;
            this.z = z;
        }

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        /// <summary>
        /// Creates new <see cref="Point3D"/> that is displaced by a <see cref="Vector3D"/> a given
        /// number of times
        /// </summary>
        /// <param name="vector">Displacemdnt vector</param>
        /// <param name="timesDisplaced">Number of times to apply displacement vector</param>
        /// <returns>Displaced <see cref="Point3D"/></returns>
        public Point3D DisplacedBy(Vector3D vector, double timesDisplaced = 1)
        {
            Vector3D scaledVector = vector.ScaledBy(timesDisplaced);
            return new Point3D(x + scaledVector.u, y + scaledVector.v, z + scaledVector.w);
        }

        /// <summary>
        /// Calculates the distance to a given <see cref="Point3D"/> object.
        /// </summary>
        /// <param name="other"><see cref="Point3D"/> object to find distance to</param>
        /// <returns>Distance between two <see cref="Point3D"/> objects</returns>
        public double DistanceTo(Point3D other)
        {
            double deltaX = other.x - x;
            double deltaY = other.y - y;
            double deltaZ = other.z - z;

            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Point3D);
        }

        public bool Equals(Point3D other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return DoubleCompare.AreEqual(x, other.x) && 
                DoubleCompare.AreEqual(y, other.y) && 
                DoubleCompare.AreEqual(z, other.z);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", x, y, z);
        }

        /// <summary>
        /// Returns <see cref="Vector3D"/> between two <see cref="Point3D"/> objects
        /// </summary>
        /// <param name="left">End point of <see cref="Vector3D"/></param>
        /// <param name="right">Start point of <see cref="Vector3D"/></param>
        /// <returns></returns>
        public static Vector3D operator -(Point3D left, Point3D right)
        {
            return new Vector3D(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        /// <summary>
        /// Creates new <see cref="Point3D"/> that is displaced by a <see cref="Vector3D"/>
        /// </summary>
        /// <param name="left"><see cref="Point3D"/> to diplace</param>
        /// <param name="right">Displacement <see cref="Vector3D"/></param>
        /// <returns>Displaced point</returns>
        public static Point3D operator +(Point3D left, Vector3D right)
        {
            return left.DisplacedBy(right);
        }

        public static bool operator ==(Point3D left, Point3D right)
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

        public static bool operator !=(Point3D left, Point3D right)
        {
            return !(left.Equals(right));
        }
    }
}
