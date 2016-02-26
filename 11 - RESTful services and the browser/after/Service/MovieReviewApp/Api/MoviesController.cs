using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using MovieReviewApp.Service;

namespace MovieReviewApp.Api
{
    [ModelStateFilter]
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

        public HttpResponseMessage Get(int id)
        {
            var movie = service.Find(id);
            if (movie == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.OK, movie);
        }

        public HttpResponseMessage Post(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var newMovie = service.Create(movie);
                var response = Request.CreateResponse(HttpStatusCode.Created, newMovie);
                var url = Url.Link("DefaultApi", new { id = newMovie.ID });
                var uri = new Uri(url);
                response.Headers.Location = uri;
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public HttpResponseMessage Put(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.ID = id;
                if (!service.Update(movie)) return Request.CreateResponse(HttpStatusCode.NotFound);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public HttpResponseMessage Delete(int id)
        {
            if (!service.Delete(id)) return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
