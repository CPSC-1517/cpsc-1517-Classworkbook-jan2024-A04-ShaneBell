using Hockey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Data
{
    public class Team
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public Role Role { get; set; }

        public Team(string teamName, string city, Role role)
        {
            TeamName = teamName;
            City = city;
            Role = role;
        }
        public override string ToString()
        {
            return $"{TeamName},{City},{Role}";
        }

        public static Team Parse(string values)
        {
            //values will be a csv file
            //Create an array of strings using .Split(,)
            //split the seperate pieces of data that are in values into an array
            string[] parts = values.Split(',');
            //return a new Team object from the CSV string
            return new Team(parts[0], parts[1], (Role)Enum.Parse(typeof(Role), parts[2]));
        }

        public static bool TryParse(string value, out Team parsedResult)
        {
            bool valid = false;

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("String to parse is empty");
            }
            parsedResult = Parse(value);
            valid = true;

            return valid;
        }



    }
}
