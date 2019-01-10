using System;
using System.IO;

using Newtonsoft.Json;

namespace Strate.Common
{
    public class FileLogger : ILogger
    {
        private readonly string fileName;

        public FileLogger(string fileName)
        {
            fileName.ShouldNotBeNullEmptyOrWhiteSpace(nameof(fileName));

            this.fileName = fileName;
        }

        public void LogError(Exception exception, string message)
        {
            var logEntry = new
            {
                Exception = exception.ToString(),
                Message = message,
                DateTime = DateTimeOffset.UtcNow.ToString()
            };

            File.AppendAllText(this.fileName, JsonConvert.SerializeObject(logEntry, Formatting.None) + Environment.NewLine);
        }
    }
}
