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
    public class ReviewRepository : IReviewRepository
    {
        MovieWebAppDBContext context = new MovieWebAppDBContext();

        public IQueryable<Review> All
        {
            get { return context.Reviews; }
        }

        public IQueryable<Review> AllIncluding(params Expression<Func<Review, object>>[] includeProperties)
        {
            IQueryable<Review> query = context.Reviews;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Review Find(int id)
        {
            return context.Reviews.Find(id);
        }

        public void InsertOrUpdate(Review review)
        {
            if (review.ID == default(int)) {
                // New entity
                context.Reviews.Add(review);
            } else {
                // Existing entity
                context.Entry(review).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var review = context.Reviews.Find(id);
            context.Reviews.Remove(review);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IReviewRepository
    {
        IQueryable<Review> All { get; }
        IQueryable<Review> AllIncluding(params Expression<Func<Review, object>>[] includeProperties);
        Review Find(int id);
        void InsertOrUpdate(Review review);
        void Delete(int id);
        void Save();
    }
}