using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    public static class DoubleCompare
    {
        public const double CompareTolerance = 1e-10;
        public static bool AreEqual(double a, double b, double tolerance = CompareTolerance)
        {
            return Math.Abs(a - b) < tolerance;
        }

        public static bool IsEffectivelyZero(double a, double tolerance = CompareTolerance)
        {
            return AreEqual(a, 0.0, tolerance);
        }
    }
}
