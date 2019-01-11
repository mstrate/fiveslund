using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Strate.Demo.Common;
using Strate.Demo.Data;
using Strate.Demo.Persistence;
using Strate.Demo.Processing;

namespace Strate.Demo.Worker
{
    /// <summary>
    ///     Provides methods for doing work on <see cref="Job"/> entities.
    /// </summary>
    public class JobWorker : IWorker
    {
        private readonly IJobProcessingContext jobProcessingContext;
        private readonly IEnumerable<IProcessor<Job>> processors;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JobWorker"/> class.
        /// </summary>
        /// <param name="jobProcessingContext">The job processing context.</param>
        /// <param name="processors">The processors used to process jobs.</param>
        public JobWorker(
            IJobProcessingContext jobProcessingContext,
            IEnumerable<IProcessor<Job>> processors
            )
        {
            jobProcessingContext.ShouldNotBeNull(nameof(jobProcessingContext));
            processors.ShouldNotBeNullOrEmpty(nameof(processors));

            this.jobProcessingContext = jobProcessingContext;
            this.processors = processors;

            // make sure there are some jobs to process (obviously would not do this
            // in a real-world scenario)
            this.EnsureUnprocessedJobs();
        }

        /// <summary>
        ///     Processes all of the unprocessed <see cref="Job"/> entities.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the status of the operation.</returns>
        public async Task DoWorkAsync()
        {
            var jobs = this.jobProcessingContext.SourceRepository.GetUnprocessedJobs();

            var jobTasks = jobs.Select(job => this.ProcessJobAsync(job));

            await Task.WhenAll(jobTasks).ConfigureAwait(false);
        }

        private void EnsureUnprocessedJobs()
        {
            var jobs = this.jobProcessingContext.SourceRepository.GetUnprocessedJobs();

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

                    this.jobProcessingContext.SourceRepository.Add(newJob);
                }
                this.jobProcessingContext.SaveChanges();
            }
        }

        private async Task ProcessJobAsync(Job job)
        {
            var processorTasks = this.processors.Select(processor => processor.ProcessAsync(job));

            await Task.WhenAll(processorTasks).ConfigureAwait(false);

            job.Status = ProcessingStatus.Complete;
            this.jobProcessingContext.DestinationRepository.Add(job);
            this.jobProcessingContext.SaveChanges();
        }
    }
}
