using System.Collections.Generic;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Provides <see cref="Job"/> specific repository methods.
    /// </summary>
    public interface IJobRepository : IRepository<Job>
    {
        /// <summary>
        ///     Gets all of the unprocessed jobs from the
        ///     current repository.
        /// </summary>
        /// <returns>An enumeration of unprocessed <see cref="Job"/>s.</returns>
        IEnumerable<Job> GetUnprocessedJobs();
    }
}