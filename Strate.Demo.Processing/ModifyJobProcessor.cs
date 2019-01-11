using System;
using System.Threading.Tasks;
using Strate.Demo.Data;

namespace Strate.Demo.Processing
{
    /// <summary>
    ///     Provides methods to modify a <see cref="Job"/>.
    /// </summary>
    public class ModifyJobProcessor : IProcessor<Job>
    {
        /// <summary>
        ///     Processes the provided <see cref="Job"/> entity.
        /// </summary>
        /// <param name="entity">The job entity to process.</param>
        /// <returns>A <see cref="Task"/> that represents the status of the operation.</returns>
        public Task ProcessAsync(Job entity)
        {
            entity.ModifiedDate = DateTimeOffset.UtcNow;
            return Task.CompletedTask;
        }
    }
}
