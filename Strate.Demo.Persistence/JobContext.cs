using System.Collections.Generic;
using Strate.Demo.Common;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    public class JobContext : IJobContext
    {
        private readonly IRepositoryContext<Job> sourceRepositoryContext;
        private readonly IRepositoryContext<Job> destinationRepositoryContext;
        private readonly ILogger logger;

        public JobContext(IReadOnlyConfigurationManager readOnlyConfigurationManager)
        {
            readOnlyConfigurationManager.ShouldNotBeNull(nameof(readOnlyConfigurationManager));

            readOnlyConfigurationManager.ShouldContainSettings(JobContext.RequiredSettings);

            var sourceRepositoryContextFilePath =  readOnlyConfigurationManager
                .GetSetting(Constants.SettingsKeys.SourceDataFilePath.ToString());

            var destinationRepositoryContextFilePath = readOnlyConfigurationManager
                .GetSetting(Constants.SettingsKeys.DestinationDataFilePath.ToString());

            var loggingFilePath = readOnlyConfigurationManager
                .GetSetting(Constants.SettingsKeys.LoggingFilePath.ToString());

            this.logger = new FileLogger(loggingFilePath);
            this.sourceRepositoryContext = new FileRepositoryContext(sourceRepositoryContextFilePath, logger);
            this.destinationRepositoryContext = new FileRepositoryContext(destinationRepositoryContextFilePath, logger);

            this.SourceRepository = new JobRepository(this.sourceRepositoryContext);
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

        public IJobRepository SourceRepository { get; }

        public IJobRepository DestinationRepository { get; }

        public void SaveChanges()
        {
            this.sourceRepositoryContext.WriteData(this.SourceRepository.GetAll());
            this.destinationRepositoryContext.WriteData(this.DestinationRepository.GetAll());
        }
    }
}
