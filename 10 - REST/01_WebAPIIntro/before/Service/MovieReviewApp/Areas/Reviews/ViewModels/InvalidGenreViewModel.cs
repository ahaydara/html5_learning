using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Reviews.ViewModels
{
    public class InvalidGenreViewModel
    {
        public IEnumerable<Genre> AllowedGenres { get; set; }
        public IEnumerable<Genre> CurrentMovieGenres { get; set; }

    }
}