using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Missions.API.Mock.Shared.Data.Models;
using Missions.Common.API.Models;
using StuffToDo.API.Lib.Services;
using StuffToDo.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffToDo.API.Controllers
{
    [EnableCors("MyCorsPolicy")]
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
            return Ok(new ApiResponse<bool>(await _missionService.Create(mission)));
        }

        /// <summary>
        /// Updates the Mission if its state allows it.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPut("{missionId}")]
        public async Task<ActionResult<bool>> UpdateMission(int missionId, Mission mission)
        {
            mission.MissionId = missionId;
            return Ok(new ApiResponse<bool>(await _missionService.Update(mission)));
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
        public async Task<ActionResult<Mission[]>> GetAllMissions([FromQuery] PagedRequest pagedRequest)
        {
            var results = await _missionService.ReadAll();

            // HACK do the paging on a lower level
            List<Mission> resultsPaged = new(results);
            resultsPaged = resultsPaged.Skip(pagedRequest.Page * pagedRequest.PageSize).Take(pagedRequest.PageSize).ToList();

            return Ok
            (
                new ApiResponsePage<Mission>
                (
                    resultsPaged.ToArray(),
                    new()
                    {
                        Page = pagedRequest.Page,
                        PageSize = pagedRequest.PageSize,
                        TotalCount = results.Length
                    }
                )
            );
        }

        /// <summary>
        /// Changes the mission's state.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPatch("{missionId}/state/reset")]
        public async Task<ActionResult<bool>> ResetMission(int missionId)
        {
            return Ok(new ApiResponse<bool>(await _missionService.ResetMission(missionId)));
        }

        /// <summary>
        /// Changes the mission's state.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPatch("{missionId}/state/finish")]
        public async Task<ActionResult<bool>> FinishMission(int missionId)
        {
            return Ok(new ApiResponse<bool>(await _missionService.FinishMission(missionId)));
        }

        /// <summary>
        /// Changes the mission's state.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPatch("{missionId}/state/next")]
        public async Task<ActionResult<bool>> MoveToNextStep(int missionId)
        {
            return Ok(new ApiResponse<bool>(await _missionService.MoveToNextStep(missionId)));
        }

        /// <summary>
        /// Changes the mission's state.
        /// </summary>
        /// <returns>Authentication token</returns>
        /// <exception cref="UnauthorizedResult">Unauthorized</exception>
        [HttpPatch("{missionId}/state/previous")]
        public async Task<ActionResult<bool>> MoveToPreviousStep(int missionId)
        {
            return Ok(new ApiResponse<bool>(await _missionService.MoveToPreviousStep(missionId)));
        }

        #region Services
        private readonly IMissionService _missionService;
        #endregion
    }
}
