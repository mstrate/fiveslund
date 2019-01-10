using System.Collections.Generic;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Provides methods to interact with a data store.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public interface IRepositoryContext<TType>
    {
        /// <summary>
        ///     Reads all the data from the data store.
        /// </summary>
        /// <returns>The data from the data store.</returns>
        IEnumerable<TType> ReadData();

        /// <summary>
        ///     Writes the provided data to the data store.
        /// </summary>
        /// <param name="data">The data to write to the data store.</param>
        void WriteData(IEnumerable<TType> data);
    }
}