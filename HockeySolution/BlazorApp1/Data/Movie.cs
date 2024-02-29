namespace BlazorApp1.Data
{
    public class Movie
    {

        public string MovieName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public Movie (string movieName, string description,int rating)
        {
            MovieName = movieName;
            Description = description;
            Rating = rating;
        }
    }
}
