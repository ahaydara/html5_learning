using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Models;
using MovieReviewWebApp.ViewModels;

namespace MovieReviewWebApp.Areas.Movies.ViewModels
{
    public class MovieIndexViewModel : PagedViewModel<Movie>
    {
    }
}