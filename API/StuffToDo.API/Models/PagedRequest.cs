using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StuffToDo.API.Models
{
    /// <summary>
    /// Class for paginated requests.
    /// </summary>
    [DataContract]
    public class PagedRequest
    {
        /// <summary>
        /// Current page number. Starts from and defaults to 0.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int Page { get; set; } = 0;

        /// <summary>
        /// Requested page size. Default is 10.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}
