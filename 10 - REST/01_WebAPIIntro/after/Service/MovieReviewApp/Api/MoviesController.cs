using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using MovieReviewApp.Service;

namespace MovieReviewApp.Api
{
    public class MoviesController : ApiController
    {
        MovieService service;

        public MoviesController()
        {
            this.service = new MovieService();
        }
        
        public IEnumerable<Movie> Get()
        {
            return service.GetAllMovies();
        }

        public Movie Get(int id)
        {
            return service.Find(id);
        }
    }
}
