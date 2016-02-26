using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieReviewApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace MovieReviewApp.Service
{
    public class AuthenticationService : IAuthentication
    {
        public bool IsValidUser(string username, string password)
        {
            return true;
        }
    
        const int UserFriendlyPasswordLength = 8;
        const int RandomPasswordByteLength = 20;
        const int MaxFailedPasswordAttempts = 10;
        const int FailedPasswordLockoutPeriod = 10;

        // these characters might be confusing for some users, so 
        // we'll strip them from the user-friendly passwords
        static readonly char[] DisallowedBase64Characters = {'+', '/', '=', '*' };

        IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(string username, string password, string email)
        {
            /*
                registration means:
                1) check for existing username/emails in repository
                2) create entry in repository in disabled state
                3) send message to new user's email with registration code
            */

            // 1) check for existing user
            var existingUsers =
                from x in _userRepository.All
                where x.ID == username || x.Email == email
                select x;
            if (existingUsers.Count() > 0)
            {
                throw new ValidationException("Username and/or Email already registered");
            }

            // 2) create new user
            var pwd = Hash(password);
            User user = new User()
            {
                ID = username,
                PasswordHash = pwd.HashedPassword,
                PasswordSalt = pwd.Salt,
                Password = pwd.Password,
                Email = email,
                CreateDate = DateTime.Now,
                CanLogin = true,
                FailedPasswordCount = 0,
                LastFailedLogin = null,
                IsRoleRegisteredUser = true
            };

            if (user.ID == "admin") user.IsRoleAdmin = true;

            // persist it all
            _userRepository.Insert(user);
            _userRepository.Save();
        }

        public bool Authenticate(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) return false;
            User user =
                (from x in _userRepository.All
                where x.ID == username
                select x).FirstOrDefault();
            return Authenticate(user, password);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            User user =
                (from x in _userRepository.All
                 where x.ID == username
                 select x).FirstOrDefault();
            if (Authenticate(user, oldPassword))
            {
                var newPwd = Hash(newPassword);
                user.PasswordHash = newPwd.HashedPassword;
                user.PasswordSalt = newPwd.Salt;
                _userRepository.Save();
                return true;
            }
            return false;
        }

        public bool ChangeEmail(string username, string email)
        {
            User user =
                (from x in _userRepository.All
                 where x.ID == username
                 select x).FirstOrDefault();
            if (user == null) return false;
            user.Email = email;
            _userRepository.Save();
            return true;
        }

        bool Authenticate(User user, string password)
        {
            if (user == null) return false;

            // user flagged as not allowed in
            if (user.CanLogin == false) return false;

            // user surpassed the failed number of guesses 
            // and their lockout period hasn't expired
            if (user.FailedPasswordCount >= MaxFailedPasswordAttempts)
            {
                DateTime lastFailedLogin = user.LastFailedLogin.Value;
                if (!(user.LastFailedLogin.Value.AddMinutes(FailedPasswordLockoutPeriod) < DateTime.UtcNow))
                {
                    return false;
                }
            }

            // does password line up with data from DB
            var correctPassword = IsPasswordCorrect(password, user.PasswordSalt, user.PasswordHash);
            if (correctPassword)
            {
                // reset their failed password count
                if (user.FailedPasswordCount > 0)
                {
                    user.FailedPasswordCount = 0;
                }
                user.LastSuccessfulLogin = DateTime.UtcNow;
            }
            else
            {
                // bump the fail count
                user.FailedPasswordCount++;
                user.LastFailedLogin = DateTime.UtcNow;
            }

            _userRepository.Save();

            return correctPassword;
        }

        /*
            for our strings (password, salt and hashed password) we want to use
            as human friendly readable formats as possible, so base64 encoding 
            is used, except for the password itself since base64 has limitations 
            on the value space when converting to a byte[], so UTF8 is used for 
            the password.
        */
        static PasswordData Hash(string password)
        {
            // create a salt
            var salt = Convert.ToBase64String(GenerateRandomBytes(RandomPasswordByteLength));
            return Hash(password, salt);
        }
        
        static PasswordData Hash(string password, string salt)
        {
            // turn strings into bytes
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            var saltBytes = Convert.FromBase64String(salt);

            // combine the bytes into one block
            byte[] saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];
            passwordBytes.CopyTo(saltedPasswordBytes, 0);
            saltBytes.CopyTo(saltedPasswordBytes, passwordBytes.Length);

            // get the hash value for the combined block
            var hashedPasswordBytes = SHA256Managed.Create().ComputeHash(saltedPasswordBytes);
            var hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
            
            return new PasswordData
            {
                HashedPassword = hashedPassword,
                Password = password,
                Salt = salt
            };
        }

        static bool IsPasswordCorrect(string password, string salt, string hashedPassword)
        {
            return Hash(password, salt).HashedPassword == hashedPassword;
        }

        static byte[] GenerateRandomBytes(int byteLength)
        {
            byte[] buffer = new byte[byteLength];
            RNGCryptoServiceProvider.Create().GetBytes(buffer);
            return buffer;
        }

        static string GenerateUserFriendlyPassword()
        {
            StringBuilder sb = new StringBuilder();
            while (sb.Length < UserFriendlyPasswordLength)
            {
                // create a random base64 strind and strip out invalid characters
                var tmp = from x in Convert.ToBase64String(GenerateRandomBytes(50)).ToCharArray()
                          where DisallowedBase64Characters.Contains(x) == false
                          select x;
                sb.Append(tmp.ToArray());
            }
            return sb.ToString().Substring(0, UserFriendlyPasswordLength);
        }

        class PasswordData
        {
            public string Password { get; set; }
            public string HashedPassword { get; set; }
            public string Salt { get; set; }
        }

    }
}