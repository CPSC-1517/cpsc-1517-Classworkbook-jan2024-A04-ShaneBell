using System.Reflection.Metadata.Ecma335;

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

        //Properties
        // allow acccess to our fields (public)
        //can validate
        //must have a get
        //set can be private (only code in the class can use it)

        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set
            {
                //empty string BAD
                //Space BAD
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Birth Place cannot be empty!");
                }
                _birthPlace = value;
            }
        }

        
        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new Exception("Cannot be born in the future!");
                }
                _dateOfBirth = value;
            }
        }
        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //    set
        //    {
        //        _firstName = value;
        //    }
        //}

        //public string FirstName { get; set; }
        //auto implemented property
        //Creates a backing field to store the Position
        //prop tab tab
        public Position Position { get; set; }
        public Shot Shot { get; set; }


    //TODO: complete the remaing properties for the fields
    //strings must not be null,empty,whitespace
    //weight and height must be >=0



    }
}
