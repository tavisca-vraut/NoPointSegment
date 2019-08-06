namespace NoPointSegment
{
    public class Point
    {
        public int X;
        public int Y;

        public int Get(char coordinate)
        {
            if (coordinate == 'X')
                return this.X;

            return this.Y;
        }
    }
}