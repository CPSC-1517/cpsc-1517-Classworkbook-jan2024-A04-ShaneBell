using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndComposition
{
    //We want car to inherit from Vehicle
    public class Car:Vehicle
    {
        public bool AWD { get; set; }
        public string style { get; set; }

    }
}
