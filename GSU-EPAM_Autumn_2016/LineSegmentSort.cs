using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Comparer for sort list by  Length LineSegment
    /// </summary>
    public class LineSegmentSort : IComparer<LineSegment>
    {
        public int Compare(LineSegment x, LineSegment y)
        {
            return x.LengthLineSegment.CompareTo(y.LengthLineSegment);
        }
    }
}
