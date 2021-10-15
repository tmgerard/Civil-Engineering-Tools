using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
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

    }
}
