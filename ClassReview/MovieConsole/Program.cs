using ClassReview;
namespace MovieConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie
            {
                Title = "Star Wars",
                Studio = "Disney",
                Budget = 200000.50,
                CrewCount = 1200
            };
            Console.WriteLine(movie1);
        }
    }
}