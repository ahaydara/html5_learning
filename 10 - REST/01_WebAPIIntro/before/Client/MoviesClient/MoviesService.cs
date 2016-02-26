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

        public Task<Movie> GetAsync(int id)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(baseUrl + id);
            return task.ContinueWith<Movie>(innerTask =>
            {
                var json = innerTask.Result;
                return JsonConvert.DeserializeObject<Movie>(json);
            });
        }
    }
}
