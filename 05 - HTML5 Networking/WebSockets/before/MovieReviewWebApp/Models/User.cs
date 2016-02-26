using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReviewWebApp.Models
{
    [DisplayColumn("Name")]
    public class User
    {
        public string ID { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool CanLogin { get; set; }
        public DateTime? LastSuccessfulLogin { get; set; }
        public int FailedPasswordCount { get; set; }
        public DateTime? LastFailedLogin { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public bool IsRoleAdmin { get; set; }
        public bool IsRoleReviewer { get; set; }
        public bool IsRoleRegisteredUser { get; set; }
    }
}
