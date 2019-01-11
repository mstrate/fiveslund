using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using Strate.Demo.Common;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Provides methods to interact with a file data store.
    /// </summary>
    /// <seealso cref="IRepositoryContext{TType}"/>
    public class FileRepositoryContext : IRepositoryContext<Job>
    {
        private readonly string filePath;
        private readonly ILogger logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileRepositoryContext"/> class.
        /// </summary>
        /// <param name="filePath">The path to the repository file.</param>
        /// <param name="logger">The logger to use for logging.</param>
        public FileRepositoryContext(string filePath, ILogger logger)
        {
            filePath.ShouldNotBeNullEmptyOrWhiteSpace(nameof(filePath));
            logger.ShouldNotBeNull(nameof(logger));

            this.filePath = filePath;
            this.logger = logger;
        }

        /// <summary>
        ///     Reads all of the jobs from the file repository.
        /// </summary>
        /// <returns>An enumeration of all the <see cref="Job"/>s in the file.</returns>
        public IEnumerable<Job> ReadData()
        {
            if (!File.Exists(this.filePath))
            {
                return Enumerable.Empty<Job>();
            }

            var fileData = File.ReadAllText(this.filePath);

            try
            {
                var jobs = JsonConvert.DeserializeObject<Job[]>(fileData);
                return jobs;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, FormattableString.Invariant($"Exception thrown when deserializing {this.filePath}"));
                throw;
            }
        }

        /// <summary>
        ///     Writes all of the provided <see cref="Job"/>s to the file repository.
        /// </summary>
        /// <param name="data">The Jobs to write to the repository.</param>
        public void WriteData(IEnumerable<Job> data)
        {
            try
            {
                File.WriteAllText(this.filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, FormattableString.Invariant($"Exception thrown when serializing {this.filePath}"));
                throw;
            }
        }
    }
}
