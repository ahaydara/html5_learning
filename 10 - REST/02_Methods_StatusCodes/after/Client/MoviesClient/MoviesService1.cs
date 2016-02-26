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
    public class MoviesService1
    {
        const string baseUrl = "http://localhost:2100/api/movies1/";
        
        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(baseUrl);
            return task.ContinueWith<IEnumerable<Movie>>(innerTask =>
            {
                var json = innerTask.Result;
                return JsonConvert.DeserializeObject<Movie[]>(json);
            });
        }

        public Task<MovieResponse> GetAsync(int id)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(baseUrl + id);
            return task.ContinueWith<MovieResponse>(innerTask =>
            {
                var json = innerTask.Result;
                var movie = JsonConvert.DeserializeObject<Movie>(json);
                return new MovieResponse { Movie = movie };
            });
        }

        public Task<MovieResponse> PostAsync(Movie movie)
        {
            var client = new HttpClient();
            var task = client.PostAsJsonAsync<Movie>(baseUrl, movie);
            return task.ContinueWith<MovieResponse>(
                innerTask =>
                {
                    if (!task.Result.IsSuccessStatusCode)
                    {
                        return new MovieResponse { Error = task.Result.ReasonPhrase };
                    }
                    return new MovieResponse();
                });
        }

        public Task<MovieResponse> PutAsync(Movie movie)
        {
            var client = new HttpClient();
            var task = client.PutAsJsonAsync<Movie>(baseUrl + movie.ID, movie);
            return task.ContinueWith<MovieResponse>(
                innerTask =>
                {
                    if (!task.Result.IsSuccessStatusCode)
                    {
                        return new MovieResponse { Error = task.Result.ReasonPhrase };
                    }
                    return new MovieResponse();
                });
        }

        public Task<MovieResponse> DeleteAsync(int id)
        {
            var client = new HttpClient();
            var task = client.DeleteAsync(baseUrl + id);
            return task.ContinueWith<MovieResponse>(
                innerTask =>
                {
                    if (!task.Result.IsSuccessStatusCode)
                    {
                        return new MovieResponse { Error = task.Result.ReasonPhrase };
                    }
                    return new MovieResponse();
                });
        }
    }
}
