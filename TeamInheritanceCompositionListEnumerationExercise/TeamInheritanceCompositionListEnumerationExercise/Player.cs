using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamInheritanceCompositionListEnumerationExercise
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public Player(string firstName, string lastName, int jerseyNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            JerseyNumber = jerseyNumber;
        }
        public override string ToString()
        {
            return $"{FirstName}, {LastName},{JerseyNumber}";
        }
    }
}
