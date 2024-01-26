using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndComposition
{
    public class Engine
    {
        public int CylinderCount { get; set; }
        public int HorsePower { get; set; }
        public string Fuel { get; set; }

        public Engine(int cylinderCount, int horsePower, string fuel)
        {
            CylinderCount = cylinderCount;
            HorsePower = horsePower;
            Fuel = fuel;
        }
        public Engine()
        {
        }
    }
}
