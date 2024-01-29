namespace RenoSystem
{
    public static class Utilities
    {
        public static bool IsZeroPositive(int value)
        {
            //bool valid = true;

            //if (value < 0) 
            //{ 
            //    valid = false;
            //}
            return value >=0;
        }
        public static bool IsNonZeroPositive(int value)
        {            
            return value > 0;
        }

        public static bool IsValidMinimum(int value1,int value2) 
        {
            return value1 >= value2;
        }



    }
}