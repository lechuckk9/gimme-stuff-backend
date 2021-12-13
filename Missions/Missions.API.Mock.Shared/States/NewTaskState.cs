using Missions.API.Mock.Shared.Business;
using System;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.States
{
    public class NewMissionState : MissionState
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="missionContainer"></param>
        public NewMissionState(MissionContainer missionContainer) : base(missionContainer) { }

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
            _missionContainer.Mission.State = EMissionStateType.InProgress;
            await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);

            return _missionContainer.Mission.State;
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> MoveToPreviousStep()
        {
            return await Task.FromResult(_missionContainer.Mission.State);
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> ResetMission()
        {
            return await Task.FromResult(_missionContainer.Mission.State);
        }
    }
}
