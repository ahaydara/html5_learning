using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieReviewApp.Utility
{
    public class MinStringLength : ValidationAttribute
    {
        public int Length { get; set; }

        public MinStringLength(int length)
        {
            if (length <= 0) throw new ArgumentException("Length must be greater than zero.");
            
            Length = length;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            var str = value.ToString();
            return str.Length >= Length;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format("The field {0} must be at least {1} characters long.", name, Length);
        }
    }
}