using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Missions.Common.API.Models;
using StuffToDo.API.Lib.Models;
using StuffToDo.API.Lib.Services;
using System.Threading.Tasks;

namespace StuffToDo.API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Authenticates the user and returns their authentication token.
        /// </summary>
        /// <param name="request">Username and password.</param>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult<ApiResponse<Result<string>>>> SignIn([FromBody] SignInRequest request)
        {
            var token = await _usersService.SignIn(request);

            if (token.Failed)
            {
                return Unauthorized(new ApiResponse<string>(token));
            }

            return Ok(new ApiResponse<string>(token));
        }

        #region Services
        private readonly IUsersService _usersService;
        #endregion
    }
}
