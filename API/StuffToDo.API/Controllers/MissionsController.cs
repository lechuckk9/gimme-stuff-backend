using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Missions.API.Mock.Shared.Data.Models;
using Missions.Common.API.Models;
using StuffToDo.API.Lib.Services;
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
        public MissionsController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        /// <summary>
        /// Adds a new Mission.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPost]
        public async Task<ActionResult<bool>> AddMission(Mission mission)
        {
            // TODO validate token
            //var token = await _usersService.SignIn(request);

            //if (token.Failed)
            //{
            //    return Unauthorized(new ApiResponse<string>(token));
            //}

            return Ok(new ApiResponse<bool>(await _missionService.Create(mission)));
        }

        /// <summary>
        /// Updates the Mission if its state allows it.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPut("{missionId}")]
        public async Task<ActionResult<Mission>> UpdateMission(int missionId, Mission mission)
        {
            mission.MissionId = missionId;
            return Ok(new ApiResponse<Mission>(await _missionService.Update(mission)));
        }

        /// <summary>
        /// Deletes the Mission if its state allows it.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpDelete("{missionId}")]
        public async Task<ActionResult<bool>> DeleteMission(int missionId)
        {
            return Ok(new ApiResponse<bool>(await _missionService.Delete(missionId)));
        }

        /// <summary>
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpGet("{missionId}")]
        public async Task<ActionResult<Mission>> GetAllMissions(int missionId)
        {
            return Ok(new ApiResponse<Mission>(await _missionService.Read(missionId)));
        }

        /// <summary>
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpGet]
        public async Task<ActionResult<Mission[]>> GetAllMissions()
        {
            return Ok(new ApiResponse<Mission[]>(await _missionService.ReadAll()));
        }

        #region Services
        private readonly IMissionService _missionService;
        #endregion
    }
}
