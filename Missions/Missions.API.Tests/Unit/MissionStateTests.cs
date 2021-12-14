using Missions.API.Mock.Shared.Business;
using Missions.API.Mock.Shared.Data.Adapters;
using Missions.API.Mock.Shared.States;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Missions.API.Tests.Unit
{
    public class MissionStateTests
    {
        private MissionsUnitTestsContext _missionsUnitTestsContext;
        private Mock<IMissionsDbAdapter> _mockMissionsDbAdapter;
        private MissionState _missionState;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MissionStateTests()
        {
            _missionsUnitTestsContext = new MissionsUnitTestsContext();
            _mockMissionsDbAdapter = _missionsUnitTestsContext.CreateMockIMissionsDbAdapter();
        }

        [Fact]
        public async void FinishMission_ValidState_True()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission(1);
            var missionContainer = new MissionContainer(_mockMissionsDbAdapter.Object);
            missionContainer.SetMission(mission);
            _missionState = new NewMissionState(missionContainer);

            // Act
            var result = await _missionState.FinishMission();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void MoveToNextStep_ValidState_True()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission(1);
            var missionContainer = new MissionContainer(_mockMissionsDbAdapter.Object);
            missionContainer.SetMission(mission);
            _missionState = new NewMissionState(missionContainer);

            // Act
            var result = await _missionState.MoveToNextStep();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void MoveToPreviousStep_ValidState_False()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission(1);
            var missionContainer = new MissionContainer(_mockMissionsDbAdapter.Object);
            missionContainer.SetMission(mission);
            _missionState = new NewMissionState(missionContainer);

            // Act
            var result = await _missionState.MoveToPreviousStep();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void ResetMission_ValidState_False()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission(1);
            var missionContainer = new MissionContainer(_mockMissionsDbAdapter.Object);
            missionContainer.SetMission(mission);
            _missionState = new NewMissionState(missionContainer);

            // Act
            var result = await _missionState.ResetMission();

            // Assert
            Assert.False(result);
        }
    }
}
