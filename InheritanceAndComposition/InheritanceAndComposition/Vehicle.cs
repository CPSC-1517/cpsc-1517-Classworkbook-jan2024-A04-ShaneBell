namespace InheritanceAndComposition
{
    public class Vehicle
    {
        public short Year { get; set; }
        public string Make { get; set; }
        public double Speed { get; set; }
        public Engine Engine { get; set; }
            
        public void Accelerate(double amount)
        {
            Speed += amount;
        
        }
        //we always want our vehicle to have an engine
        public Vehicle (Engine engine)
        {
            Engine = engine;
        }
        public Vehicle()
        {
            Engine = new Engine();
            
        }


    }
}