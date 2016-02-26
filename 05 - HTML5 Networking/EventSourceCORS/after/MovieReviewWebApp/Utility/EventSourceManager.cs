using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewWebApp.Utility
{
    public class EventSourceManager
    {
        static Dictionary<string, Dictionary<string, List<HttpContextBase>>> _entries = new Dictionary<string, Dictionary<string, List<HttpContextBase>>>();

        static object _lock = new object();

        public static void RegisterClient(string type, string key, HttpContextBase ctx)
        {
            lock (_lock)
            {
                if (!_entries.ContainsKey(type))
                {
                    _entries.Add(type, new Dictionary<string, List<HttpContextBase>>());
                }
                var typeDictionary = _entries[type];
                if (!typeDictionary.ContainsKey(key))
                {
                    typeDictionary.Add(key, new List<HttpContextBase>());
                }
                var list = typeDictionary[key];
                list.Add(ctx);
            }
        }
    }
}