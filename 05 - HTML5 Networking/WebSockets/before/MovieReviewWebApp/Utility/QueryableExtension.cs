using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace MovieReviewWebApp.Utility
{
    public static class QueryableExtension
    {
        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> list, string sortBy)
        {
            return list.Sort(sortBy, false);
        }
        public static IOrderedQueryable<T> SortDescending<T>(this IQueryable<T> list, string sortBy)
        {
            return list.Sort(sortBy, true);
        }
        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> list, string sortBy, bool descending)
        {
            Func<System.Reflection.MethodInfo, bool> func = null;
            Func<System.Reflection.MethodInfo, bool> func2 = null;
            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(sortBy, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            if (pi == null)
            {
                throw new System.ArgumentException(string.Format("Type {0} does not have a property named {1}", typeof(T).FullName, sortBy));
            }
            ParameterExpression expression = Expression.Parameter(typeof(T), "p");
            MemberExpression propertyExpression = Expression.Property(expression, sortBy);
            Expression lambda = Expression.Lambda(propertyExpression, new ParameterExpression[]
			{
				expression
			});
            System.Type t = typeof(Queryable);
            System.Reflection.MethodInfo mi;
            if (descending)
            {
                System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> arg_9F_0 = t.GetMethods();
                if (func == null)
                {
                    func = ((System.Reflection.MethodInfo m) => m.Name == "OrderByDescending" && m.GetParameters().Count<System.Reflection.ParameterInfo>() == 2);
                }
                mi = arg_9F_0.Where(func).Single<System.Reflection.MethodInfo>();
            }
            else
            {
                System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo> arg_C8_0 = t.GetMethods();
                if (func2 == null)
                {
                    func2 = ((System.Reflection.MethodInfo m) => m.Name == "OrderBy" && m.GetParameters().Count<System.Reflection.ParameterInfo>() == 2);
                }
                mi = arg_C8_0.Where(func2).Single<System.Reflection.MethodInfo>();
            }
            mi = mi.MakeGenericMethod(new System.Type[]
			{
				typeof(T), 
				pi.PropertyType
			});
            return (IOrderedQueryable<T>)mi.Invoke(null, new object[]
			{
				list, 
				lambda
			});
        }
    }
}
 