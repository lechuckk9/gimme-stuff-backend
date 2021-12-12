using Missions.API.Mock.Shared.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.Data.Adapters
{
    /// <summary>
    /// Missions database adapter.
    /// </summary>
    internal interface IMissionsDbAdapter
    {
        internal bool Create(Mission mission);
        internal Mission Read(int missionId);
        internal Mission[] ReadAll();
        internal Mission Update(Mission mission);
        internal bool Delete(Mission mission);
    }
}
