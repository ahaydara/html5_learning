﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Reviews.ViewModels
{
    public class RecentReviewsViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
    }
}