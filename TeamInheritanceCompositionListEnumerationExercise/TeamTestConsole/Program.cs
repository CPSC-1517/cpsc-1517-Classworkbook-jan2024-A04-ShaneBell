using TeamInheritanceCompositionListEnumerationExercise;
namespace TeamTestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Team team1= new Team();
            team1.TeamName = "Oilers";
            team1.AddPlayer("Shane", "Bell", 42);
            List<int> list= new List<int>();

            list.Add(1);
            list.Add(2);

        }
    }
}