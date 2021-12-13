using Missions.API.Mock.Shared.Data.Adapters;
using Missions.API.Mock.Shared.Data.Models;
using Missions.API.Mock.Shared.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.Business
{
    /// <summary>
    /// Container class for <see cref="Task"/> classes. Also manages their states.
    /// </summary>
    public sealed class MissionContainer : IMissionContainer
    {
        /// <summary>
        /// Constructor for existing missions.
        /// </summary>
        /// <param name="mission"></param>
        public MissionContainer(Mission mission, IMissionsDbAdapter missionDbAdapter)
        {
            _mission = mission;
            _missionsDbAdapter = missionDbAdapter;
            SetMissionState();
        }

        /// <inheritdoc/>
        public MissionContainer(IMissionsDbAdapter missionDbAdapter) : this(new Mission(), missionDbAdapter) { }

        /// <inheritdoc/>
        public async Task ResetMission()
        {
            _mission.State = await _missionState.ResetMission();
        }

        /// <inheritdoc/>
        public async Task FinishMission()
        {
            _mission.State = await _missionState.FinishMission();
        }

        /// <inheritdoc/>
        public async Task MoveToPreviousStep()
        {
            _mission.State = await _missionState.MoveToPreviousStep();
        }

        /// <inheritdoc/>
        public async Task MoveToNextStep()
        {
            _mission.State = await _missionState.MoveToNextStep();
        }

        /// <inheritdoc/>
        public async Task<bool> CreateNew(Mission mission) => await _missionsDbAdapter.Create(mission);


        /// <inheritdoc/>
        public async Task<Mission> Get(int missionId) => await _missionsDbAdapter.Read(missionId);

        /// <inheritdoc/>
        public async Task<Mission[]> GetAll() => await _missionsDbAdapter.ReadAll();

        private void SetMissionState()
        {
            if (_mission != null)
            {
                _missionState = _mission.State switch
                {
                    EMissionStateType.InProgress => new InProgressMissionState(this),
                    EMissionStateType.Done => new DoneMissionState(this),
                    _ => new NewMissionState(this),
                };
            }
        }

        #region Properies
        /// <summary>
        /// Mission's object.
        /// </summary>
        public Mission Mission { get => _mission; }
        #endregion

        #region Fields
        private MissionState _missionState;
        private Mission _mission;

        internal IMissionsDbAdapter _missionsDbAdapter;
        #endregion
    }
}
