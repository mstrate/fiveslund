using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using Strate.Common;
using Strate.Demo.Data;

namespace Strate.Demo.Persistence
{
    public class FileRepositoryContext : IRepositoryContext<Job>
    {
        private readonly string fileName;
        private readonly ILogger logger;

        public FileRepositoryContext(string fileName, ILogger logger)
        {
            fileName.ShouldNotBeNullEmptyOrWhiteSpace(nameof(fileName));
            logger.ShouldNotBeNull(nameof(logger));

            this.fileName = fileName;
            this.logger = logger;
        }

        public IEnumerable<Job> ReadData()
        {
            if (!File.Exists(this.fileName))
            {
                return Enumerable.Empty<Job>();
            }

            var fileData = File.ReadAllText(this.fileName);

            try
            {
                var jobs = JsonConvert.DeserializeObject<Job[]>(fileData);
                return jobs;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, FormattableString.Invariant($"Exception thrown when deserializing {this.fileName}"));
                throw;
            }
        }

        public void WriteData(IEnumerable<Job> data)
        {
            try
            {
                File.WriteAllText(this.fileName, JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, FormattableString.Invariant($"Exception thrown when serializing {this.fileName}"));
                throw;
            }
        }
    }
}
