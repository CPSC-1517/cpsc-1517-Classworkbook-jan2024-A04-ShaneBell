namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 1, 3, 4, 4, 5, 7, 8, 8, 10, 11, 14 };
            Console.WriteLine("NO LINQ");
            foreach (int i in list)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Ya LINQ");
            foreach(int anumber in list.Where(num => num % 2 == 0))
            {
                Console.WriteLine(anumber);
            }
            

        }
    }
}