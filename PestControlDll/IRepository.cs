using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControlDll
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Creates provided object
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Create(T t);
        /// <summary>
        /// Gets the specified object from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Read(int id);
        /// <summary>
        /// Gets all the objects from the database
        /// </summary>
        /// <returns></returns>
        List<T> Read();
        /// <summary>
        /// Updates provided update
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update(T t);
        bool Delete(int id);
    }
}
