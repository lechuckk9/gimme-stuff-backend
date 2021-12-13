using System;
using System.Threading.Tasks;
using Missions.API.Mock.Shared.Business;
using Missions.API.Mock.Shared.Data.Models;

namespace StuffToDo.API.Lib.Services
{
    public class MissionService : IMissionService
    {
        public MissionService(IMissionContainer missionContainer)
        {
            _missionContainer = missionContainer;
        }

        /// <inheritdoc/>
        public async Task<bool> Create(Mission mission)
        {
            return await _missionContainer.CreateNew(mission);
        }

        /// <inheritdoc/>
        public async Task<bool> Delete(int missionId)
        {
            return await _missionContainer.Delete(missionId);
        }

        /// <inheritdoc/>
        public async Task<Mission> Read(int missionId)
        {
            return await _missionContainer.Get(missionId);
        }

        /// <inheritdoc/>
        public async Task<Mission[]> ReadAll()
        {
            return await _missionContainer.GetAll();
        }

        /// <inheritdoc/>
        public async Task<bool> Update(Mission mission)
        {
            return await _missionContainer.Update(mission);
        }

        /// <inheritdoc/>
        public async Task<bool> ResetMission(int missionId)
        {
            _missionContainer.SetMission(missionId);
            return await _missionContainer.ResetMission();
        }

        /// <inheritdoc/>
        public async Task<bool> FinishMission(int missionId)
        {
            _missionContainer.SetMission(missionId);
            return await _missionContainer.FinishMission();
        }

        /// <inheritdoc/>
        public async Task<bool> MoveToPreviousStep(int missionId)
        {
            _missionContainer.SetMission(missionId);
            return await _missionContainer.MoveToPreviousStep();
        }

        /// <inheritdoc/>
        public async Task<bool> MoveToNextStep(int missionId)
        {
            _missionContainer.SetMission(missionId);
            return await _missionContainer.MoveToNextStep();
        }

        #region Fields
        private IMissionContainer _missionContainer;
        #endregion
    }
}
