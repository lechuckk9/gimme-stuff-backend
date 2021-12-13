using Missions.API.Mock.Shared.Business;
using System;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.States
{
    public class DoneMissionState : MissionState
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="missionContainer"></param>
        public DoneMissionState(MissionContainer missionContainer) : base(missionContainer) { }

        /// <inheritdoc/>
        public override async Task<bool> FinishMission()
        {
            return await Task.FromResult(false);
        }

        /// <inheritdoc/>
        public override async Task<bool> MoveToNextStep()
        {
            return await Task.FromResult(false);
        }

        /// <inheritdoc/>
        public override async Task<bool> MoveToPreviousStep()
        {
            _missionContainer.Mission.State = EMissionStateType.InProgress;
            return await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);
        }

        /// <inheritdoc/>
        public override async Task<bool> ResetMission()
        {
            _missionContainer.Mission.State = EMissionStateType.New;
            return await _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);
        }
    }
}
