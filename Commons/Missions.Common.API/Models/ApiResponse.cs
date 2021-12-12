using Missions.Common.Lib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Missions.Common.API.Models
{
    /// <summary>
    /// Standard API response envelope.
    /// </summary>
    [DataContract]
    public class ApiResponse
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApiResponse() {}

        /// <summary>
        /// Constructor for exception response.
        /// </summary>
        public ApiResponse(Exception exception)
        {
            if (exception != null)
            {
                Message = exception.Message;
                Exception = exception;

                if (exception is ExceptionBase exceptionBase)
                {
                    ResultCode = exceptionBase.ErrorCode;
                }
                else
                {
                    ResultCode = -1;
                }
            }
        }

        #region Properties
        /// <summary>
        /// API result code - see the Error code numbers, in case of an error.
        /// 0 = success
        /// </summary>
        [DataMember(IsRequired = false)]
        public int ResultCode { get; set; }

        /// <summary>
        /// Additional response's information.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Exception.
        /// Not serialized in the response.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [JsonIgnore]
        public Exception Exception { get; set; }
        #endregion
    }

    /// <summary>
    /// Standard API response envelope.
    /// </summary>
    [DataContract]
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApiResponse() : base() {}

        /// <summary>
        /// Constructor for typed data response.
        /// </summary>
        public ApiResponse(T data) : base()
        {
            Data = data;
        }

        /// <summary>
        /// Constructor for exception response.
        /// </summary>
        public ApiResponse(Exception exception) : base(exception) {}

        /// <summary>
        /// Constructor for typed data with exception response.
        /// </summary>
        public ApiResponse(T data, Exception exception) : base(exception)
        {
            Data = data;
        }

        /// <summary>
        /// Constructor for <see cref="Result"/>.
        /// </summary>
        public ApiResponse(Result<T> result) : base(result.Error)
        {
            Data = result.Data;
        }

        #region Properties
        /// <summary>
        /// Response typed data.
        /// </summary>
        [DataMember]
        public T Data { get; set; }
        #endregion
    }


    /// <summary>
    /// Standard API response envelope.
    /// </summary>
    [DataContract]
    public class ApiResponsePage<T> : ApiResponse<T[]>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ApiResponsePage() : base() { }

        /// <summary>
        /// Constructor for typed data paged response.
        /// </summary>
        public ApiResponsePage(T[] data, Paging page) : base()
        {
            Data = data;
            Page = page;
        }

        #region Properties
        /// <summary>
        /// Response typed data.
        /// </summary>
        [DataMember]
        public T[] Data { get; set; }

        /// <summary>
        /// Response typed data.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public Paging Page { get; set; }
        #endregion

        /// <summary>
        /// Class for paginated responses.
        /// </summary>
        public class Paging
        {
            /// <summary>
            /// Count of returned items.
            /// </summary>
            public int Count { get; set; }

            /// <summary>
            /// Total count of items.
            /// </summary>
            public int TotalCount { get; set; }

            /// <summary>
            /// Current page number.
            /// </summary>
            public int Page { get; set; }

            /// <summary>
            /// Current page's size.
            /// </summary>
            public int PageSize { get; set; }
        }
    }
}
