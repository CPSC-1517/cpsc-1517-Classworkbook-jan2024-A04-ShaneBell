using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenoSystem
{
    public static class Utilities
    {
        public static bool IsZeroPositive(int value)
        {
            bool valid = true;

            if (value < 0)
            {
                valid = false;
            }

            return valid;
        }

        public static bool IsNonZeroPositive(int value)
        {
            bool valid = true;

            if (value <= 0)
            {
                valid = false;
            }

            return valid;
        }

        public static bool IsValidMinimum(int value1, int value2)
        {
            bool valid = false;

            if (value1 >= value2)
            {
                valid = true;
            }

            return valid;
        }
    }
}
