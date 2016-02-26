using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesClient
{
    public class Movie
    {
        public Movie()
        {
        }

        public Movie(Movie other)
        {
            this.ID = other.ID;
            this.Title = other.Title;
            this.Rating = other.Rating;
            this.YearReleased = other.YearReleased;
            this.Description = other.Description;
            this.Director = other.Director;
            this.Country = other.Country;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public int YearReleased { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
    }
}
