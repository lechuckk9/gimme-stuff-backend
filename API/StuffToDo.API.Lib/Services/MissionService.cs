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

        public async Task<bool> Create(Mission mission)
        {
            return await _missionContainer.CreateNew(mission);
        }

        public async Task<bool> Delete(int missionId)
        {
            throw new NotImplementedException();
        }

        public async Task<Mission> Read(int missionId)
        {
            return await _missionContainer.Get(missionId);
        }

        public async Task<Mission[]> ReadAll()
        {
            return await _missionContainer.GetAll();
        }

        public async Task<Mission> Update(Mission mission)
        {
            throw new NotImplementedException();
        }

        #region Fields
        private IMissionContainer _missionContainer;
        #endregion
    }
}
