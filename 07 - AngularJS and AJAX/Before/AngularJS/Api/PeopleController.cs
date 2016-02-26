using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJS.Models;

namespace AngularJS.Api
{
    public class PeopleController : ApiController
    {
        private readonly IPeopleRepository _repo = new PeopleRepository();

        // GET api/Peoples
        public IEnumerable<Person> Get()
        {
            return _repo.Get();
        }

        // GET api/Peoples/5
        public HttpResponseMessage Get(int id)
        {
            var person = _repo.Get(id);

            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        // POST api/Peoples
        public HttpResponseMessage Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var newPeople = _repo.Add(person);
            var response = Request.CreateResponse(HttpStatusCode.Created, newPeople);
            var uriString = Url.Link("DefaultApi", new { id = newPeople.Id }) ?? string.Empty;
            response.Headers.Location = new Uri(uriString);

            return response;
        }

        // PUT api/Peoples/5
        public HttpResponseMessage Put(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var newPeople = _repo.Update(person);
            return Request.CreateResponse(HttpStatusCode.OK, newPeople);
        }

        // DELETE api/Peoples/5
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}