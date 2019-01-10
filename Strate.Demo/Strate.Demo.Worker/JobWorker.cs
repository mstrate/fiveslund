using System;
using System.Collections.Generic;
using System.Linq;
using Strate.Common;
using Strate.Demo.Data;
using Strate.Demo.Persistence;
using Strate.Demo.Processing;

namespace Strate.Demo.Worker
{
    public class JobWorker
    {
        private readonly IJobContext jobContext;
        private readonly IEnumerable<IProcessor<Job>> processors;

        public JobWorker(
            IJobContext jobContext,
            IEnumerable<IProcessor<Job>> processors
            )
        {
            jobContext.ShouldNotBeNull(nameof(jobContext));
            processors.ShouldNotBeNullOrEmpty(nameof(processors));

            this.jobContext = jobContext;
            this.processors = processors;

            // make sure there are some jobs to process (obviously would not do this
            // in a real-world scenario
            this.EnsureUnprocessedJobs();
        }

        public void DoWork()
        {
            var jobs = this.jobContext.SourceRepository.GetUnprocessedJobs();

            foreach (var job in jobs)
            {
                foreach (var processor in this.processors)
                {
                    processor.Process(job);
                }
                job.Status = ProcessingStatus.Complete;
                this.jobContext.DestinationRepository.Add(job);
                this.jobContext.SaveChanges();
            }
        }

        private void EnsureUnprocessedJobs()
        {
            var jobs = this.jobContext.SourceRepository.GetUnprocessedJobs();

            if (!jobs.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var newJob = new Job
                    {
                        CreatedDate = DateTimeOffset.UtcNow,
                        ModifiedDate = DateTimeOffset.UtcNow,
                        Id = Guid.NewGuid(),
                        Status = ProcessingStatus.Pending
                    };

                    this.jobContext.SourceRepository.Add(newJob);
                }
                this.jobContext.SaveChanges();
            }
        }
    }
}
