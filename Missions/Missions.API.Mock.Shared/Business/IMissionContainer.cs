using System.Threading.Tasks;
using Missions.API.Mock.Shared.Data.Models;

namespace Missions.API.Mock.Shared.Business
{
    public interface IMissionContainer
    {
        /// <summary>
        /// Moves the Mission to <see cref="EStateType.New"/> state.
        /// </summary>
        Task<bool> ResetMission();

        /// <summary>
        /// Moves the Mission to <see cref="EStateType.Done"/> state.
        /// </summary>
        Task<bool> FinishMission();

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        Task<bool> MoveToPreviousStep();

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        Task<bool> MoveToNextStep();

        /// <summary>
        /// Creates a new Mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task<bool> CreateNew(Mission mission);

        /// <summary>
        /// Gets a mission.
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        Task<Mission> Get(int missionId);

        /// <summary>
        /// Gets all missions.
        /// </summary>
        /// <returns></returns>
        Task<Mission[]> GetAll();

        /// <summary>
        /// Deletes a mission.
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        Task<bool> Delete(int missionId);

        /// <summary>
        /// Updates a new Mission.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        Task<bool> Update(Mission mission);

        /// <summary>
        /// Sets the mission object to the container, by loading it from the database.
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        void SetMission(int missionId);

        /// <summary>
        /// Sets the mission object to the container.
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        void SetMission(Mission mission);
    }
}
