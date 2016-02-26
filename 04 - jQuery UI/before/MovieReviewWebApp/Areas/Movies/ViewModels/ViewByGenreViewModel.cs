using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Models;
using System.Web.Mvc;

namespace MovieReviewWebApp.Areas.Movies.ViewModels
{
    public class ViewByGenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<SelectListItem> GenreSelectList
        {
            get
            {
                var q =
                    from x in Genres
                    select new SelectListItem
                    {
                        Text = x.Name, Value = x.ID.ToString(), Selected = x.ID == CurrentGenreID
                    };
                return q;
            }
        }
        public int CurrentGenreID { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}