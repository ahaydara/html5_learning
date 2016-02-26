using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewApp.Service
{
    public class MovieService
    {
        MovieReviewApp.Models.MovieWebAppDBContext db = new Models.MovieWebAppDBContext();

        public IQueryable<Movie> GetAllMovies()
        {
            var query =
                from m in db.Movies
                    .Include("Director")
                    .Include("Country")
                    .Include("Genres")
                let genres = (from g in m.Genres select g.Name)
                select new Movie
                {
                    ID = m.ID,
                    Title = m.Title,
                    Rating = m.Rating,
                    YearReleased = m.Year,
                    Description = m.Description,
                    Director = m.Director.Name,
                    Country = m.Country.Name,
                    Genres = genres
                };
            return query;
        }

        public Movie Find(int id)
        {
            return this.GetAllMovies().SingleOrDefault(x => x.ID == id);
        }

        void Map(Movie movie, Models.Movie dbItem)
        {
            var director = db.Directors.FirstOrDefault(d => d.Name == movie.Director);
            var country = db.Countries.FirstOrDefault(c => c.Name == movie.Country);
            var genres = db.Genres.Where(g => movie.Genres.Contains(g.Name));

            dbItem.Title = movie.Title;
            dbItem.Description = movie.Description;
            dbItem.Rating = movie.Rating;
            dbItem.Year = movie.YearReleased;
            dbItem.Director = director;
            dbItem.Country = country;
            dbItem.Genres = genres.ToList();
        }

        public int Create(Movie movie)
        {
            var dbItem = new Models.Movie();
            Map(movie, dbItem);
            db.Movies.Add(dbItem);
            db.SaveChanges();
            return dbItem.ID;
        }
        
        public bool Update(Movie movie)
        {
            var dbItem = db.Movies.Find(movie.ID);
            if (dbItem == null) return false;
            Map(movie, dbItem);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}