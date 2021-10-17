using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry;
using System;

namespace TestMechanics.Geometry
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
    }
}
