using System.Threading.Tasks;
using Missions.API.Mock.Shared.Data.Models;

namespace Missions.API.Mock.Shared.Business
{
    public interface IMissionContainer
    {
        /// <summary>
        /// Moves the Mission to <see cref="EStateType.New"/> state.
        /// </summary>
        Task ResetMission();

        /// <summary>
        /// Moves the Mission to <see cref="EStateType.Done"/> state.
        /// </summary>
        Task FinishMission();

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        Task MoveToPreviousStep();

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        Task MoveToNextStep();

        /// <summary>
        /// Creates a new Mission.
        /// </summary>
        /// <param name="missionDbAdapter"></param>
        /// <returns></returns>
        Task<bool> CreateNew(Mission mission);

        /// <summary>
        /// Get a mission.
        /// </summary>
        /// <param name="missionDbAdapter"></param>
        /// <param name="missionId"></param>
        /// <returns></returns>
        Task<Mission> Get(int missionId);

        /// <summary>
        /// Get all missions.
        /// </summary>
        /// <param name="missionDbAdapter"></param>
        /// <returns></returns>
        Task<Mission[]> GetAll();
    }
}
