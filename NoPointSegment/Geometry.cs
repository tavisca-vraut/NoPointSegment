namespace NoPointSegment
{
    public static class Geometry
    {
        public  static bool IsParallelToXAxis(int x1, int x2)
        {
            if (x1 == x2)
                return false;

            return true;
        }

        public static bool CheckPerpendicularIntersection(Segment segment1, Segment segment2)
        {
            if (Segment.TwoSegmentsParallelToSameAxis(segment1, segment2) == true)
                return false;

            return Segment.ArePerpendicularSegmentsIntersecting(segment1, segment2);
        }

        public static bool CheckParallelSegmentsIntersection(Segment segment1, Segment segment2, out bool IsPointIntersection)
        {
            // If this function is entered, then the lines are parallel to the same axis

            bool segentsParallelToX = segment1.IsParallelToXAxis;
            IsPointIntersection = false;

            char checkCoordinate = 'X', otherCoordinate = 'Y';

            if (segentsParallelToX == false) checkCoordinate.SwapWith(ref otherCoordinate);

            if (Segment.AreParallelSegmentsOnSameLevel(segment1, segment2, otherCoordinate) == false)
                return false;

            return Segment.CheckIfSegmentsOverlap(segment1, segment2, ref IsPointIntersection, checkCoordinate);
        }
    }
}