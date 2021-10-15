using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry;

namespace Mechanics.Geometry.Tests
{
    [TestClass]
    public class TestPoint2D
    {
        Point2D pointOne = new Point2D(1, 2);
        Point2D pointTwo = new Point2D(2, 4);
        Vector2D displaceVec = new Vector2D(1, 1);

        [TestMethod]
        public void TestDisplacedBy()
        {
            Point2D expected = new Point2D(2, 3);
            Point2D actual = pointOne.DisplacedBy(displaceVec, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDistanceTo()
        {
            double expected = 2.2361;
            double actual = pointOne.DistanceTo(pointTwo);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void TestMinusOperator()
        {
            Vector2D expected = new Vector2D(1, 2);
            Vector2D actual = pointTwo - pointOne;
            Assert.AreEqual(expected, actual);
        }
    }
}
