using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missions.Common.Lib.Data.Adapters
{
    /// <summary>
    /// Base database adapter, for supporting CRUD on generic types.
    /// </summary>
    public interface IBaseDbAdapter<T>
    {
        /// <summary>
        /// Creates a new element.
        /// </summary>
        /// <param name="id">Created <see cref="T"/> object.</param>
        /// <returns></returns>
        public T Create(T data);

        /// <summary>
        /// Returns the requested object.
        /// </summary>
        /// <param name="id">Requested <see cref="T"/> object's id.</param>
        /// <returns></returns>
        public T Read(int id);

        /// <summary>
        /// Reads all elements.
        /// </summary>
        /// <returns>Array of <see cref="T"/> objects.</returns>
        public T[] ReadAll();

        /// <summary>
        /// Updates the element.
        /// </summary>
        /// <param name="id">Requested <see cref="T"/> object's data.</param>
        /// <returns></returns>
        public T Update(T data);

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <returns>Action's success indicator.</returns>
        public bool Delete(int id);
    }
}
