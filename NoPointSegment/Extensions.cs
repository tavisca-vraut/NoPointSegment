namespace NoPointSegment
{
    public static class Extensions
    {
        // 'this' keyword was not allowed with ref in the CODEJAM C#'s version. So, just using static methods.
        public static bool InRange(this int test, int rangeStart, int rangeEnd)
        {
            if (rangeStart <= test && test <= rangeEnd)
                return true;

            return false;
        }

        public static void SwapWith(this ref int number1, ref int number2)
        {
            var temp = number1;
            number1 = number2;
            number2 = temp;
        }

        public static void SwapWith(this ref char character1, ref char character2)
        {
            var temp = character1;
            character1 = character2;
            character2 = temp;
        }
    }
}