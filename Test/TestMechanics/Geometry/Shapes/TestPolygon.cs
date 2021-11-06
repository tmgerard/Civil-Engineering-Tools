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
    public class TestPolygon
    {
        private List<Point2D> polyPoints = new List<Point2D>()
        {
            new Point2D(0, 0),
            new Point2D(5, 0),
            new Point2D(5, 5),
            new Point2D(0, 0)
        };

        private List<Point2D> notClosedPolyPoints = new List<Point2D>()
        {
            new Point2D(0, 0),
            new Point2D(5, 0),
            new Point2D(5, 5)
        };

        private List<Point2D> centroidPolyPoints = new List<Point2D>()
        {
            new Point2D(0, 0),
            new Point2D(2.5, 0),
            new Point2D(5, 3)
        };

        private List<Point2D> closedCentroidPolyPoints = new List<Point2D>()
        {
            new Point2D(0, 0),
            new Point2D(2.5, 0),
            new Point2D(5, 3)
        };

        private Polygon shape;

        [TestMethod()]
        public void TestAreaVerticesClosed()
        {
            double expected = 12.5;
            shape = new Polygon(polyPoints);

            Assert.AreEqual(expected, shape.Area());
        }

        [TestMethod()]
        public void TestAreaVerticesNotClosed()
        {
            double expected = 12.5;
            shape = new Polygon(notClosedPolyPoints);

            Assert.AreEqual(expected, shape.Area());
        }

        [TestMethod()]
        public void TestCentroidVerticesNotClosed()
        {
            Point2D expected = new Point2D(2.5, 1);
            shape = new Polygon(centroidPolyPoints);

            Assert.AreEqual(expected, shape.Centroid());
        }

        [TestMethod()]
        public void TestCentroidVerticesClosed()
        {
            Point2D expected = new Point2D(2.5, 1);
            shape = new Polygon(closedCentroidPolyPoints);

            Assert.AreEqual(expected, shape.Centroid());
        }
    }
}