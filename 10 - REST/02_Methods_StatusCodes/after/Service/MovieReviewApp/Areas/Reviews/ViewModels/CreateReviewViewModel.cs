using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Areas.Reviews.ViewModels
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