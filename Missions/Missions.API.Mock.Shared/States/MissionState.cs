using System.Threading.Tasks;
using Missions.API.Mock.Shared.Business;

namespace Missions.API.Mock.Shared.States
{
    public abstract class MissionState
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="missionContainer"></param>
        public MissionState(MissionContainer missionContainer)
        {
            _missionContainer = missionContainer;
        }

        /// <summary>
        /// Moves the Mission to <see cref="EStateType.New"/> state.
        /// </summary>
        /// <returns>New <see cref="EStateType"/> state.</returns>
        public abstract Task<EMissionStateType> ResetMission();

        /// <summary>
        /// Moves the Mission to <see cref="EStateType.Done"/> state.
        /// </summary>
        /// <returns>New <see cref="EStateType"/> state.</returns>
        public abstract Task<EMissionStateType> FinishMission();

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        /// <returns>New <see cref="EStateType"/> state.</returns>
        public abstract Task<EMissionStateType> MoveToPreviousStep();

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        /// <returns>New <see cref="EStateType"/> state.</returns>
        public abstract Task<EMissionStateType> MoveToNextStep();

        #region Fields
        protected MissionContainer _missionContainer;
        #endregion
    }
}
