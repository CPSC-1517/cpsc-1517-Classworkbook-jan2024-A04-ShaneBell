using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamInheritanceCompositionListEnumerationExercise
{
    public class FootballTeam:Team
    {
        public string HomeStadium { get; set; }
        public int TotalFieldGoals { get; set; }
        public int TotalTouchDowns { get; set; }

        public override string ToString()
        {
            return $"{TeamName},{City},{NumberOfPlayers},{Season},{HomeStadium},{TotalFieldGoals},{TotalTouchDowns}"; 
        }
    }
}
