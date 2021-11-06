using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry.Shapes
{
    /// <summary>
    /// Reprsents a circle with a given radius.
    /// </summary>
    public class Circle
    {
        private Point2D center;
        private double radius;

        public Circle(double radius)
        {
            CheckRadius(radius);
            this.radius = radius;
            center = new Point2D(0, 0);
        }

        public Circle(double radius, Point2D center)
        {
            CheckRadius(radius);
            this.radius = radius;
            this.center = center;
        }

        private void CheckRadius(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must be positive.");
            }
        }

        private void CheckDiameter(double diameter)
        {
            if (diameter <= 0)
            {
                throw new ArgumentOutOfRangeException("Diameter must be positive.");
            }
        }

        /// <summary>
        /// Diameter of the <see cref="Circle"/>.
        /// </summary>
        public double Diamter
        {
            get => this.radius * 2;
            set
            {
                CheckDiameter(value);
                this.radius = value / 2.0;
            }
        }

        /// <summary>
        /// Radius of the <see cref="Circle"/>.
        /// </summary>
        public double Radius
        {
            get => this.radius;
            set
            {
                CheckRadius(value);
                this.radius = value;
            }
        }

        /// <summary>
        /// Location of the center of the <see cref="Circle"/>.
        /// </summary>
        public Point2D Origin { get; set; }

        /// <summary>
        /// Calculates the area of the <see cref="Circle"/>.
        /// </summary>
        /// <returns>Area</returns>
        public double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        /// <summary>
        /// Returns the length around the <see cref="Circle"/>'s perimeter.
        /// </summary>
        /// <returns>Circumference</returns>
        public double Circumference()
        {
            return 2 * Math.PI * radius;
        }

        /// <summary>
        /// Checks if a give <see cref="Point2D"/> lies within the <see cref="Circle"/>.
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <returns>True if point is in the circle</returns>
        public bool ContainsPoint(Point2D point)
        {
            return point.DistanceTo(center) < radius;
        }

        /// <summary>
        /// Returns <see cref="Polygon"/> that approximates the <see cref="Circle"/> using
        /// the given amount of divisions.
        /// </summary>
        /// <param name="divisions">Number of divisions</param>
        /// <returns>Polygon approximation of circle</returns>
        public Polygon ToPolygon(int divisions = 50)
        {
            double angleDelta = 2 * Math.PI / divisions;

            List<Point2D> vertices = new List<Point2D>();
            for (int i = 0; i < divisions - 1; i++)
            {
                vertices.Add(PointAtAngle(angleDelta * i));
            }

            return new Polygon(vertices);
        }

        private Point2D PointAtAngle(double angle)
        {
            return new Point2D(center.x + radius * Math.Cos(angle), center.y + radius * Math.Sin(angle));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Circle);
        }

        public bool Equals(Circle other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Origin == other.Origin && DoubleCompare.AreEqual(Radius, other.Radius);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(center, radius, Diamter, Radius, Origin);
        }
    }
}
