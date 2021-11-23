﻿using System;

namespace Mechanics.Geometry
{
    /// <summary>
    /// Represents a 2-dimensional vector from origin to a point
    /// </summary>
    public class Vector2D
    {
        /// <summary>
        /// Create a vector from the origin to point (i, j)
        /// </summary>
        /// <param name="u">x-direction component of vector</param>
        /// <param name="v">y-direction component of vector</param>
        public Vector2D(double u, double v)
        {
            this.u = u;
            this.v = v;
        }

        /// <summary>
        /// Create a vector between two <see cref="Point2D"/> objects
        /// </summary>
        /// <param name="start">Start point of <see cref="Vector2D"/></param>
        /// <param name="end">End point of <see cref="Vector2D"/></param>
        public Vector2D(Point2D start, Point2D end)
        {
            u = end.x - start.x;
            v = end.y - start.y;
        }

        /// <summary>
        /// Magnitude of the vector in the i direction along the x-axis
        /// </summary>
        public double u { get; set; }

        /// <summary>
        /// Magnitude of the vector in the j direction along the y-axis
        /// </summary>
        public double v { get; set; }

        /// <summary>
        /// Calculates the magnitude of the angle between two <see cref="Vector2D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to calculate angle to</param>
        /// <returns>Value of angle between <see cref="Vector2D"/> objects</returns>
        public double AngleValueTo(Vector2D other)
        {
            double dotProduct = Dot(other);
            double normProduct = Norm() * other.Norm();
            return Math.Acos(dotProduct / normProduct);
        }

        /// <summary>
        /// Calculates angle between <see cref="Vector2D"/> objects with
        /// sign denoting the direction of the rotation
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to calculate angle to</param>
        /// <returns>
        /// Angle between <see cref="Vector2D"/> objects (positive indicates clockwise rotation)
        /// </returns>
        public double AngleTo(Vector2D other)
        {
            return Math.CopySign(AngleValueTo(other), Cross(other));
        }

        /// <summary>
        /// Calculates the cosine of <see cref="Vector2D"/>
        /// </summary>
        /// <returns>Cosine of <see cref="Vector2D"/></returns>
        public double Cosine()
        {
            return v / Norm();
        }

        /// <summary>
        /// Returns the cross product between two <see cref="Vector2D"/> objects
        /// </summary>
        /// <remarks>
        /// The z-axis component is implied to be zero and is used primarily
        /// for determining the rotational direction of angles (positive is counterclockwise).
        /// A cross product of zero indicates a parallel vector.
        /// </remarks>
        /// <param name="other"><see cref="Vector2D"/> to cross</param>
        /// <returns>Cross product</returns>
        public double Cross(Vector2D other)
        {
            return (u * other.v) - (v * other.u);
        }

        /// <summary>
        /// Returns the dot product of two <see cref="Vector2D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to dot</param>
        /// <returns>Dot product</returns>
        public double Dot(Vector2D other)
        {
            return (u * other.u) + (v * other.v);
        }

        /// <summary>
        /// Checks to see if <see cref="Vector2D"/> is of unit length
        /// </summary>
        /// <returns>True if <see cref="Vector2D"/> is normal</returns>
        public bool IsNormal()
        {
            const double NormCondition = 1.0;
            return DoubleCompare.AreEqual(Norm(), NormCondition);
        }

        /// <summary>
        /// Checks if a given <see cref="Vector2D"/> object is parallel
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to check if parallel</param>
        /// <returns>True if <see cref="Vector2D"/> is parallel</returns>
        public bool IsParalelTo(Vector2D other)
        {
            return DoubleCompare.IsEffectivelyZero(Cross(other));
        }

        /// <summary>
        /// Checks if a given <see cref="Vector2D"/> object is perpendicular
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to check if perpendicular</param>
        /// <returns>True if <see cref="Vector2D"/> is perpendicular</returns>
        public bool IsPerpendicularTo(Vector2D other)
        {
            return DoubleCompare.IsEffectivelyZero(Dot(other));
        }

        /// <summary>
        /// Returns the norm (length) of the <see cref="Vector2D"/> object
        /// </summary>
        /// <returns>Length of <see cref="Vector2D"/></returns>
        public double Norm()
        {
            return Math.Sqrt(Math.Pow(u, 2) + Math.Pow(v, 2));
        }

        /// <summary>
        /// Returns unit length <see cref="Vector2D"/> in the direction of the original <see cref="Vector2D"/>
        /// </summary>
        /// <returns></returns>
        public Vector2D Normalized()
        {
            return ScaledBy(1.0 / Norm());
        }

        /// <summary>
        /// Returns <see cref="Vector2D"/> object of same length but opposite direction
        /// </summary>
        /// <returns><see cref="Vector2D"/></returns>
        public Vector2D Opposite()
        {
            return new Vector2D(-u, -v);
        }

        /// <summary>
        /// Returns <see cref="Vector2D"/> object of same length but perpendicular
        /// </summary>
        /// <returns><see cref="Vector2D"/></returns>
        public Vector2D Perpendicular()
        {
            return new Vector2D(-v, u);
        }

        /// <summary>
        /// Returns projection of <see cref="Vector2D"/> onto another <see cref="Vector2D"/>
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to project over</param>
        /// <returns>Length of projection</returns>
        public double ProjectionOver(Vector2D other)
        {
            return Dot(other.Normalized());
        }

        /// <summary>
        /// Returns <see cref="Vector2D"/> of same length at a given rotation
        /// </summary>
        /// <param name="radians">Rotation in radians</param>
        /// <returns>Rotated <see cref="Vector2D"/></returns>
        public Vector2D Rotated(double radians)
        {
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            return new Vector2D(u * cos - v * sin, u * sin - v * cos);
        }

        /// <summary>
        /// Returns a <see cref="Vector2D"/> object that is scaled by a
        /// factor relative to the original <see cref="Vector2D"/> object
        /// </summary>
        /// <param name="scalarValue">Scaling factor</param>
        /// <returns>Scaled <see cref="Vector2D"/></returns>
        public Vector2D ScaledBy(double scalarValue)
        {
            return new Vector2D(scalarValue * u, scalarValue * v);
        }

        /// <summary>
        /// Calculates the sine of the given vector
        /// </summary>
        /// <returns>Sine of <see cref="Vector2D"/></returns>
        public double Sine()
        {
            return u / Norm();
        }

        /// <summary>
        /// Convert <see cref="Vector2D"/> object to a <see cref="Vector3D"/> object
        /// </summary>
        /// <returns>Three-dimensional vector</returns>
        public Vector3D ToVector3D()
        {
            return new Vector3D(this);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Vector2D);
        }

        public bool Equals(Vector2D other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return DoubleCompare.AreEqual(u, other.u) && DoubleCompare.AreEqual(v, other.v);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(u, v);
        }

        public override string ToString()
        {
            return String.Format("({0}i, {1}j) with norm of {2}", u, v, Norm());
        }

        public static Vector2D operator +(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.u + right.u, left.v + right.v);
        }

        public static Vector2D operator -(Vector2D left, Vector2D right)
        {
            return new Vector2D(left.u - right.u, left.v - right.v);
        }

        public static Vector2D operator -(Vector2D vec)
        {
            return new Vector2D(-vec.u, -vec.v);
        }

        public static bool operator ==(Vector2D left, Vector2D right)
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

        public static bool operator !=(Vector2D left, Vector2D right)
        {
            return !(left == right);
        }
    }
}
