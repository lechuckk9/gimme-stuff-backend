using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Missions.Common.Lib.Data.Adapters
{
    /// <summary>
    /// Base database adapter, for supporting CRUD on generic types.
    /// </summary>
    public interface IBaseDbAdapter
    {
        /// <summary>
        /// Creates a new element.
        /// </summary>
        /// <param name="id">Created <see cref="T"/> object.</param>
        /// <returns></returns>
        bool Insert(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Returns the requested object.
        /// </summary>
        /// <param name="id">Requested <see cref="T"/> object's id.</param>
        /// <returns></returns>
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Reads all elements.
        /// </summary>
        /// <returns>Array of <see cref="T"/> objects.</returns>
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="id">Requested <see cref="T"/> object's data.</param>
        /// <returns></returns>
        bool Update(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Executes the query; eg. Delete.
        /// </summary>
        /// <param name="id">Requested <see cref="T"/> object's data.</param>
        /// <returns></returns>
        bool Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        /// <summary>
        /// Gets database connection.
        /// </summary>
        /// <returns></returns>
        DbConnection GetDbconnection();
    }
}
