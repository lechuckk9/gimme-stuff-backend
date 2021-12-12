using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.Common.Lib.Exceptions
{
    public class ExceptionBase : Exception
    {
        /// <summary>
        /// Constructor for error number and message.
        /// </summary>
        public ExceptionBase(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Exception's error code - reference for <see cref="Common.Resources.Exceptions"/> resource files.
        /// </summary>
        public int ErrorCode { get; }
    }
}
