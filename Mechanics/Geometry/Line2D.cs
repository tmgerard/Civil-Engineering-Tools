using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    public class Line2D
    {
        public Line2D(Point2D basePoint, Vector2D direction)
        {
            this.Base = basePoint;
            this.Direction = direction;
        }

        public Point2D Base { get; set; }
        public Vector2D Direction { get; set; }

        /// <summary>
        /// Checks if a given <see cref="Line2D"/> object is parallel
        /// </summary>
        /// <param name="other"><see cref="Line2D"/> object</param>
        /// <returns>True if lines are parallel</returns>
        public bool IsParallelTo(Line2D other)
        {
            return this.Direction.IsParalelTo(other.Direction);
        }

        /// <summary>
        /// Checks if a given <see cref="Line2D"/> object is perpendicular
        /// </summary>
        /// <param name="other"><see cref="Line2D"/> object</param>
        /// <returns>True if lines are perpendicular</returns>
        public bool IsPerpendicularTo(Line2D other)
        {
            return this.Direction.IsPerpendicularTo(other.Direction);
        }

        /// <summary>
        /// Creates <see cref="Line2D"/> object through a given <see cref="Point2D"/> object
        /// that is perpendicular to the existing line.
        /// </summary>
        /// <param name="point"><see cref="Point2D"/> line will intersect</param>
        /// <returns>New <see cref="Line2D"/></returns>
        public Line2D PerpendicularThrough(Point2D point)
        {
            return new Line2D(point, this.Direction.Perpendicular());
        }

        /// <summary>
        /// Creates <see cref="Line2D"/> object through a given <see cref="Point2D"/> object
        /// that is parallel to the existing line.
        /// </summary>
        /// <param name="point"><see cref="Point2D"/> line will intersect</param>
        /// <returns>New <see cref="Line2D"/></returns>
        public Line2D ParallelThrough(Point2D point)
        {
            return new Line2D(point, this.Direction);
        }

        /// <summary>
        /// Returns <see cref="Point2D"/> object representing the intersection
        /// between two <see cref="Line2D"/> objects
        /// </summary>
        /// <param name="other"><see cref="Line2D"/> to test for intersection</param>
        /// <returns>Intersecting <see cref="Point2D"/></returns>
        public Point2D IntersectionWith(Line2D other)
        {
            if (this.IsParallelTo(other))
            {
                return null;
            }

            Vector2D d1 = this.Direction;
            Vector2D d2 = other.Direction;

            double cross = d1.Cross(d2);
            Vector2D delta = new Vector2D(this.Base, other.Base);

            double t1 = (delta.i * d2.j - delta.j * d2.i) / cross;

            return this.Base.DisplacedBy(d1, t1);
        }
    }
}
