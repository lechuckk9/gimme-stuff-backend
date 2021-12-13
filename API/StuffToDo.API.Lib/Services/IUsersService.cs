using Missions.Common.API.Models;
using StuffToDo.API.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffToDo.API.Lib.Services
{
    /// <summary>
    /// User service.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Authenticates the user and returns an authentication token.
        /// </summary>
        /// <returns></returns>
        Task<Result<string>> SignIn(SignInRequest request);
    }
}
