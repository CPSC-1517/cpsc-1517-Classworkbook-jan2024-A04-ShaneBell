using TeamInheritanceCompositionListEnumerationExercise;
namespace TeamTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team1 = new Team();
            team1.TeamName = "Oilers";
            team1.AddPlayer("Shane", "Bell", 42);

            FootballTeam team2 = new FootballTeam
            {
                HomeStadium = "Commonwealth statium",
                TotalFieldGoals = 50,
                TotalTouchDowns = 20,
                City = "Edmonton",
                Season = Season.Summer,
                TeamName = "Ooks"
            };


            team2.AddPlayer("Homer", "Simpson", 42);
            team2.AddPlayer("Maggie", "Simpson", 43);
            team2.AddPlayer("Bart", "Simpson", 44);

            Console.WriteLine(team2.ToString());

            foreach (Player aPlayer in team2.PlayerList)
            {
                Console.WriteLine(aPlayer.ToString());
            }



        }
    }
}