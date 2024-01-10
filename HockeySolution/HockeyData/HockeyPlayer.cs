 namespace Hockey.Data
{
    public class HockeyPlayer
    {
        //Data fields
        //store the data in the object
        //prefix _ for private fields
        //camel case
        //The green squiggles are saying they are strings and therefore not nullable
        //can use ? after string to allow nulls
        //This can also be managed in the constructor
        private string? _birthPlace;
        private string? _firstName;
        private string? _lastName;
        private int _heightInInches;
        private int _weightInPounds;
        private DateOnly _dateOfBirth;
        private Position _position;



    }
}
