using System.Collections.Generic;
using System.Linq;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(IRepositoryContext<Job> repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Job> GetUnprocessedJobs()
        {
            return this.Where(job => job.Status != ProcessingStatus.Complete).ToList();
        }
    }
}
