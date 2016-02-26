using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewApp.Service
{
    public class MovieService
    {
        MovieReviewApp.Models.MovieWebAppDBContext db = new Models.MovieWebAppDBContext();

        public IQueryable<Movie> MapAll(IQueryable<Models.Movie> dbItems)
        {
            var query =
                from m in dbItems
                let director = m.Director != null ? m.Director.Name : null
                let country = m.Country != null ? m.Country.Name : null
                select new Movie
                {
                    ID = m.ID,
                    Title = m.Title,
                    Rating = m.Rating,
                    YearReleased = m.Year,
                    Description = m.Description,
                    Director = director,
                    Country = country,
                    PosterName = m.PosterName
                };
            return query;
        }
        public IQueryable<Movie> GetAllMovies()
        {
            var query =
                from m in db.Movies
                    .Include("Director")
                    .Include("Country")
                select m;
            return MapAll(query);
        }

        public Movie Find(int id)
        {
            return this.GetAllMovies().SingleOrDefault(x => x.ID == id);
        }

        void Map(Movie movie, Models.Movie dbItem)
        {
            var director = db.Directors.FirstOrDefault(d => d.Name == movie.Director);
            if (director == null && !String.IsNullOrWhiteSpace(movie.Director))
            {
                director = new Models.Director(){Name = movie.Director};
            }
            var country = db.Countries.FirstOrDefault(c => c.Name == movie.Country);
            if (country == null)
            {
                country = new Models.Country(){Name = movie.Country};
            }

            dbItem.Title = movie.Title;
            dbItem.Description = movie.Description;
            dbItem.Rating = movie.Rating;
            dbItem.Year = movie.YearReleased;
            dbItem.Director = director;
            dbItem.Country = country;
        }

        public Movie Create(Movie movie)
        {
            var dbItem = new Models.Movie();
            Map(movie, dbItem);
            db.Movies.Add(dbItem);
            db.SaveChanges();
            return MapAll(new Models.Movie[] { dbItem }.AsQueryable()).Single();
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