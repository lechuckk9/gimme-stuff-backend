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
        public override async Task<bool> FinishMission()
        {
            _missionContainer.Mission.State = EMissionStateType.Done;
            return await  _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);
        }

        /// <inheritdoc/>
        public override async Task<bool> MoveToNextStep()
        {
            _missionContainer.Mission.State = EMissionStateType.Done;
            return await  _missionContainer._missionsDbAdapter.Update(_missionContainer.Mission);
        }

        /// <inheritdoc/>
        public override async Task<bool> MoveToPreviousStep()
        {
            _missionContainer.Mission.State = EMissionStateType.New;
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
