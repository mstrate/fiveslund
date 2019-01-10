using System.Collections.Generic;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> GetUnprocessedJobs();
    }
}