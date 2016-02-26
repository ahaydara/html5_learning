using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewWebApp.ViewModels
{
    public class NavigationViewModel
    {
        public bool Admin { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}