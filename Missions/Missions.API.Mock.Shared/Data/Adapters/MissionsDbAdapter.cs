using Dapper;
using Missions.API.Mock.Shared.Data.Models;
using Missions.Common.Lib.Data.Adapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.API.Mock.Shared.Data.Adapters
{
    /// <inheritdoc/>
    public class MissionsDbAdapter : IMissionsDbAdapter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="baseDbAdapter"></param>
        public MissionsDbAdapter(IBaseDbAdapter baseDbAdapter)
        {
            _baseDbAdapter = baseDbAdapter;
        }

        /// <inheritdoc/>
        async Task<bool> IMissionsDbAdapter.Create(Mission mission)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("Title", mission.Title, DbType.String);
            dbParams.Add("Description", mission.Description, DbType.String);
            dbParams.Add("Type", mission.Type, DbType.Int32);
            dbParams.Add("State", mission.State, DbType.Int32);
            dbParams.Add("UserAssignee", mission.UserAssignee, DbType.Int32);
            dbParams.Add("UserAuthor", mission.UserAuthor, DbType.Int32);

            string command = @"
INSERT INTO Mission (Title, Description, Type, State, UserAssignee, UserAuthor)
VALUES (@Title, @Description, @Type, @State, @UserAssignee, @UserAuthor)
";

            return await Task.FromResult(_baseDbAdapter.Insert(command, dbParams, commandType: CommandType.Text));
        }

        /// <inheritdoc/>
        async Task<Mission> IMissionsDbAdapter.Read(int missionId)
        {
            var result = await Task.FromResult(_baseDbAdapter.Get<Mission>($"SELECT * FROM Mission WHERE MissionId={missionId}", null, commandType: CommandType.Text));
            return result;
        }

        /// <inheritdoc/>
        async Task<Mission[]> IMissionsDbAdapter.ReadAll()
        {
            var result = await Task.FromResult(_baseDbAdapter.GetAll<Mission>($"SELECT * FROM Mission", null, commandType: CommandType.Text));
            return result.ToArray();
        }

        /// <inheritdoc/>
        async Task<bool> IMissionsDbAdapter.Update(Mission mission)
        {
            string updateSql = string.Empty;
            var dbParams = new DynamicParameters();
            if (!string.IsNullOrEmpty(mission.Title))
            {
                dbParams.Add("Title", mission.Title, DbType.String);
                updateSql += "Title=@Title,";
            }

            if (!string.IsNullOrEmpty(mission.Description))
            {
                dbParams.Add("Description", mission.Description, DbType.String);
                updateSql += "Description=@Description,";
            }

            if (mission.Type.HasValue)
            {
                dbParams.Add("Type", mission.Type, DbType.Int32);
                updateSql += "Type=@Type,";
            }

            if (mission.State.HasValue)
            {
                dbParams.Add("State", mission.State, DbType.Int32);
                updateSql += "State=@State,";
            }

            if (mission.UserAssignee.HasValue)
            {
                dbParams.Add("UserAssignee", mission.UserAssignee, DbType.Int32);
                updateSql += "UserAssignee=@UserAssignee,";
            }

            if (mission.UserAuthor.HasValue)
            {
                dbParams.Add("UserAuthor", mission.UserAuthor, DbType.Int32);
                updateSql += "UserAuthor=@UserAuthor,";
            }

            if (string.IsNullOrEmpty(updateSql))
            {
                return false;
            }

            string command = $@"
UPDATE Mission SET {updateSql.Remove(updateSql.Length - 1)}
WHERE MissionId = {mission.MissionId}
";

            var result = await Task.FromResult(_baseDbAdapter.Update(command, dbParams, commandType: CommandType.Text));
            return result;
        }

        /// <inheritdoc/>
        async Task<bool> IMissionsDbAdapter.Delete(int missionId)
        {
            var result = await Task.FromResult(_baseDbAdapter.Execute($"DELETE FROM Mission WHERE MissionId={missionId}", null, commandType: CommandType.Text));
            return result;
        }

        #region Fields
        private IBaseDbAdapter _baseDbAdapter;
        #endregion
    }
}
