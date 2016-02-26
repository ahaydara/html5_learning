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
            return service.GetAllMovies().ToArray();
        }

        public Movie Get(int id)
        {
            return service.Find(id);
        }

        // Part 1
        // TODO: provide implementations for POST, PUT and DELETE.

        
        // Part 2
        // TODO: issue the appropriate HTTP status code
        // for POST: issue a 201 and set Location header.
        // for GET, PUT and DELETE: issue 404 if appropriate.
        // for GET and PUT: issue 204 upon success.
    }
}
