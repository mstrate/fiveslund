using System.Threading.Tasks;

namespace Strate.Demo.Worker
{
    /// <summary>
    ///     Provides methods for doing work.
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        ///     Method to do work.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the status of the operation.</returns>
        Task DoWorkAsync();
    }
}
