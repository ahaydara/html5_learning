using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewWebApp.Utility;

namespace MovieReviewWebApp.ViewModels
{
    public abstract class PagedViewModel
    {
        public string SortBy { get; set; }
        public bool SortDesc { get; set; }

        public string Action { get; set; }

        int _ItemsPerPage = 1;
        public int ItemsPerPage
        {
            get
            {
                return _ItemsPerPage;
            }
            set
            {
                if (value < 1) _ItemsPerPage = 1;
                else _ItemsPerPage = value;
            }
        }
        
        int _CurrentPage = 1;
        public int CurrentPage
        {
            get
            {
                if (_CurrentPage > TotalPages) return TotalPages;
                return _CurrentPage;
            }
            set
            {
                if (value < 1) _CurrentPage = 1;
                else _CurrentPage = value;
            }
        }

        public int TotalPages
        {
            get
            {
                if (TotalItems == 0) return 1;
                return (int)Math.Ceiling((double)TotalItems / (double)ItemsPerPage);
            }
        }
        public abstract int TotalItems { get; }
    }

    public class PagedViewModel<T> : PagedViewModel
    {
        public IQueryable<T> DataSource { get; set; }

        int? _TotalItems;
        public override int TotalItems
        {
            get
            {
                if (_TotalItems == null)
                {
                    _TotalItems = DataSource.Count();
                }
                return _TotalItems.Value;
            }
        }

        IEnumerable<T> _Items;
        public IEnumerable<T> Items
        {
            get
            {
                if (_Items == null)
                {
                    var q =
                        from x in DataSource
                        select x;
                    var skip = ((CurrentPage - 1) * ItemsPerPage);
                    var rows = ItemsPerPage;
                    _Items = q.Sort(SortBy, SortDesc).Skip(skip).Take(rows).ToArray();
                }
                return _Items;
            }
        }
    }
}