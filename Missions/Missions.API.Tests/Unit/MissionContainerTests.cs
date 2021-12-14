using Missions.API.Mock.Shared.Business;
using Missions.API.Mock.Shared.Data.Adapters;
using Missions.API.Mock.Shared.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Missions.API.Tests.Unit
{
    /// <summary>
    /// Tests for <see cref="MissionContainerTests"/>.
    /// </summary>
    public class MissionContainerTests
    {
        private MissionsUnitTestsContext _missionsUnitTestsContext;
        private Mock<IMissionsDbAdapter> _mockMissionsDbAdapter;
        private MissionContainer _missionContainer;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MissionContainerTests()
        {
            _missionsUnitTestsContext = new MissionsUnitTestsContext();
            _mockMissionsDbAdapter = _missionsUnitTestsContext.CreateMockIMissionsDbAdapter();
            _missionContainer = new MissionContainer(_mockMissionsDbAdapter.Object);
        }

        [Fact]
        public async void Create_InvalidMission_False()
        {
            // Arrange
            Mission mission = new();

            // Act
            var result = await _missionContainer.CreateNew(mission);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void Create_ValidMission_True()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission();

            // Act
            var result = await _missionContainer.CreateNew(mission);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(42, true)]
        [InlineData(-6, false)]
        [InlineData(-66, false)]
        public async void Get_VariousMissionIds_ValidMissionIfMissionIdGreaterThanZero(int missionId, bool missionNotNull)
        {
            // Arrange

            // Act
            var result = await _missionContainer.Get(missionId);

            // Assert
            Assert.Equal(missionNotNull, result != null);
        }

        [Fact]
        public async void GetAll_MissionsExist_MissionCollection()
        {
            // Arrange

            // Act
            var result = await _missionContainer.GetAll();

            // Assert
            Assert.IsType<Mission[]>(result);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(42, true)]
        [InlineData(-6, false)]
        [InlineData(-66, false)]
        public async void Delete_VariousMissionIds_ValidMissionIfMissionIdGreaterThanZero(int missionId, bool expectedResult)
        {
            // Arrange

            // Act
            var result = await _missionContainer.Delete(missionId);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void Update_InvalidMission_False()
        {
            // Arrange
            Mission mission = new();

            // Act
            var result = await _missionContainer.CreateNew(mission);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async void Update_ValidMission_True()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission(1);

            // Act
            var result = await _missionContainer.CreateNew(mission);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SetMission_ValidMissionId_True()
        {
            // Arrange
            int missionId = 1;
            var mission = _missionsUnitTestsContext.GetAValidMission(1);

            // Act
            _missionContainer.SetMission(missionId);

            // Assert
            Assert.Equal(mission.State, _missionContainer.Mission.State);
        }

        [Fact]
        public void SetMission_ValidMission_True()
        {
            // Arrange
            var mission = _missionsUnitTestsContext.GetAValidMission(1);

            // Act
            _missionContainer.SetMission(mission);

            // Assert
            Assert.Equal(mission.State, _missionContainer.Mission.State);
        }
    }
}
