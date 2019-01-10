using System.Collections.Generic;
using System.Linq;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Provides <see cref="Job"/> specific methods for interacting with a repository.
    /// </summary>
    public class JobRepository : Repository<Job>, IJobRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JobRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public JobRepository(IRepositoryContext<Job> repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <summary>
        ///     Gets all of the unprocessed jobs from the
        ///     current repository.
        /// </summary>
        /// <returns>An enumeration of unprocessed <see cref="Job"/>s.</returns>
        public IEnumerable<Job> GetUnprocessedJobs()
        {
            return this.Where(job => job.Status != ProcessingStatus.Complete).ToList();
        }
    }
}
