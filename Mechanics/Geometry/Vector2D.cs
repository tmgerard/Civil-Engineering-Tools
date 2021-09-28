using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    public class Vector2D
    {
        /// <summary>
        /// Create a vector from the origin to point (i, j)
        /// </summary>
        /// <param name="i">x-direction component of vector</param>
        /// <param name="j">y-direction component of vector</param>
        public Vector2D(double i, double j)
        {
            this.i = i;
            this.j = j;
        }

        /// <summary>
        /// Create a vector between two <see cref="Point2D"/> objects
        /// </summary>
        /// <param name="start">Start point of <see cref="Vector2D"/></param>
        /// <param name="end">End point of <see cref="Vector2D"/></param>
        public Vector2D(Point2D start, Point2D end)
        {
            i = end.x - start.x;
            j = end.y - start.y;
        }

        public double i { get; set; }
        public double j { get; set; }

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
            return j / Norm();
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
            return (i * other.j) - (j * other.i);
        }

        /// <summary>
        /// Returns the dot product of two <see cref="Vector2D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Vector2D"/> to dot</param>
        /// <returns>Dot product</returns>
        public double Dot(Vector2D other)
        {
            return (i * other.i) + (j * other.j);
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
            return Math.Sqrt(Math.Pow(i, 2) + Math.Pow(j, 2));
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
            return new Vector2D(-i, -j);
        }

        /// <summary>
        /// Returns <see cref="Vector2D"/> object of same length but perpendicular
        /// </summary>
        /// <returns><see cref="Vector2D"/></returns>
        public Vector2D Perpendicular()
        {
            return new Vector2D(-j, i);
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
            return new Vector2D(i * cos - j * sin, i * sin - j * cos);
        }

        /// <summary>
        /// Returns a <see cref="Vector2D"/> object that is scaled by a
        /// factor relative to the original <see cref="Vector2D"/> object
        /// </summary>
        /// <param name="scalarValue">Scaling factor</param>
        /// <returns>Scaled <see cref="Vector2D"/></returns>
        public Vector2D ScaledBy(double scalarValue)
        {
            return new Vector2D(scalarValue * i, scalarValue * j);
        }

        /// <summary>
        /// Calculates the sine of the given vector
        /// </summary>
        /// <returns>Sine of <see cref="Vector2D"/></returns>
        public double Sine()
        {
            return i / Norm();
        }

    }
}
