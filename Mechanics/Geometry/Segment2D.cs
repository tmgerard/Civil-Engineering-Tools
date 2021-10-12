using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    public class Segment2D
    {
        const double Mid = 0.5;

        public Segment2D(Point2D start, Point2D end)
        {
            this.Start = start;
            this.End = end;
        }

        public Point2D Start { get; set; }

        public Point2D End { get; set; }

        /// <summary>
        /// Return <see cref="Vector2D"/> between <see cref="Segment2D"/> end points
        /// </summary>
        /// <returns><see cref="Vector2D"/> object</returns>
        public Vector2D DirectionVector()
        {
            return End - Start;
        }

        /// <summary>
        /// Return <see cref="Vector2D"/> of unit length between <see cref="Segment2D"/> end points
        /// </summary>
        /// <returns><see cref="Vector2D"/> object</returns>
        public Vector2D UnitDirectionVector()
        {
            Vector2D vec = new Vector2D(Start, End);
            return vec.Normalized();
        }

        /// <summary>
        /// Return <see cref="Vector2D"/> of unit length perpendicular to <see cref="Segment2D"/> object
        /// </summary>
        /// <returns><see cref="Vector2D"/> object</returns>
        public Vector2D NormalUnitVector()
        {
            return DirectionVector().Perpendicular().Normalized();
        }

        /// <summary>
        /// Return <see cref="Vector2D"/> perpendicular to <see cref="Segment2D"/> object
        /// </summary>
        /// <returns><see cref="Vector2D"/> object</returns>
        public Vector2D NormalVector()
        {
            return DirectionVector().Perpendicular();
        }

        /// <summary>
        /// Returns the length of the <see cref="Segment2D"/> object
        /// </summary>
        /// <returns><see cref="Segment2D"/> length</returns>
        public double Length()
        {
            return Start.DistanceTo(End);
        }

        /// <summary>
        /// Returns <see cref="Point2D"/> object corresponding to a location on the line segment given as
        /// a ratio of the segments length.
        /// </summary>
        /// <param name="ratio">Segment length ratio</param>
        /// <returns><see cref="Point2D"/> on line segment</returns>
        public Point2D PointAt(double ratio)
        {
            if !(IsOnSegment(ratio))
            {
                throw new ArgumentOutOfRangeException("Ratio must be between zero and one.");
            }

            return Start.DisplacedBy(this.DirectionVector(), ratio);
        }

        /// <summary>
        /// Returns <see cref="Point2D"/> at the center of the segment.
        /// </summary>
        /// <returns><see cref="Point2D"/> object</returns>
        public Point2D PointAtMiddle()
        {
            return PointAt(Mid);
        }

        /// <summary>
        /// Returns <see cref="Point2D"/> object corresponding to the closest point
        /// on the <see cref="Segment2D"/> object to a given <see cref="Point2D"/>
        /// object outside the segment.
        /// </summary>
        /// <param name="point"><see cref="Point2D"/> object outside segment</param>
        /// <returns><see cref="Point2D"/> object</returns>
        public Point2D ClosestPointTo(Point2D point)
        {
            Vector2D vecToPoint = new Vector2D(Start, point);
            Vector2D segmentUnitVector = this.UnitDirectionVector();
            double projection = vecToPoint.ProjectionOver(segmentUnitVector);

            if (projection < 0)
            {
                return Start;
            }
            else if (projection > Length())
            {
                return End;
            }
            else
            {
                return Start.DisplacedBy(segmentUnitVector, projection);
            }
        }

        /// <summary>
        /// Returns the distance between a <see cref="Point2D"/> in space to its closest
        /// point on the segment.
        /// </summary>
        /// <param name="point"><see cref="Point2D"/> object</param>
        /// <returns>Distance to point</returns>
        public double DistanceTo(Point2D point)
        {
            return point.DistanceTo(ClosestPointTo(point));
        }

        /// <summary>
        /// Returns <see cref="Point2D"/> object that represents
        /// the intersection point of two <see cref="Segment2D"/> objects.
        /// </summary>
        /// <param name="other"><see cref="Segment2D"/> object</param>
        /// <returns>Intersection point</returns>
        public Point2D IntersectionWith(Segment2D other)
        {
            Vector2D d1 = DirectionVector();
            Vector2D d2 = other.DirectionVector();

            if (d1.IsParalelTo(d2))
            {
                return null;
            }

            double cross = d1.Cross(d2);
            Vector2D delta = other.Start - Start;

            double t1 = (delta.i * d2.j - delta.j * d2.i) / cross;
            double t2 = (delta.i * d1.j - delta.j * d1.i) / cross;

            if (IsOnSegment(t1) && IsOnSegment(t2))
            {
                return PointAt(t1);
            }
            else
            {
                return null;
            }
        }

        private bool IsOnSegment(double ratio)
        {
            return !(ratio < 0 || ratio > 0);
        }
    }
}
