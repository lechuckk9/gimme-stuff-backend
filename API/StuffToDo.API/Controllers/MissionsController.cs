using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffToDo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        /// <summary>
        /// Adds a new task.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPost]
        public ActionResult<string> AddTask()
        {
            return Ok();
        }

        /// <summary>
        /// Updates the task if its state allows it.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPut]
        public ActionResult<string> UpdateTask()
        {
            return Ok();
        }

        /// <summary>
        /// Deletes the task if its state allows it.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpDelete]
        public ActionResult<string> DeleteTask()
        {
            return Ok();
        }

        /// <summary>
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpGet]
        public ActionResult<string> GetAllTasks()
        {
            return Ok();
        }
    }

    #region Services
    //private readonly IUserService _userService;
    #endregion
}
