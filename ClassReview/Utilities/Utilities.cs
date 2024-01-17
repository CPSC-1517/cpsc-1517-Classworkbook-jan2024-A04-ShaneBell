namespace ValidationUtilities
{
    public static class Utilities
    {
        public static bool IsNullOrEmptyOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        
        public static bool IsLessThanZero(int value)
        {
            return value < 0;
        }
        public static bool IsLessThanZero(double value)
        {
            return value < 0;
        }

    }
}