using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewApp.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey("Reviewer")]
        public string UserID { get; set; }
        [Range(1, 5)]
        [UIHint("Stars")]
        [Display(Name="Stars")]
        public int? Stars { get; set; }
        [Display(Name="Review")]
        public string Comment { get; set; }
        [Display(Name="Review Date")]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime ReviewDate { get; set; }
        
        public virtual Movie Movie { get; set; }

        [ForeignKey("UserID")]
        public virtual User Reviewer { get; set; }
    }
}