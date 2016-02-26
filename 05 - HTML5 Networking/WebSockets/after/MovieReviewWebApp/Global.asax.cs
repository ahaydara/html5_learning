using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MovieReviewWebApp.Utility;
using System.Security.Principal;
using System.IO;

namespace MovieReviewWebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute() { View = "Error" });
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "MovieReviewWebApp.Controllers" }
            );

        }

        protected void Application_Start()
        {
            RegisterViewEngines();
            RegisterDependencyResolver(new UnityDependencyResolver());
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterViewEngines(ViewEngines.Engines);
            StartWebSocketChatServer();
        }

        void Application_End()
        {
            _server.Dispose();
        }

        static object _websocketErrorLogLock = new object();
        static Fleck.WebSocketServer _server;
        private void StartWebSocketChatServer()
        {
            var _connections = new List<Fleck.IWebSocketConnection>();
            _server = new Fleck.WebSocketServer("ws://localhost:5555");
            _server.Start(
                socket =>
                {
                    socket.OnError =
                        (ex) =>
                        {
                            try
                            {
                                _connections.Remove(socket);
                            }
                            catch { }

                            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"logs\websocketerror.txt");
                            var data = DateTime.Now + Environment.NewLine + ex.ToString() + Environment.NewLine;
                            lock (_websocketErrorLogLock)
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(path));
                                File.AppendAllText(path, data);
                            }
                        };
                    socket.OnOpen =
                        () =>
                        {
                            _connections.Add(socket);
                        };
                    socket.OnClose =
                        () =>
                        {
                            _connections.Add(socket);
                        };
                    socket.OnMessage =
                        (msg) =>
                        {
                            foreach (var s in _connections)
                            {
                                s.Send(msg);
                            }
                        };
                });
        }

        private static void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        private void RegisterDependencyResolver(UnityDependencyResolver dependencyResolver)
        {
            DependencyResolver.SetResolver(dependencyResolver);
        }

        private void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            viewEngineCollection.Clear();
            viewEngineCollection.Add(new RazorViewEngine());
        }

        void Application_PostAuthenticateRequest(object s, EventArgs e)
        {
            var userRepository =
                (MovieReviewWebApp.Models.IUserRepository)DependencyResolver.Current.GetService(typeof(MovieReviewWebApp.Models.IUserRepository));
            var ctx = new HttpContextWrapper(HttpContext.Current);
            LoadRoles(userRepository, ctx);
        }

        public static void LoadRoles(MovieReviewWebApp.Models.IUserRepository userRepository, HttpContextBase ctx)
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