using System;
using System.Threading.Tasks;
using Missions.API.Mock.Shared.Data.Models;
using Missions.Common.API.Models;

namespace StuffToDo.API.Lib.Services
{
    /// <summary>
    /// Mission service.
    /// </summary>
    public interface IMissionService
    {
        /// <summary>
        /// Creates a new mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public Task<bool> Create(Mission mission);

        /// <summary>
        /// Gets a mission.
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        public Task<Mission> Read(int missionId);

        /// <summary>
        /// Gets all missions.
        /// </summary>
        /// <returns></returns>
        public Task<Mission[]> ReadAll();

        /// <summary>
        /// Updates a mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public Task<Mission> Update(Mission mission);

        /// <summary>
        /// Deletes a mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        public Task<bool> Delete(int missionId);
    }
}
