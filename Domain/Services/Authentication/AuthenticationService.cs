using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// login with username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>return User type if login success, return null if login fails</returns>
        public Task<User> Login(string username, string password)
        {
            /* 
             * log in logic goes here
            */
            return Task.Run(() => new User { UserName = username });
        }
        /// <summary>
        /// sign in new user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns>return true if sign in success, return false if sign up fails</returns>
        public Task<bool> Register(string email, string username, string password, string confirmPassword)
        {
            /* 
             * sign in logic goes here
            */
            return Task.Run(() => true);
        }
    }
}
