using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Models;

namespace MovieReviewWebApp.Areas.Reviews.ViewModels
{
    public class InvalidGenreViewModel
    {
        public IEnumerable<Genre> AllowedGenres { get; set; }
        public IEnumerable<Genre> CurrentMovieGenres { get; set; }

    }
}