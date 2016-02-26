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
    public class DirectorRepository : IDirectorRepository
    {
        MovieWebAppDBContext context = new MovieWebAppDBContext();

        public IQueryable<Director> All
        {
            get { return context.Directors; }
        }

        public IQueryable<Director> AllIncluding(params Expression<Func<Director, object>>[] includeProperties)
        {
            IQueryable<Director> query = context.Directors;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Director Find(int id)
        {
            return context.Directors.Find(id);
        }

        public void InsertOrUpdate(Director director)
        {
            if (director.ID == default(int)) {
                // New entity
                context.Directors.Add(director);
            } else {
                // Existing entity
                context.Entry(director).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var director = context.Directors.Find(id);
            context.Directors.Remove(director);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IDirectorRepository
    {
        IQueryable<Director> All { get; }
        IQueryable<Director> AllIncluding(params Expression<Func<Director, object>>[] includeProperties);
        Director Find(int id);
        void InsertOrUpdate(Director director);
        void Delete(int id);
        void Save();
    }
}