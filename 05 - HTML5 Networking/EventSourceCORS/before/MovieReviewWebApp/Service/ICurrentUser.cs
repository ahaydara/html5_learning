using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReviewWebApp.Service
{
    public interface ICurrentUser
    {
        bool IsLoggedIn { get; }
        string Username { get; }

        bool IsInRole(string role);
        
        void Login(string username);
        void Logout();
    }
}
