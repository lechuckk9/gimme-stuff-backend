using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Missions.Common.Lib.Data.Adapters
{
    /// <inheritdoc/>
    public class BaseDbAdapter : IBaseDbAdapter
    {
        /// <inheritdoc/>
        public bool Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int result;
            using IDbConnection db = new SqlConnection(_ConnectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result > 0;
        }

        /// <inheritdoc/>
        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_ConnectionString);
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_ConnectionString);
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        /// <inheritdoc/>
        public bool Insert(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int result;
            using IDbConnection db = new SqlConnection(_ConnectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result > 0;
        }

        /// <inheritdoc/>
        public bool Update(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int result;
            using IDbConnection db = new SqlConnection(_ConnectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result > 0;
        }

        /// <inheritdoc/>
        public DbConnection GetDbconnection() => new SqlConnection(_ConnectionString);

        #region Fields
        // HACK load from appSettings
        const string _ConnectionString = "Server=188.121.44.217;Database=stuff_to_do;user id=todoadmin;password=odoffutsfoTolA12;persist security info=True;";
        #endregion
    }
}
