using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewApp.Service
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class SystemDateTime : IDateTime
    {
        public DateTime Now
        {
            get { return System.DateTime.Now; }
        }
    }
}