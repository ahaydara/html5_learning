using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoviesClient
{
    public class MoviesService
    {
        const string baseUrl = "http://localhost:2100/api/movies/";
        
        // TODO: implement these methods to access the movie service.
        // 
        // Use HttpClient and the async programming model. 
        // use the various *Async methods to make the HTTP requests.
        // And then use ContinueWith<T> to process the results (available
        // via the Result property).
        //         
        // Use the IsSuccessStatusCode on the Result to know if the 
        // call was successful. The Result.ReasonPhrase contains the 
        // HTTP status text which is useful for repoting errors.
        // 
        // Use ReadAsStringAsync().Result to access the response body. 
        // To deseralize the JSON into a strongly typed object, use 
        // the JsonConvert.DeserializeObject API.

        
        // For the GetAllAsync, just access the response body and convert
        // the JSON to an array of Movie objects.
        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            var client = new HttpClient();

            // returning null to compile. replace with proper return 
            // value when you implement this method;
            return null;
        }

        // For the Get return a MovieResponse and populate the Movie property 
        // if it's a successful call, otherwise populate the 
        // Error property from Result.ReasonPhrase.
        public Task<MovieResponse> GetAsync(int id)
        {
            var client = new HttpClient();

            // returning null to compile. replace with proper return 
            // value when you implement this method;
            return null;
        }

        // For the Post return a MovieResponse and populate the Movie property 
        // if it's a successful call, otherwise populate the 
        // Error property from Result.ReasonPhrase.
        public Task<MovieResponse> PostAsync(Movie movie)
        {
            var client = new HttpClient();

            // returning null to compile. replace with proper return 
            // value when you implement this method;
            return null;
        }

        // For the Put there is no Movie result if it's a successful call
        // so just populate the MovieResponse.Error property from 
        // Result.ReasonPhrase if there's an error.
        public Task<MovieResponse> PutAsync(Movie movie)
        {
            var client = new HttpClient();

            // returning null to compile. replace with proper return 
            // value when you implement this method;
            return null;
        }

        // For the Delete there is no Movie result if it's a successful call
        // so just populate the MovieResponse.Error property from 
        // Result.ReasonPhrase if there's an error.
        public Task<MovieResponse> DeleteAsync(int id)
        {
            var client = new HttpClient();

            // returning null to compile. replace with proper return 
            // value when you implement this method;
            return null;
        }
    }
}
