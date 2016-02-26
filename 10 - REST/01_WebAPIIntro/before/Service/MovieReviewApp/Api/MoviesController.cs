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

        // TODO: implement the 2 'GET' methods. The first should return
        // a collection of movies. The second should return an 
        // individual movie based upon the movie's ID.
        // 
        // Use the MovieService object (via the "service" member variable 
        // declared above).

    }
}
