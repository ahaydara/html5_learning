using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.WebPages;
using MovieReviewApp.ViewModels;

namespace MovieReviewApp.Utility
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper html, string path)
        {
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", UrlHelper.GenerateContentUrl(path, html.ViewContext.HttpContext));
            return MvcHtmlString.Create(img.ToString());
        }
        
        public static MvcHtmlString Poster(this HtmlHelper html, string name)
        {
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", 
                UrlHelper.GenerateUrl(
                    null, "Index", "Poster", 
                    new RouteValueDictionary(new { id=name, area="" }), 
                    RouteTable.Routes, 
                    html.ViewContext.RequestContext, 
                    false));
            return MvcHtmlString.Create(img.ToString());
        }
        
        public static MvcHtmlString Error(this HtmlHelper html)
        {
            return Image(html, "~/Content/images/cross_octagon_fram.png");
        }

        public static MvcHtmlString SortHeader(this HtmlHelper html, PagedViewModel data, string text, string prop, string action)
        {
            bool desc = data.SortDesc;
            if (data.SortBy.Equals(prop, StringComparison.OrdinalIgnoreCase)) desc = !desc;
            return html.ActionLink(text, action, new { page=1, sort=prop, desc });
        }

        public static MvcHtmlString Pager(this HtmlHelper html, PagedViewModel data, string action)
        {
            data.Action = action;
            return html.Partial("Pager", data);
        }
        
        public static MvcHtmlString ReviewLink(this HtmlHelper html, int id)
        {
            return html.ActionLink("Write a review", "CreateFor", "Review", new { area="Reviews", id }, null);
        }
    }
}