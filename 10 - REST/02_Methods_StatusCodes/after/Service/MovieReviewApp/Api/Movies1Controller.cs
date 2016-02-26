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
    public class Movies1Controller : ApiController
    {
        MovieService service;

        public Movies1Controller()
        {
            this.service = new MovieService();
        }

        public IEnumerable<Movie> Get()
        {
            return service.GetAllMovies().ToArray();
        }

        public Movie Get(int id)
        {
            return service.Find(id);
        }

        public void Post(Movie movie)
        {
            service.Create(movie);
        }

        public void Put(int id, Movie movie)
        {
            service.Update(movie);
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
