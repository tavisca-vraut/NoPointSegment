using System;

namespace NoPointSegment
{
    class Program
    {
        public string Intersection(int[] seg1, int[] seg2)
        {
            Segment segmentA = new Segment(seg1);
            Segment segmentB = new Segment(seg2);

            if (Geometry.CheckPerpendicularIntersection(segmentA, segmentB) == true)
                return "POINT";

            if (Geometry.CheckParallelSegmentsIntersection(segmentA, segmentB, out bool PointIntersection) == true)
            {
                if (PointIntersection)
                    return "POINT";
                return "SEGMENT";
            }

            return "NO";
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            string input = Console.ReadLine();
            Program solver = new Program();
            do
            {
                var segments = input.Split('|');
                var segParts = segments[0].Split(',');
                var seg1 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                segParts = segments[1].Split(',');
                var seg2 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                Console.WriteLine(solver.Intersection(seg1, seg2));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
