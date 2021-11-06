using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanics.Geometry
{
    /// <summary>
    /// Defines an interval where the ends are excluded.
    /// </summary>
    public class OpenInterval
    {
        private double start;
        private double end;

        public OpenInterval(double start, double end)
        {
            if (start > end)
            {
                throw new ArgumentOutOfRangeException("Start of interval should be smaller than end.");
            }
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Start of the open interval.
        /// </summary>
        public double Start
        {
            get
            {
                return this.start;
            }
        }

        /// <summary>
        /// End of the open interval.
        /// </summary>
        public double End
        {
            get
            {
                return this.end;
            }
        }

        /// <summary>
        /// Length of the open interval.
        /// </summary>
        public double Length
        {
            get
            {
                return End - Start;
            }
        }

        /// <summary>
        /// Checks if <see cref="OpenInterval"/> contains a given value.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if value is in interval</returns>
        public bool Contains(double value)
        {
            return Start < value && value < End;
        }

        /// <summary>
        /// Tests if a give <see cref="OpenInterval"/> overlaps with this interval.
        /// </summary>
        /// <param name="other">Interval to test</param>
        /// <returns>True if intervals overlap</returns>
        public bool Overlaps(OpenInterval other)
        {
            if (DoubleCompare.AreEqual(Start, other.Start) && DoubleCompare.AreEqual(End, other.End))
            {
                return true;
            }

            return Contains(other.Start) ||
                Contains(other.End) ||
                other.Contains(Start) ||
                other.Contains(End);
        }

        /// <summary>
        /// Returns range of overlap between two <see cref="OpenInterval"/> objects.
        /// </summary>
        /// <param name="other">Overlapping interval</param>
        /// <returns><see cref="OpenInterval"/> representing overlapping interval</returns>
        public OpenInterval GetOverlap(OpenInterval other)
        {
            if (!Overlaps(other))
            {
                return null;
            }

            return new OpenInterval(Math.Max(Start, other.Start), Math.Min(End, other.End));
        }
    }
}
