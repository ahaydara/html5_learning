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
    public class MoviesService2
    {
        const string baseUrl = "http://localhost:2100/api/movies2/";

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
            var task = client.GetAsync(baseUrl + id);
            return task.ContinueWith<MovieResponse>(innerTask =>
            {
                if (task.Result.IsSuccessStatusCode)
                {
                    var json = innerTask.Result.Content.ReadAsStringAsync().Result;
                    var movie = JsonConvert.DeserializeObject<Movie>(json);
                    return new MovieResponse
                    {
                        Movie = movie
                    };
                }
                else
                {
                    return new MovieResponse
                    {
                        Error = task.Result.ReasonPhrase
                    };
                }
            });
        }

        public Task<MovieResponse> PostAsync(Movie movie)
        {
            var client = new HttpClient();
            var task = client.PostAsJsonAsync<Movie>(baseUrl, movie);
            return task.ContinueWith<MovieResponse>(
                innerTask =>
                {
                    if (task.Result.IsSuccessStatusCode)
                    {
                        var json = innerTask.Result.Content.ReadAsStringAsync().Result;
                        var newMovie = JsonConvert.DeserializeObject<Movie>(json);
                        return new MovieResponse
                        {
                            Movie = newMovie
                        };
                    }
                    else
                    {
                        return new MovieResponse { Error = task.Result.ReasonPhrase };
                    }
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
