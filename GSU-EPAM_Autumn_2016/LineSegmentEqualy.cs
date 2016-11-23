using System.Collections.Generic;

namespace GSU_EPAM_Autumn_2016
{
    /// <summary>
    /// Class for work with Distinct() in list by LengthLineSegment
    /// </summary>
    class LineSegmentEqualy : IEqualityComparer<LineSegment>
    {
        public bool Equals(LineSegment x, LineSegment y)
        {
            return x.LengthLineSegment == y.LengthLineSegment;
        }

        public int GetHashCode(LineSegment obj)
        {
            return obj.LengthLineSegment.GetHashCode();
        }
    }
}
