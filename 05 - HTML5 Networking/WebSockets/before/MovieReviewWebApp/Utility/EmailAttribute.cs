using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MovieReviewWebApp.Utility
{
    public class EmailAttribute : ValidationAttribute
    {
        public EmailAttribute()
        {
            ErrorMessage = "{0} is not a valid email address.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            return Regex.IsMatch(value.ToString(), @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*");
        }
    }
}