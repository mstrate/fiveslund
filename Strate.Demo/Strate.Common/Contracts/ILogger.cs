using System;

namespace Strate.Common
{
    public interface ILogger
    {
        void LogError(Exception exception, string message);
    }
}
