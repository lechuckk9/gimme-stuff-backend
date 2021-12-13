using Missions.API.Mock.Shared.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.Data.Adapters
{
    /// <summary>
    /// Missions database adapter.
    /// </summary>
    public interface IMissionsDbAdapter
    {
        /// <summary>
        /// Creates a new mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task<bool> Create(Mission mission);

        /// <summary>
        /// Gets a mission.
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        Task<Mission> Read(int missionId);

        /// <summary>
        /// Gets all missions.
        /// </summary>
        /// <returns></returns>
        Task<Mission[]> ReadAll();

        /// <summary>
        /// Updates a mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task<Mission> Update(Mission mission);

        /// <summary>
        /// Deletes a mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task<bool> Delete(int missionId);
    }
}
