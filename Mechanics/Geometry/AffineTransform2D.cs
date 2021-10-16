using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    /// <summary>
    /// Tranformstion which applies translation, scaling, and shear to points
    /// in two-dimensional space.
    /// </summary>
    public class AffineTransform2D
    {
        public AffineTransform2D() { }

        public AffineTransform2D(double scaleX, double scaleY, 
            double translateX, double translateY, 
            double shearX, double shearY)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            TranslateX = translateX;
            TranslateY = translateY;
            ShearX = shearX;
            ShearY = shearY;
        }

        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public double TranslateX { get; set; }
        public double TranslateY { get; set; }
        public double ShearX { get; set; }
        public double ShearY { get; set; }

        /// <summary>
        /// Combines two <see cref="AffineTransform2D"/> objects and returns a
        /// new <see cref="AffineTransform2D"/> object.
        /// </summary>
        /// <param name="other"><see cref="AffineTransform2D"/> to concatenate</param>
        /// <returns>Combined <see cref="AffineTransform2D"/></returns>
        public AffineTransform2D Concatenate(AffineTransform2D other)
        {
            AffineTransform2D newTransform = new AffineTransform2D();
            newTransform.ScaleX = other.ScaleX * ScaleX + other.ShearX * ShearY;
            newTransform.ScaleY = other.ShearY * ShearX + other.ScaleY * ScaleY;
            newTransform.TranslateX = other.ScaleX * TranslateX + other.ShearY * TranslateY + other.TranslateX;
            newTransform.TranslateY = other.ShearY * TranslateX + other.ScaleY * TranslateY + other.TranslateY;
            newTransform.ShearX = other.ScaleX * ShearY + other.ShearX * ScaleY;
            newTransform.ShearY = other.ShearY * ScaleX + other.ScaleY * ShearY;

            return newTransform;
        }

        /// <summary>
        /// <see cref="AffineTransform2D"/> that returns the inverse transform which
        /// returns geometric objects to their original state.
        /// </summary>
        /// <returns>Inverse <see cref="AffineTransform2D"/></returns>
        public AffineTransform2D Inverse()
        {
            double denom = ScaleX * ScaleY - ShearX * ShearY;

            AffineTransform2D inverse = new AffineTransform2D();
            inverse.ScaleX = ScaleY / denom;
            inverse.ScaleY = ScaleX / denom;
            inverse.TranslateX = (TranslateY * ShearX - ScaleY * TranslateX) / denom;
            inverse.TranslateY = (TranslateX * ShearY - ScaleX * TranslateY) / denom;
            inverse.ShearX = -ShearX / denom;
            inverse.ShearY = -ShearY / denom;

            return inverse;
        }

        /// <summary>
        /// Apply affine transform to <see cref="Point2D"/> object
        /// </summary>
        /// <param name="point"><see cref="Point2D"/> to transform</param>
        /// <returns>Transformed <see cref="Point2D"/></returns>
        public Point2D Transform(Point2D point)
        {
            double transformedX = (ScaleX * point.x) + (ShearX * point.y) + TranslateX;
            double transformedY = (ShearY * point.x) + (ScaleY * point.y) + TranslateY;
            return new Point2D(transformedX, transformedY);
        }

        /// <summary>
        /// Apply affine transform to <see cref="Segment2D"/> object
        /// </summary>
        /// <param name="segment"><see cref="Segment2D"/> to transform</param>
        /// <returns>Transformed <see cref="Segment2D"/></returns>
        public Segment2D Transform(Segment2D segment)
        {
            return new Segment2D(Transform(segment.Start), Transform(segment.End));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AffineTransform2D);
        }

        public bool Equals(AffineTransform2D other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return DoubleCompare.AreEqual(ScaleX, other.ScaleX) && 
                DoubleCompare.AreEqual(ScaleY, other.ScaleY) &&
                DoubleCompare.AreEqual(TranslateX, other.TranslateX) &&
                DoubleCompare.AreEqual(TranslateY, other.TranslateY) &&
                DoubleCompare.AreEqual(ShearX, other.ShearX) &&
                DoubleCompare.AreEqual(ShearY, other.ShearY);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ScaleX, ScaleY, TranslateX, TranslateY, ShearX, ShearY);
        }

        public static bool operator ==(AffineTransform2D left, AffineTransform2D right)
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

        public static bool operator !=(AffineTransform2D left, AffineTransform2D right)
        {
            return !(left.Equals(right));
        }

        /// <summary>
        /// Concatenates two <see cref="AffineTransform2D"/> objects.
        /// </summary>
        /// <param name="left"><see cref="AffineTransform2D"/> to concatenate to</param>
        /// <param name="right"><see cref="AffineTransform2D"/> concatenating to original transform</param>
        /// <returns>Concatenated <see cref="AffineTransform2D"/></returns>
        public static AffineTransform2D operator +(AffineTransform2D left, AffineTransform2D right)
        {
            return left.Concatenate(right);
        }

        /// <summary>
        /// Returns inverse of given <see cref="AffineTransform2D"/>
        /// </summary>
        /// <param name="transform"><see cref="AffineTransform2D"/> to invert</param>
        /// <returns>Inverted <see cref="AffineTransform2D"/></returns>
        public static AffineTransform2D operator -(AffineTransform2D transform)
        {
            return transform.Inverse();
        }
    }
}
