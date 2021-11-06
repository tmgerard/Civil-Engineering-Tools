using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry.Shapes
{
    /// <summary>
    /// Class that defines a two-dimensional rectangle.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Constructs <see cref="Rectangle"/> with a given width and height and a default
        /// origin at point (0, 0).
        /// </summary>
        /// <param name="width">Width of <see cref="Rectangle"/></param>
        /// <param name="height">Height of <see cref="Rectangle"/></param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.Origin = new Point2D(0, 0);
        }

        /// <summary>
        /// Constructs <see cref="Rectangle"/> with a given width, height, and origin point.
        /// </summary>
        /// <param name="width">Width of <see cref="Rectangle"/></param>
        /// <param name="height">Height of <see cref="Rectangle"/></param>
        /// <param name="origin">Coordinates of bottom left edge of <see cref="Rectangle"/></param>
        public Rectangle(double width, double height, Point2D origin)
        {
            this.Width = width;
            this.Height = height;
            this.Origin = origin;
        }

        /// <summary>
        /// Width of the <see cref="Rectangle"/> object.
        /// </summary>
        public double Width
        {
            get
            {
                return this.Width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle width must be positive");
                }
                this.Width = value;
            }
        }

        /// <summary>
        /// Height of the <see cref="Rectangle"/> object.
        /// </summary>
        public double Height
        {
            get
            {
                return this.Height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle height must be positive");
                }
                this.Height = value;
            }
        }

        /// <summary>
        /// <see cref="Point2D"/> object that defines the location of the bottom left
        /// corner of the <see cref="Rectangle"/> object.
        /// </summary>
        public Point2D Origin { get; set; }

        /// <summary>
        /// Left edge position of <see cref="Rectangle"/> object
        /// </summary>
        public double Left => Origin.x;

        /// <summary>
        /// Right edge position of <see cref="Rectangle"/> object
        /// </summary>
        public double Right => Origin.x + Width;

        /// <summary>
        /// Bottom edge position of <see cref="Rectangle"/> object
        /// </summary>
        public double Bottom => Origin.y;

        /// <summary>
        /// Top edge position of of <see cref="Rectangle"/> object
        /// </summary>
        public double Top => Origin.y + Height;

        /// <summary>
        /// Area of <see cref="Rectangle"/>
        /// </summary>
        /// <returns>Rectangle area</returns>
        public double Area()
        {
            return Width * Height;
        }

        /// <summary>
        /// Total length of the <see cref="Rectangle"/>'s sides.
        /// </summary>
        /// <returns>Rectangle perimeter</returns>
        public double Perimeter()
        {
            return 2 * (Height + Width);
        }

        /// <summary>
        /// Checks if a given <see cref="Point2D"/> lies within the <see cref="Rectangle"/>
        /// </summary>
        /// <param name="point"><see cref="Point2D"/> object</param>
        /// <returns>True if <see cref="Point2D"/> object lies within <see cref="Rectangle"/></returns>
        public bool ContainsPoint(Point2D point)
        {
            return Left < point.x && point.x < Right && Bottom < point.y && point.y < Top;
        }

        /// <summary>
        /// Computes <see cref="Rectangle"/> intersection between two <see cref="Rectangle"/> objects.
        /// </summary>
        /// <param name="other">Intersecting rectangle</param>
        /// <returns><see cref="Rectangle"/> or null</returns>
        public Rectangle IntersectionWith(Rectangle other)
        {
            OpenInterval hOverlap = HorizontalOverlapWith(other);
            OpenInterval vOverlap = VerticalOverlapWith(other);
            if (hOverlap is null || vOverlap is null)
            {
                return null;
            }

            return new Rectangle(hOverlap.Length, vOverlap.Length, new Point2D(hOverlap.Start, vOverlap.Start));
        }

        private OpenInterval HorizontalOverlapWith(Rectangle other)
        {
            OpenInterval selfInterval = new OpenInterval(Left, Right);
            OpenInterval otherInterval = new OpenInterval(other.Left, other.Right);

            return selfInterval.GetOverlap(otherInterval);
        }

        private OpenInterval VerticalOverlapWith(Rectangle other)
        {
            OpenInterval selfInterval = new OpenInterval(Bottom, Top);
            OpenInterval otherInterval = new OpenInterval(other.Bottom, other.Top);

            return selfInterval.GetOverlap(otherInterval);
        }

        /// <summary>
        /// Creates <see cref="Polygon"/> equivalent of <see cref="Rectangle"/> object.
        /// </summary>
        /// <returns><see cref="Polygon"/> object</returns>
        public Polygon ToPolygon()
        {
            List<Point2D> vertices = new List<Point2D>()
            {
                Origin,
                new Point2D(Right, Bottom),
                new Point2D(Right, Top),
                new Point2D(Left, Top)
            };

            return new Polygon(vertices);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Rectangle);
        }

        public bool Equals(Rectangle other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Origin == other.Origin && Width == other.Width && Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height, Origin, Left, Right, Bottom, Top);
        }
    }
}
