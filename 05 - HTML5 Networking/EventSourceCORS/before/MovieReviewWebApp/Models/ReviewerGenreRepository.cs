using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MovieReviewWebApp.Models;

namespace MovieReviewWebApp.Models
{ 
    public class ReviewerGenreRepository : IReviewerGenreRepository
    {
        MovieWebAppDBContext context = new MovieWebAppDBContext();

        public IQueryable<ReviewerGenre> All
        {
            get { return context.ReviewerGenres; }
        }

        public IQueryable<ReviewerGenre> AllIncluding(params Expression<Func<ReviewerGenre, object>>[] includeProperties)
        {
            IQueryable<ReviewerGenre> query = context.ReviewerGenres;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ReviewerGenre Find(int id)
        {
            return context.ReviewerGenres.Find(id);
        }

        public void InsertOrUpdate(ReviewerGenre reviewergenre)
        {
            if (reviewergenre.ID == default(int)) {
                // New entity
                context.ReviewerGenres.Add(reviewergenre);
            } else {
                // Existing entity
                context.Entry(reviewergenre).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var reviewergenre = context.ReviewerGenres.Find(id);
            context.ReviewerGenres.Remove(reviewergenre);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IReviewerGenreRepository
    {
        IQueryable<ReviewerGenre> All { get; }
        IQueryable<ReviewerGenre> AllIncluding(params Expression<Func<ReviewerGenre, object>>[] includeProperties);
        ReviewerGenre Find(int id);
        void InsertOrUpdate(ReviewerGenre reviewergenre);
        void Delete(int id);
        void Save();
    }
}