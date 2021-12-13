using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.API.Mock.Shared.Services.Authentication
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates the user and returns a token.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        Task<string> AuthenticateUserGetToken(string username, string password);
    }
}
