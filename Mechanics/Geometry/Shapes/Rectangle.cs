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
    }
}
