using ValidationUtilities;

namespace ClassReview
{
    public class Movie
    {
        private string _title;
        private string _studio;
        private double _budget;
        private int _crewCount;
        public Genre Genre { get; set; }
        public Rating Rating { get; set; }

        public Movie()
        {
            _title = string.Empty;
            _studio = string.Empty;
            _budget = 0;
            Genre = Genre.Unknown;
            Rating = Rating.Unknown;
        }
        public Movie(string title, string studio, double budget, int crewCount, Genre genre, Rating rating)
        {
            Title = title;
            Studio = studio;
            Budget = budget;
            CrewCount = crewCount;
            Genre = genre;
            Rating = rating;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("Title cannot be empty!");
                }
                _title = value;
            }
        }
        public string Studio
        {
            get
            {
                return _studio;
            }
            set
            {
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("Studio cannot be empty!");
                }
                _studio = value;
            }
        }
        public double Budget
        {
            get
            {
                return _budget;
            }
            set
            {
                if (Utilities.IsLessThanZero(value))
                {
                    throw new Exception("Budget cannot be less than zero!");
                }
                _budget = value;
            }
        }
        public int CrewCount
        {
            get
            {
                return _crewCount;
            }
            set
            {
                if (Utilities.IsLessThanZero(value))
                {
                    throw new Exception("Crew Count cannot be less than zero!");
                }
                _crewCount = value;
            }
        }


        public override string ToString()
        {
            return $"{Title} cost {Budget:C} and had a crew count of {CrewCount}";
        }








    }
}