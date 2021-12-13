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
        public override async Task<EMissionStateType> FinishMission()
        {
            return await Task.FromResult(_missionContainer.Mission.State);
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> MoveToNextStep()
        {
            return await Task.FromResult(_missionContainer.Mission.State);
        }

        /// <inheritdoc/>
        public override async Task<EMissionStateType> MoveToPreviousStep()
        {
            _missionContainer.Mission.State = EMissionStateType.InProgress;
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
