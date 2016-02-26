using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReviewApp.Service
{
    public interface IAuthentication
    {
        bool Authenticate(string username, string password);
        void Register(string username, string password, string email);
        bool ChangePassword(string username, string oldPassword, string newPassword);
        bool ChangeEmail(string username, string email);
    }
}
