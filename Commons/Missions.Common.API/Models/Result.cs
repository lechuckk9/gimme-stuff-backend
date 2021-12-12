using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.Common.API.Models
{
    /// <summary>
    /// Result DTO.
    /// </summary>
    public abstract class Result
    {
        /// <summary>
        /// </summary>
        /// <param name="error"></param>
        public Result(Exception error)
        {
            Error = error;
        }

        #region Properties
        /// <summary>
        /// Check if error is null
        /// </summary>
        public bool Success => Error == null;

        /// <summary>
        /// Check if error is not null
        /// </summary>
        public bool Failed => !Success;

        /// <summary>
        /// Result's exception.
        /// </summary>
        public Exception Error { get; }
        #endregion
    }

    public class Result<T> : Result
    {
        /// <summary>
        /// Constructor for a successful result.
        /// </summary>
        /// <param name="error"></param>
        public Result(T data) : base(null)
        {
            Data = data;
        }

        /// <summary>
        /// Constructor for a failed result.
        /// </summary>
        /// <param name="error"></param>
        public Result(Exception error) : base(error) { }

        /// <summary>
        /// Constructor a typed failed result.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="error">error information</param>
        public Result(T data, Exception error) : base(error ?? throw new Exception("Error's object was not provided."))
        {
            Data = data;
        }

        #region Static methods
        /// <summary>
        /// Creates a successful result.
        /// </summary>
        /// <param name="data">Typed data</param>
        /// <returns></returns>
        public static Result<T> AsSuccess(T data) => new(data);

        /// <summary>
        /// Creates a failed result.
        /// </summary>
        /// <param name="exception">Exception object</param>
        /// <returns></returns>
        public static Result<T> AsFail(Exception exception) => new(exception);

        /// <summary>
        /// Creates a typed failed result.
        /// </summary>
        /// <param name="data">Typed data</param>
        /// <param name="exception">Exception object</param>
        /// <returns></returns>
        public static Result<T> AsFail(T data, Exception exception) => new(data, exception);
        #endregion

        #region Properties
        /// <summary>
        /// Result's typed data.
        /// </summary>
        public T Data { get; }
        #endregion
    }
}
