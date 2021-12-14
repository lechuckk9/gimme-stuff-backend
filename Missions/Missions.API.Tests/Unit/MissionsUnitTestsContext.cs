using Missions.API.Mock.Shared.Data.Adapters;
using Missions.API.Mock.Shared.Data.Models;
using Missions.API.Mock.Shared.States;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Tests.Unit
{
    /// <summary>
    /// Class for generating mocks, for Unit tests.
    /// </summary>
    public class MissionsUnitTestsContext
    {
        public Mock<IMissionsDbAdapter> CreateMockIMissionsDbAdapter()
        {
            var mock = new Mock<IMissionsDbAdapter>();

            // Create
            mock.Setup
            (
                m => m.Create(It.Is<Mission>(m => IsMissionValidForCreate(m)))
            )
            .Returns
            (
                Task.FromResult(true)
            );

            mock.Setup
            (
                m => m.Create(It.Is<Mission>(m => !IsMissionValidForCreate(m)))
            )
            .Returns
            (
                Task.FromResult(false)
            );

            // Read
            mock.Setup
            (
                m => m.Read(It.Is<int>(m => m >= 0))
            )
            .Returns
            (
                Task.FromResult(GetAValidMission())
            );

            mock.Setup
            (
                m => m.Read(It.Is<int>(m => m < 0))
            )
            .Returns
            (
                Task.FromResult<Mission>(null)
            );

            // ReadAll
            mock.Setup
            (
                m => m.ReadAll()
            )
            .Returns
            (
                Task.FromResult(new Mission[] { GetAValidMission(), GetAValidMission() })
            );

            // Delete
            mock.Setup
            (
                m => m.Delete(It.Is<int>(m => m >= 0))
            )
            .Returns
            (
                Task.FromResult(true)
            );

            mock.Setup
            (
                m => m.Delete(It.Is<int>(m => m < 0))
            )
            .Returns
            (
                Task.FromResult(false)
            );

            // Update
            mock.Setup
            (
                m => m.Update(It.Is<Mission>(m => IsMissionValidForUpdate(m)))
            )
            .Returns
            (
                Task.FromResult(true)
            );

            mock.Setup
            (
                m => m.Update(It.Is<Mission>(m => !IsMissionValidForUpdate(m)))
            )
            .Returns
            (
                Task.FromResult(false)
            );

            return mock;
        }

        private bool IsMissionValidForCreate(Mission m) => !string.IsNullOrEmpty(m.Title) && !string.IsNullOrEmpty(m.Description) && m.Type.HasValue && m.State.HasValue;

        public Mission GetAValidMission(int? missionId = null) => new()
        {
            MissionId = missionId,
            Title = "It's a feature",
            Description = "Not a bug.",
            Type = EMissionType.Bug,
            State = API.Mock.Shared.States.EMissionStateType.New,
            UserAssignee = 1,
            UserAuthor = 1
        };

        private bool IsMissionValidForUpdate(Mission m) => m.MissionId.HasValue && (!string.IsNullOrEmpty(m.Title) || !string.IsNullOrEmpty(m.Description) || m.Type.HasValue || m.State.HasValue);

        public Mock<MissionState> CreateMockMissionState()
        {
            var mock = new Mock<MissionState>();

            // FinishMission
            mock.Setup
            (
                m => m.FinishMission()
            )
            .Returns
            (
                Task.FromResult(true)
            );

            mock.Setup
            (
                m => m.MoveToNextStep()
            )
            .Returns
            (
                Task.FromResult(true)
            );

            mock.Setup
            (
                m => m.MoveToPreviousStep()
            )
            .Returns
            (
                Task.FromResult(true)
            );

            mock.Setup
            (
                m => m.ResetMission()
            )
            .Returns
            (
                Task.FromResult(true)
            );

            return mock;
        }
    }
}
