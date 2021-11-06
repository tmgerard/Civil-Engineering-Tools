using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mechanics.Geometry;

namespace Mechanics.Geometry.Shapes.Tests
{
    [TestClass()]
    public class TestCircle
    {
        Circle circle = new Circle(10, new Point2D(10, 10));

        [TestMethod()]
        public void TestArea()
        {
            double expected = Math.PI * 10 * 10;
            Assert.AreEqual(expected, circle.Area(), 1e-5);
        }

        [TestMethod()]
        public void TestCircumference()
        {
            double expected = 2 * Math.PI * 10;
            Assert.AreEqual(expected, circle.Circumference(), 1e-5);
        }

        [TestMethod()]
        public void TestContainsPoint()
        {
            Point2D point = new Point2D(11, 12);
            Assert.IsTrue(circle.ContainsPoint(point));
        }

        [TestMethod()]
        public void TestDoesNotContainPoint()
        {
            Point2D point = new Point2D(100, 100);
            Assert.IsFalse(circle.ContainsPoint(point));
        }

        [TestMethod()]
        public void TestToPolygon()
        {
            Circle polyCircle = new Circle(10, new Point2D(2, 5));
            const int divisions = 4;
            Polygon actual = polyCircle.ToPolygon(divisions);
            
            List<Point2D> vertices = new List<Point2D>
            {
                new Point2D(12, 5),
                new Point2D(2, 15),
                new Point2D(-8, 5),
                new Point2D(2, -5)
            };
            Polygon expected = new Polygon(vertices);

            Assert.AreEqual(expected, actual);
        }
    }
}