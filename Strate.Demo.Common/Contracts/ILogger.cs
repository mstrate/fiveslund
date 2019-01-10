using System;

namespace Strate.Demo.Common
{
    public interface ILogger
    {
        void LogError(Exception exception, string message);
    }
}
