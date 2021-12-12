using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.Common.Lib.Data.Adapters
{
    /// <inheritdoc/>
    public class BaseDbAdapter<T> : IBaseDbAdapter<T>
    {
        // TODO how will T be handled and saved to db? - map with Dapper
        // TODO add sql command, transaction, etc.


        /// <inheritdoc
        public T Create(T data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc
        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc
        public T[] ReadAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc
        public T Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
