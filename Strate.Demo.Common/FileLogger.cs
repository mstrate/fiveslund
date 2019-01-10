using System;
using System.IO;

using Newtonsoft.Json;

namespace Strate.Demo.Common
{
    /// <summary>
    ///     Provides methods for logging.
    /// </summary>
    public class FileLogger : ILogger
    {
        private readonly string fileName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="fileName">The name of the file to log to.</param>
        public FileLogger(string fileName)
        {
            fileName.ShouldNotBeNullEmptyOrWhiteSpace(nameof(fileName));

            this.fileName = fileName;
        }

        /// <summary>
        ///     Logs and exception along with an error message.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The message to log.</param>
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
