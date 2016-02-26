using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewWebApp.Areas.Reviews.ViewModels
{
    public class CreateReviewInputModel
    {
        public int MovieID { get; set; }
        [UIHint("Stars")]
        public int? Stars { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name="Review")]
        public string Comment { get; set; }
    }

    public class CreateReviewViewModel : CreateReviewInputModel
    {
        public Movie Movie { get; set; }
    }
}