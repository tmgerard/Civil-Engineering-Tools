using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mechanics.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mechanics.Geometry;

namespace Mechanics.Geometry.Tests
{
    [TestClass()]
    public class TestAffineTransform2D
    {
        Point2D point = new Point2D(2, 3);
        AffineTransform2D scale = new AffineTransform2D(2, 5, 0, 0, 0, 0);
        AffineTransform2D translate = new AffineTransform2D(1, 1, 10, 15, 0, 0);
        AffineTransform2D shear = new AffineTransform2D(1, 1, 0, 0, 3, 4);

        [TestMethod()]
        public void TestScalePoint()
        {
            Point2D expected = new Point2D(4, 15);
            Point2D actual = scale.Transform(point);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestTranslatePoint()
        {
            Point2D expected = new Point2D(12, 18);
            Point2D actual = translate.Transform(point);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestShearPoint()
        {
            Point2D expected = new Point2D(11, 11);
            Point2D actual = shear.Transform(point);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestConcatenateScaleThenTranslate()
        {
            AffineTransform2D expected = new AffineTransform2D(2, 5, 10, 15, 0, 0);
            AffineTransform2D actual = scale.Concatenate(translate);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestConcatenateTranslateThenScale()
        {
            AffineTransform2D expected = new AffineTransform2D(2, 5, 20, 75, 0, 0);
            AffineTransform2D actual = translate.Concatenate(scale);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestInverse()
        {
            AffineTransform2D expected = new AffineTransform2D();
            AffineTransform2D actual = translate.Concatenate(translate.Inverse());
            Assert.AreEqual(expected, actual);
        }
    }
}