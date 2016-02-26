using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewApp.Service
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public int YearReleased { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}