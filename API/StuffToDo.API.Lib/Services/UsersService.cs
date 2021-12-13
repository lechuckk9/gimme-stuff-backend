using Missions.Common.API.Models;
using Missions.Common.Lib.Exceptions;
using StuffToDo.API.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.API.Mock.Shared.Services.Authentication;

namespace StuffToDo.API.Lib.Services
{
    /// <inheritdoc/>
    public class UsersService : IUsersService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="authenticationService"></param>
        public UsersService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <inheritdoc/>
        public async Task<Result<string>> SignIn(SignInRequest request)
        {
            var token = await _authenticationService.AuthenticateUserGetToken(request.Username, request.Password);

            if (token == null)
            {
                return Result<string>.AsFail(new ExceptionBase(2, "Sign-in token generation failed."));
            }

            return Result<string>.AsSuccess(token);
        }

        #region Services
        private IAuthenticationService _authenticationService;
        #endregion
    }
}
