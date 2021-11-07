using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    public class Vector3D
    {

        public Vector3D()
        {
            i = 0;
            j = 0;
            k = 0;
        }

        public Vector3D(double i, double j, double k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
        }

        public Vector3D(Vector2D vector)
        {
            i = vector.i;
            j = vector.j;
            this.k = 0;
        }

        public Vector3D(Vector2D vector, double k)
        {
            i = vector.i;
            j = vector.j;
            this.k = k;
        }

        /// <summary>
        /// Magnitude of the vector in the i direction along the x-axis
        /// </summary>
        public double i { get; set; }

        /// <summary>
        /// Magnitude of the vector in the j direction along the y-axis
        /// </summary>
        public double j { get; set; }

        /// <summary>
        /// Magnitude of the vector in the k direction along the z-axis
        /// </summary>
        public double k { get; set; }

        /// <summary>
        /// Calculates the magnitude of the angle between two <see cref="Vector3D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Vector3D"/> to calculate angle to</param>
        /// <returns>Value of angle between <see cref="Vector3D"/> objects</returns>
        public double AngleValueTo(Vector3D other)
        {
            double dotProduct = Dot(other);
            double normProduct = Norm() * other.Norm();
            return Math.Acos(dotProduct / normProduct);
        }

        /// <summary>
        /// Returns the cross product between two <see cref="Vector3D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Vector3D"/> to cross</param>
        /// <returns>Cross product</returns>
        public Vector3D Cross(Vector3D other)
        {
            double i = this.j * other.k - this.k * other.j;
            double j = -(this.i * other.k - this.k * other.i);
            double k = this.i * other.j - this.j * other.i;

            return new Vector3D(i, j, k);
        }

        /// <summary>
        /// Returns the dot product of two <see cref="Vector3D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Vector3D"/> to dot</param>
        /// <returns>Dot product</returns>
        public double Dot(Vector3D other)
        {
            return (i * other.i) + (j * other.j) + (k * other.k);
        }

        /// <summary>
        /// Checks to see if <see cref="Vector3D"/> is of unit length
        /// </summary>
        /// <returns>True if <see cref="Vector3D"/> is normal</returns>
        public bool IsNormal()
        {
            const double NormCondition = 1.0;
            return DoubleCompare.AreEqual(Norm(), NormCondition);
        }

        /// <summary>
        /// Checks if a given <see cref="Vector3D"/> object is parallel
        /// </summary>
        /// <param name="other"><see cref="Vector3D"/> to check if parallel</param>
        /// <returns>True if <see cref="Vector3D"/> is parallel</returns>
        public bool IsParallel(Vector3D other)
        {
            return Normalized() == other.Normalized();
        }

        /// <summary>
        /// Checks if a given <see cref="Vector3D"/> object is perpendicular
        /// </summary>
        /// <param name="other"><see cref="Vector3D"/> to check if perpendicular</param>
        /// <returns>True if <see cref="Vector3D"/> is perpendicular</returns>
        public bool IsPerpendicularTo(Vector3D other)
        {
            return DoubleCompare.IsEffectivelyZero(Dot(other));
        }

        /// <summary>
        /// Returns the norm (length) of the <see cref="Vector3D"/> object
        /// </summary>
        /// <returns>Length of <see cref="Vector3D"/></returns>
        public double Norm()
        {
            return Math.Sqrt(Math.Pow(i, 2) + Math.Pow(j, 2) + Math.Pow(k, 2));
        }

        /// <summary>
        /// Returns unit length <see cref="Vector3D"/> in the direction of the original <see cref="Vector3D"/>
        /// </summary>
        /// <returns></returns>
        public Vector3D Normalized()
        {
            return ScaledBy(1.0 / Norm());
        }

        /// <summary>
        /// Returns <see cref="Vector3D"/> object of same length but opposite direction
        /// </summary>
        /// <returns><see cref="Vector3D"/></returns>
        public Vector3D Opposite()
        {
            return new Vector3D(-i, -j, -k);
        }

        /// <summary>
        /// Returns projection of <see cref="Vector3D"/> onto another <see cref="Vector3D"/>
        /// </summary>
        /// <param name="other"><see cref="Vector3D"/> to project over</param>
        /// <returns>Length of projection</returns>
        public double ProjectionOver(Vector3D other)
        {
            return Dot(other.Normalized());
        }

        /// <summary>
        /// Returns a <see cref="Vector3D"/> object that is scaled by a
        /// factor relative to the original <see cref="Vector3D"/> object
        /// </summary>
        /// <param name="scalarValue">Scaling factor</param>
        /// <returns>Scaled <see cref="Vector3D"/></returns>
        public Vector3D ScaledBy(double scalarValue)
        {
            return new Vector3D(scalarValue * i, scalarValue * j, scalarValue * k);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Vector3D);
        }

        public bool Equals(Vector3D other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return DoubleCompare.AreEqual(i, other.i) &&
                DoubleCompare.AreEqual(j, other.j) &&
                DoubleCompare.AreEqual(k, other.k);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(i, j, k);
        }

        public override string ToString()
        {
            return String.Format("({0}i, {1}j, {2}k) with norm of {3}", i, j, k, Norm());
        }

        public static Vector3D operator +(Vector3D left, Vector3D right)
        {
            return new Vector3D(left.i + right.i, left.j + right.j, left.k + right.k);
        }

        public static Vector3D operator -(Vector3D left, Vector3D right)
        {
            return new Vector3D(left.i - right.i, left.j - right.j, left.k - right.k);
        }

        public static Vector3D operator -(Vector3D vec)
        {
            return new Vector3D(-vec.i, -vec.j, -vec.k);
        }

        public static bool operator ==(Vector3D left, Vector3D right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                if (Object.ReferenceEquals(right, null))
                {
                    return true;
                }

                return true;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Vector3D left, Vector3D right)
        {
            return !(left == right);
        }
    }
}
