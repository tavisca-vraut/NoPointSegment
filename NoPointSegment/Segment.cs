namespace NoPointSegment
{
    public class Segment
    {
        public Point LeftPoint;
        public Point RightPoint;

        public bool IsParallelToXAxis { get; set; } // If false, then parallel to Y axis

        public Segment(int[] segment)
        {
            var coordinate1 = new Point
            {
                X = segment[0],
                Y = segment[1]
            };
            var coordinate2 = new Point
            {
                X = segment[2],
                Y = segment[3]
            };

            DetermineParallelToWhichAxis(coordinate1, coordinate2);
            DetermineLeftAndRightPoint(coordinate1, coordinate2);
        }

        public void DetermineParallelToWhichAxis(Point coordinate1, Point coordinate2)
        {
            // If false, then parallel to Y axis
            IsParallelToXAxis = Geometry.IsParallelToXAxis(coordinate1.X, coordinate2.X);
        }

        private void DetermineLeftAndRightPoint(Point coordinate1, Point coordinate2)
        {
            // If false, then parallel to Y axis
            if (IsParallelToXAxis == true)
            {
                LeftPoint = coordinate1.X < coordinate2.X ? coordinate1 : coordinate2;
                RightPoint = coordinate1.X < coordinate2.X ? coordinate2 : coordinate1;
            }
            else
            {
                LeftPoint = coordinate1.Y < coordinate2.Y ? coordinate1 : coordinate2;
                RightPoint = coordinate1.Y < coordinate2.Y ? coordinate2 : coordinate1;
            }
        }

        public static bool ArePerpendicularSegmentsIntersecting(Segment segment1, Segment segment2)
        {
            var segmentParallelToX = segment1.IsParallelToXAxis == true ? segment1 : segment2;
            var segmentParallelToY = segment1.IsParallelToXAxis == false ? segment1 : segment2;

            return segmentParallelToY.LeftPoint.X.InRange(segmentParallelToX.LeftPoint.X,
                                      segmentParallelToX.RightPoint.X) &&
                   segmentParallelToX.LeftPoint.Y.InRange(segmentParallelToY.LeftPoint.Y,
                                      segmentParallelToY.RightPoint.Y);
        }

        public static bool CheckIfSegmentsOverlap(Segment segment1, Segment segment2, ref bool IsPointIntersection, char checkCoordinate)
        {
            Segment firstSegment = segment1.LeftPoint.Get(checkCoordinate) <= segment2.LeftPoint.Get(checkCoordinate) ? segment1 : segment2;
            Segment secondSegment = segment1.LeftPoint.Get(checkCoordinate) <= segment2.LeftPoint.Get(checkCoordinate) ? segment2 : segment1;

            if (secondSegment.LeftPoint.Get(checkCoordinate).InRange(firstSegment.LeftPoint.Get(checkCoordinate),
                                   firstSegment.RightPoint.Get(checkCoordinate)))
            {
                IsPointIntersection = firstSegment.RightPoint.Get(checkCoordinate) == secondSegment.LeftPoint.Get(checkCoordinate);
                return true;
            }

            return false;
        }

        public static bool TwoSegmentsParallelToSameAxis(Segment segment1, Segment segment2)
        {
            return segment1.IsParallelToXAxis == segment2.IsParallelToXAxis;
        }

        public static bool AreParallelSegmentsOnSameLevel(Segment segment1, Segment segment2, char axis)
        {
            return segment1.LeftPoint.Get(axis) == segment2.LeftPoint.Get(axis);
        }
    }
}