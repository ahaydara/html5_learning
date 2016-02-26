using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewApp.Models;
using MovieReviewApp.ViewModels;

namespace MovieReviewApp.Areas.Movies.ViewModels
{
    public class MovieIndexViewModel : PagedViewModel<Movie>
    {
    }
}