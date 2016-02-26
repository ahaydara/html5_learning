using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesClient
{
    public class MovieResponse
    {
        public Movie Movie { get; set; }
        public string Error { get; set; }
    }
}
