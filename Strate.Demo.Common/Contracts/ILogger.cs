using System;

namespace Strate.Demo.Common
{
    /// <summary>
    ///     Provides methods for logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        ///     Logs and exception along with an error message.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">The message to log.</param>
        void LogError(Exception exception, string message);
    }
}
