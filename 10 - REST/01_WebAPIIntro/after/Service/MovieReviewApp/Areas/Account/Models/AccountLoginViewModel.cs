using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieReviewApp.Utility;

namespace MovieReviewApp.ViewModels
{
    public class AccountLoginInputModel
    {
        [Required]
        [MinStringLength(3)]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [MinStringLength(3)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
    
    public class AccountLoginViewModel : AccountLoginInputModel
    {
        public bool ShowWarning { get; set; }
        public string RolesRequired { get; set; }
    }
}