using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MovieReviewApp.Utility;

namespace MovieReviewApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDependencyResolver(new UnityDependencyResolver());
            RegisterViewEngines(ViewEngines.Engines);
            RegisterMediaFormatters(GlobalConfiguration.Configuration);
        }

        private void RegisterMediaFormatters(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Formatters.Add(new JpgMediaTypeFormatter());
        }

        private static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        private void RegisterDependencyResolver(UnityDependencyResolver dependencyResolver)
        {
            DependencyResolver.SetResolver(dependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }

        private void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            viewEngineCollection.Clear();
            viewEngineCollection.Add(new RazorViewEngine());
        }

        void Application_PostAuthenticateRequest(object s, EventArgs e)
        {
            var userRepository =
                (MovieReviewApp.Models.IUserRepository)DependencyResolver.Current.GetService(typeof(MovieReviewApp.Models.IUserRepository));
            var ctx = new HttpContextWrapper(HttpContext.Current);
            LoadRoles(userRepository, ctx);
        }

        public static void LoadRoles(MovieReviewApp.Models.IUserRepository userRepository, HttpContextBase ctx)
        {
            if (ctx.Request.IsAuthenticated)
            {
                var user =
                    (from x in userRepository.All
                     where x.ID == ctx.User.Identity.Name
                     select x).Single();
                var roleList = new List<string>();
                if (user.IsRoleAdmin) roleList.Add("Admin");
                if (user.IsRoleReviewer || user.IsRoleAdmin) roleList.Add("Reviewer");
                if (user.IsRoleRegisteredUser || user.IsRoleReviewer || user.IsRoleAdmin) roleList.Add("RegisteredUser");
                if (roleList.Count() > 0)
                {
                    ctx.User = new GenericPrincipal(ctx.User.Identity, roleList.ToArray());
                }
            }
        }
    }
}