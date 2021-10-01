using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry;
using System;

namespace TestMechanics.TestGeometry
{
    [TestClass]
    public class TestVector2D
    {
        Vector2D vec1 = new Vector2D(1, 2);
        Vector2D vec2 = new Vector2D(4, 6);

        Vector2D right = new Vector2D(1, 0);
        Vector2D left = new Vector2D(-1, 0);
        Vector2D up = new Vector2D(0, 1);
        Vector2D down = new Vector2D(0, -1);

        [TestMethod]
        public void TestPlus()
        {
            Vector2D expected = new Vector2D(5, 8);
            Vector2D actual = vec1 + vec2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMinus()
        {
            Vector2D expected = new Vector2D(-3, -4);
            Vector2D actual = vec1 - vec2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDotProduct()
        {
            double expected = 16;
            double actual = vec1.Dot(vec2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCrossProduct()
        {
            double expected = -2;
            double actual = vec1.Cross(vec2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParallel()
        {
            Assert.IsTrue(vec1.IsParalelTo(vec1));
        }

        [TestMethod]
        public void TestNotParallel()
        {
            Assert.IsFalse(vec1.IsParalelTo(vec2));
        }

        [TestMethod]
        public void TestPerpendicular()
        {
            Vector2D perp = new Vector2D(-2, 1);
            Assert.IsTrue(vec1.IsPerpendicularTo(perp));
        }

        [TestMethod]
        public void TestNotPerpendicular()
        {
            Assert.IsFalse(vec1.IsPerpendicularTo(vec2));
        }

        [TestMethod]
        public void TestAngleValueZero()
        {
            double expected = 0;
            double actual = right.AngleValueTo(right);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAngleValuePI()
        {
            double expected = Math.PI;
            double actual = right.AngleValueTo(left);
            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestMethod]
        public void TestAngleValueToPiOverTwo()
        {
            double expected = Math.PI / 2;
            double actual = right.AngleValueTo(up);
            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestMethod]
        public void TestAngleValueToNegativePiOverTwo()
        {
            double expected = Math.PI / 2;
            double actual = right.AngleValueTo(down);
            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestMethod]
        public void TestAngleToPiOverTwo()
        {
            double expected = Math.PI / 2;
            double actual = right.AngleTo(up);
            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestMethod]
        public void TestAngleToNegativePiOverTwo()
        {
            double expected = -Math.PI / 2;
            double actual = right.AngleTo(down);
            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestMethod]
        public void TestRotateZeroRadians()
        {
            Vector2D expected = right;
            Vector2D actual = right.Rotated(0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRotatePiOverTwoRadians()
        {
            Vector2D expected = up;
            Vector2D actual = right.Rotated(Math.PI / 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRotatePiRadians()
        {
            Vector2D expected = left;
            Vector2D actual = right.Rotated(Math.PI);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRotateMinusPiOverTwoRadians()
        {
            Vector2D expected = down;
            Vector2D actual = right.Rotated(-Math.PI / 2);
            Assert.AreEqual(expected, actual);
        }
    }
}
