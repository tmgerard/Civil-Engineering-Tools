using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry;
using System;

namespace Mechanics.Geometry.Tests
{
    [TestClass]
    public class TestSegment2D
    {
        Point2D start = new Point2D(400, 0);
        Point2D end = new Point2D(0, 400);
        Segment2D segment;
        
        [TestInitialize]
        public void TestInit()
        {
            segment = new Segment2D(start, end);
        }

        [TestMethod]
        public void TestLength()
        {
            double expected = Math.Sqrt(Math.Pow(400, 2) + Math.Pow(400, 2));
            double actual = segment.Length();
            Assert.AreEqual(expected, actual, 0.00001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestPointAtBadRatio()
        {
            segment.PointAt(100);
        }

        [TestMethod]
        public void TestPointAt()
        {
            Point2D expected = new Point2D(300, 100);
            Point2D actual = segment.PointAt(0.25);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClosestPointIsStart()
        {
            Point2D point = new Point2D(500, 10);
            Point2D expected = start;
            Point2D actual = segment.ClosestPointTo(point);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClosestPointIsEnd()
        {
            Point2D point = new Point2D(10, 500);
            Point2D expected = end;
            Point2D actual = segment.ClosestPointTo(point);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClosestPointIsMiddle()
        {
            Point2D point = new Point2D(250, 250);
            Point2D expected = new Point2D(200, 200);
            Point2D actual = segment.ClosestPointTo(point);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParallelNoIntersection()
        {
            Segment2D other = new Segment2D(new Point2D(200, 0), new Point2D(0, 200));
            Point2D actual = segment.IntersectionWith(other);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void TestIntersection()
        {
            Segment2D other = new Segment2D(new Point2D(0, 0), new Point2D(400, 400));
            Point2D expected = new Point2D(200, 200);
            Point2D actual = segment.IntersectionWith(other);
            Assert.AreEqual(expected, actual);
        }
    }
}
