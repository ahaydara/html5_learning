using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MovieReviewApp.Models;

namespace MovieReviewApp.Models
{ 
    public class GenreRepository : IGenreRepository
    {
        MovieWebAppDBContext context = new MovieWebAppDBContext();

        public GenreRepository()
        {

        }

        public IQueryable<Genre> All
        {
            get { return context.Genres; }
        }

        public IQueryable<Genre> AllIncluding(params Expression<Func<Genre, object>>[] includeProperties)
        {
            IQueryable<Genre> query = context.Genres;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Genre Find(int id)
        {
            return context.Genres.Find(id);
        }

        public void InsertOrUpdate(Genre genre)
        {
            if (genre.ID == default(int)) {
                // New entity
                context.Genres.Add(genre);
            } else {
                // Existing entity
                context.Entry(genre).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var genre = context.Genres.Find(id);
            context.Genres.Remove(genre);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IGenreRepository
    {
        IQueryable<Genre> All { get; }
        IQueryable<Genre> AllIncluding(params Expression<Func<Genre, object>>[] includeProperties);
        Genre Find(int id);
        void InsertOrUpdate(Genre genre);
        void Delete(int id);
        void Save();
    }
}