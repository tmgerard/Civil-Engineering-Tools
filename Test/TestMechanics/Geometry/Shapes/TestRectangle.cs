using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Mechanics.Geometry;

namespace Mechanics.Geometry.Shapes.Tests
{
    [TestClass()]
    public class TestRectangle
    {
        double width = 10;
        double height = 5;
        Rectangle rectangle;

        [TestInitialize]
        public void TestInit()
        {
            rectangle = new Rectangle(width, height);
        }

        [TestMethod]
        public void TestArea()
        {
            double expected = 50;

            Assert.AreEqual(expected, rectangle.Area());
        }

        [TestMethod]
        public void TestPerimeter()
        {
            double expected = 30;

            Assert.AreEqual(expected, rectangle.Perimeter());
        }

        [TestMethod]
        public void TestDoesNotContainPoint()
        {
            Point2D point = new Point2D(50, 7);

            Assert.IsFalse(rectangle.ContainsPoint(point));
        }

        [TestMethod]
        public void TestContainsPoint()
        {
            Point2D point = new Point2D(5, 3);

            Assert.IsTrue(rectangle.ContainsPoint(point));
        }

        [TestMethod]
        public void TestIntersectionWith()
        {
            Rectangle other = new Rectangle(width, height, new Point2D(5, 2));
            Rectangle expected = new Rectangle(5, 3, other.Origin);

            Assert.AreEqual(expected, rectangle.IntersectionWith(other));
        }

        [TestMethod]
        public void TestNoIntersectionWithHorizontalOverlap()
        {
            Rectangle other = new Rectangle(width, height, new Point2D(0, 50));

            Assert.IsNull(rectangle.IntersectionWith(other));
        }

        [TestMethod]
        public void TestNoIntersectionWithVerticalOverlap()
        {
            Rectangle other = new Rectangle(width, height, new Point2D(50, 0));

            Assert.IsNull(rectangle.IntersectionWith(other));
        }

        [TestMethod]
        public void TestToPolygon()
        {
            List<Point2D> vertices = new List<Point2D>()
            {
                rectangle.Origin,
                new Point2D(10, 0),
                new Point2D(10, 5),
                new Point2D(0, 5)
            };

            Polygon expected = new Polygon(vertices);
            Polygon actual = rectangle.ToPolygon();

            Assert.AreEqual(expected, actual);
        }
    }
}