using Missions.API.Mock.Shared.Data.Models;
using Missions.Common.Lib.Data.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.Data.Adapters
{
    /// <inheritdoc/>
    internal class MissionsDbAdapter : IMissionsDbAdapter
    {
        /// <inheritdoc/>
        bool IMissionsDbAdapter.Create(Mission mission)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        bool IMissionsDbAdapter.Delete(Mission mission)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        Mission IMissionsDbAdapter.Read(int missionId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        Mission[] IMissionsDbAdapter.ReadAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        Mission IMissionsDbAdapter.Update(Mission mission)
        {
            throw new NotImplementedException();
        }

        #region Fields
        private BaseDbAdapter<Mission> baseDbAdapter;
        #endregion
    }
}
