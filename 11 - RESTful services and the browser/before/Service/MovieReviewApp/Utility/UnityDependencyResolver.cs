using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MovieReviewApp.Models;
using MovieReviewApp.Service;

namespace MovieReviewApp.Utility
{
    public class UnityDependencyResolver : IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        IUnityContainer _unity;
        public UnityDependencyResolver()
        {
            _unity = new UnityContainer();
            _unity.RegisterType<IAuthentication, AuthenticationService>();
            _unity.RegisterType<ICurrentUser, FormsAuthCurrentUser>();
            _unity.RegisterType<IUserRepository, UserRepository>();
            _unity.RegisterType<IDateTime, SystemDateTime>();
            _unity.RegisterType<IReviewRepository, ReviewRepository>();
            _unity.RegisterType<IMovieRepository, MovieRepository>();
            _unity.RegisterType<IGenreRepository, GenreRepository>();
            _unity.RegisterType<IReviewerGenreRepository, ReviewerGenreRepository>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unity.Resolve(serviceType);
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}