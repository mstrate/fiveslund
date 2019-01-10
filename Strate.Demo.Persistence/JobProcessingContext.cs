using System.Collections.Generic;
using Strate.Demo.Common;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Represents the context within which <see cref="Job"/> processing
    ///     takes place.
    /// </summary>
    public class JobProcessingContext : IJobProcessingContext
    {
        private readonly IRepositoryContext<Job> sourceRepositoryContext;
        private readonly IRepositoryContext<Job> destinationRepositoryContext;
        private readonly ILogger logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JobProcessingContext"/> class.
        /// </summary>
        /// <param name="readOnlyConfigurationManager">The readonly configuration manager.</param>
        public JobProcessingContext(IReadOnlyConfigurationManager readOnlyConfigurationManager)
        {
            readOnlyConfigurationManager.ShouldNotBeNull(nameof(readOnlyConfigurationManager));

            readOnlyConfigurationManager.ShouldContainSettings(JobProcessingContext.RequiredSettings);

            var loggingFilePath = readOnlyConfigurationManager
                .GetSetting(Constants.SettingsKeys.LoggingFilePath.ToString());
            this.logger = new FileLogger(loggingFilePath);

            var sourceRepositoryContextFilePath =  readOnlyConfigurationManager
                .GetSetting(Constants.SettingsKeys.SourceDataFilePath.ToString());
            this.sourceRepositoryContext = new FileRepositoryContext(sourceRepositoryContextFilePath, logger);
            this.SourceRepository = new JobRepository(this.sourceRepositoryContext);

            var destinationRepositoryContextFilePath = readOnlyConfigurationManager
                .GetSetting(Constants.SettingsKeys.DestinationDataFilePath.ToString());
            this.destinationRepositoryContext = new FileRepositoryContext(destinationRepositoryContextFilePath, logger);
            this.DestinationRepository = new JobRepository(this.destinationRepositoryContext);
        }

        private static IEnumerable<object> RequiredSettings
        {
            get
            {
                yield return Constants.SettingsKeys.LoggingFilePath;
                yield return Constants.SettingsKeys.SourceDataFilePath;
                yield return Constants.SettingsKeys.DestinationDataFilePath;
            }
        }

        /// <summary>
        ///     The repository containing the source data.
        /// </summary>
        public IJobRepository SourceRepository { get; }

        /// <summary>
        ///     The repository containg the destination data.
        /// </summary>
        public IJobRepository DestinationRepository { get; }

        /// <summary>
        ///     Saves all the changes for the current operation.
        /// </summary>
        public void SaveChanges()
        {
            this.sourceRepositoryContext.WriteData(this.SourceRepository.GetAll());
            this.destinationRepositoryContext.WriteData(this.DestinationRepository.GetAll());
        }
    }
}
