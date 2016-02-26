using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MovieReviewWebApp.Utility
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        IUnityContainer _unity;
        public UnityDependencyResolver()
        {
            _unity = new UnityContainer();
            _unity.LoadConfiguration();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unity.Resolve(serviceType);
            }
            catch (Exception)
            {
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unity.ResolveAll(serviceType);
            }
            catch (Exception)
            {
            }
            return Enumerable.Empty<object>();
        }
    }
}