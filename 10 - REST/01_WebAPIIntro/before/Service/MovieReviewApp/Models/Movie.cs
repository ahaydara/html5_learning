using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Models
{
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genre>();
        }

        public int ID { get; set; }

        public string Title { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name="Description")]
        public string Description { get; set; }

        [Display(Name = "Year Released")]
        public int Year { get; set; }

        [Display(Name = "Rating")]
        public string Rating { get; set; }

        [Display(Name = "Director")]
        public virtual Director Director { get; set; }
        public int? DirectorID { get; set; }

        [Display(Name = "Country")]
        public virtual Country Country { get; set; }
        public int? CountryID { get; set; }

        [Display(Name = "Genre")]
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Review> Reviews { get; set; }
        
        public string PosterName { get; set; }

        [Display(Name="Number of Reviews")]
        public int NumberOfReviews
        {
            get
            {
                return Reviews != null ? Reviews.Count() : 0;
            }
        }

        [UIHint("Stars")]
        [Display(Name="Average Stars")]
        public int? AverageStars
        {
            get
            {
                var q =
                    from x in Reviews
                    select x.Stars;
                var avg = q.Average();
                if (avg == null) return null;
                return (int)Math.Round(avg.Value);
            }
        }
    }
}