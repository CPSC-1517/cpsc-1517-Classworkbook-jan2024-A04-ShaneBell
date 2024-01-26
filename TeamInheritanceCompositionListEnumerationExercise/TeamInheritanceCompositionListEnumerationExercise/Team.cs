using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TeamInheritanceCompositionListEnumerationExercise
{
    public class Team
    {
        public int NumberOfPlayers { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public Season Season { get; set; }
        //You need to create a list before adding to it. So you must instantiate with new() and assign to the property first. Then you can add to the list.
        public List<Player> PlayerList { get; set; } = new();

        public void AddPlayer (string firstName, string lastName, int jerseyNumber)
        {
            //add a player to the player list
            PlayerList.Add(new Player(firstName, lastName, jerseyNumber));
            //increment player count
            NumberOfPlayers++;
        }

    }
}
