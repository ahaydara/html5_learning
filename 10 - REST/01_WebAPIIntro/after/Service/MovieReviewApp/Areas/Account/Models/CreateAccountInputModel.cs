using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieReviewApp.Utility;

namespace MovieReviewApp.Areas.Account.Models
{
    public class CreateAccountInputModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Email]
        public string Email { get; set; }
    }
}