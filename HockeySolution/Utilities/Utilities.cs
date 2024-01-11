namespace ValidationUtilities
{
    public static class Utilities
    {
        //We will create a static class with static methods
        //This means we cannot instantiate the class BUT, we can still use the methods that are in the class.
        //Since we  have the same validation many times we will create a class library for them.
        public static bool IsNullOrEmptyOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        //Create Validate method to validate >=0
        //Use it in HockeyPlayer for Weight and Height Properties

        public static bool IsNegative(int value)
        {
            //bool result = false;
            //if (value < 0)
            //{
            //    result = true;
            //}
            //return result;
            //OR
            //return value < 0;
            //OR
            bool result;
            result = value < 0 ? true : false;
            return result;
        }

    }
}