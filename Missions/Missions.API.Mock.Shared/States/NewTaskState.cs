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
        public override async Task<bool> FinishMission()
        {
            _missionContainer.Mission.State = EMissionStateType.Done;
            return await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);
        }

        /// <inheritdoc/>
        public override async Task<bool> MoveToNextStep()
        {
            _missionContainer.Mission.State = EMissionStateType.InProgress;
            return await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);
        }

        /// <inheritdoc/>
        public override async Task<bool> MoveToPreviousStep()
        {
            return await Task.FromResult(false);
        }

        /// <inheritdoc/>
        public override async Task<bool> ResetMission()
        {
            return await Task.FromResult(false);
        }
    }
}
