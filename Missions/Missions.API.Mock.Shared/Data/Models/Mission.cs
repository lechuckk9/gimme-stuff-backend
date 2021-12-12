using Missions.API.Mock.Shared.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.Data.Models
{
    /// <summary>
    /// Mission DTO.
    /// </summary>
    [DataContract]
    public class Mission
    {
        /// <summary>
        /// Mission's id.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? MissionId { get; set; }

        /// <summary>
        /// Task's type.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EMissionType Type { get; set; }

        /// <summary>
        /// Task's name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        /// <summary>
        /// Task's description.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        /// <summary>
        /// Task's state.
        /// </summary>
        [DataMember(IsRequired = false)]
        public EMissionStateType State { get; set; } = EMissionStateType.New;

        /// <summary>
        /// Task's assignee.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? UserAsignee { get; set; }

        /// <summary>
        /// Task's author.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? UserAuthor { get; set; }
    }
}
