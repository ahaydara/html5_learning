using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.ViewModels;

namespace MovieReviewWebApp.Areas.Reviews.ViewModels
{
    public class AllReviewsViewModel : PagedViewModel<Review>
    {
    }
}