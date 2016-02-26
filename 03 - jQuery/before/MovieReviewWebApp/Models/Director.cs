using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewWebApp.Models
{
    [DisplayColumn("Name")]
    public class Director
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}