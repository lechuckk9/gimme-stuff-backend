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
        /// Constructor for new missions.
        /// </summary>
        /// <param name="mission"></param>
        public MissionContainer(IMissionsDbAdapter missionsDbAdapter) : this(new Mission(), missionsDbAdapter) { }

        /// <summary>
        /// Constructor for existing missions.
        /// </summary>
        /// <param name="mission"></param>
        public MissionContainer(Mission mission, IMissionsDbAdapter missionsDbAdapter)
        {
            _missionsDbAdapter = missionsDbAdapter;
            SetMission(mission);
        }

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


        /// <inheritdoc/>
        public async Task<bool> ResetMission()
        {
            return await _missionState.ResetMission();
        }

        /// <inheritdoc/>
        public async Task<bool> FinishMission()
        {
            return await _missionState.FinishMission();
        }

        /// <inheritdoc/>
        public async Task<bool> MoveToPreviousStep()
        {
            return await _missionState.MoveToPreviousStep();
        }

        /// <inheritdoc/>
        public async Task<bool> MoveToNextStep()
        {
            return await _missionState.MoveToNextStep();
        }

        /// <inheritdoc/>
        public async Task<bool> CreateNew(Mission mission) => await _missionsDbAdapter.Create(mission);

        /// <inheritdoc/>
        public async Task<Mission> Get(int missionId) => await _missionsDbAdapter.Read(missionId);

        /// <inheritdoc/>
        public async Task<Mission[]> GetAll() => await _missionsDbAdapter.ReadAll();

        /// <inheritdoc/>
        public async Task<bool> Delete(int missionId) => await _missionsDbAdapter.Delete(missionId);

        /// <inheritdoc/>
        public async Task<bool> Update(Mission mission) => await _missionsDbAdapter.Update(mission);

        /// <inheritdoc/>
        public async void SetMission(int missionId)
        {
            _mission = await Get(missionId);
            SetMissionState();
        }

        /// <inheritdoc/>
        public void SetMission(Mission mission)
        {
            _mission = mission;
            SetMissionState();
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
