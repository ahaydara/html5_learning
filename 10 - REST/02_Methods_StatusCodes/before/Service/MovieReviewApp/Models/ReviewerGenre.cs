using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApp.Models
{
    public class ReviewerGenre
    {
        public int ID { get; set; }

        [Display(Name="Reviewer")]
        [ForeignKey("Reviewer")]
        public string UserID { get; set; }
        [Display(Name = "Genre")]
        public int GenreID { get; set; }

        
        public virtual Genre Genre { get; set; }
        [ForeignKey("UserID")]
        public virtual User Reviewer { get; set; }
    }
}