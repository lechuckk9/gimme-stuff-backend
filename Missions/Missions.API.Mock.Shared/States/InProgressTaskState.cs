using Missions.API.Mock.Shared.Business;
using System;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.States
{
    public class InProgressMissionState : MissionState
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="missionContainer"></param>
        public InProgressMissionState(MissionContainer missionContainer) : base(missionContainer) { }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> FinishMission()
        {
            _missionContainer.Mission.State = EMissionStateType.Done;
            await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);

            return _missionContainer.Mission.State;
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> MoveToNextStep()
        {
            _missionContainer.Mission.State = EMissionStateType.Done;
            await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);

            return _missionContainer.Mission.State;
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> MoveToPreviousStep()
        {
            _missionContainer.Mission.State = EMissionStateType.New;
            await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);

            return _missionContainer.Mission.State;
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> ResetMission()
        {
            _missionContainer.Mission.State = EMissionStateType.New;
            await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);

            return _missionContainer.Mission.State;
        }
    }
}
