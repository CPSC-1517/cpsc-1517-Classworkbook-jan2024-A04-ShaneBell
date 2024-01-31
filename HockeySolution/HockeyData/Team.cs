using Hockey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyData
{
    public class Team
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public Role  Role { get; set; }

        public Team (string teamName, string city, Role role)
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
            return new Team(parts[0], parts[1], (Role)Enum.Parse(typeof(Role),parts[2]));
        }
    }
}
