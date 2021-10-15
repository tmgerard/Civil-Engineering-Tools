using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry.Tests
{
    [TestClass()]
    public class TestLine2D
    {
        private Line2D line1 = new Line2D(new Point2D(0, 0), new Vector2D(1, 1));
        private Line2D line2 = new Line2D(new Point2D(10, 10), new Vector2D(1, 1));
        private Line2D line3 = new Line2D(new Point2D(50, 0), new Vector2D(0, 1));
        private Line2D line4 = new Line2D(new Point2D(0, 30), new Vector2D(1, 0));

        [TestMethod()]
        public void TestIsParallelTo()
        {
            Assert.IsTrue(line1.IsParallelTo(line2));
        }

        [TestMethod()]
        public void TestIsParallelToNonParallelLines()
        {
            Assert.IsFalse(line1.IsParallelTo(line3));
        }

        [TestMethod()]
        public void TestIsPerpendicularTo()
        {
            Assert.IsTrue(line1.IsPerpendicularTo(new Line2D(line1.Base, line1.Direction.Perpendicular())));
        }

        [TestMethod()]
        public void TestIntersectionWith()
        {
            Point2D expected = new Point2D(50, 30);
            Point2D actual = line3.IntersectionWith(line4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestIntersectionWithNoIntersection()
        {
            Assert.IsNull(line1.IntersectionWith(line2));
        }
    }
}