﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Models;

namespace MovieReviewWebApp.Areas.Reviews.ViewModels
{
    public class ReviewsViewByMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}