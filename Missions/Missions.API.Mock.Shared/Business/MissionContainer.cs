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
    public sealed class MissionContainer
    {
        /// <summary>
        /// Constructor for existing missions.
        /// </summary>
        /// <param name="mission"></param>
        public MissionContainer(Mission mission)
        {
            _mission = mission;
            SetMissionState();
        }

        /// <summary>
        /// Default constructor; generates a new <see cref="Mission"/>.
        /// </summary>
        public MissionContainer() : this(new Mission()) { }

        /// <summary>
        /// Moves the Mission to <see cref="EStateType.New"/> state.
        /// </summary>
        public void ResetMission()
        {
            _mission.State = _missionState.ResetMission();
        }

        /// <summary>
        /// Moves the Mission to <see cref="EStateType.Done"/> state.
        /// </summary>
        public void FinishMission()
        {
            _mission.State = _missionState.FinishMission();
        }

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        public void MoveToPreviousStep()
        {
            _mission.State = _missionState.MoveToPreviousStep();
        }

        /// <summary>
        /// Moves the Mission to the appropriate <see cref="EStateType"/> state.
        /// </summary>
        public void MoveToNextStep()
        {
            _mission.State = _missionState.MoveToNextStep();
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
        #region Properies
        /// <summary>
        /// Mission's object.
        /// </summary>
        public Mission Mission { get => _mission; }
        #endregion

        #region Fields
        private MissionState _missionState;
        private Mission _mission;
        #endregion
    }
}
