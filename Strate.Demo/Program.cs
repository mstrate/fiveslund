using Strate.Demo.Common;
using Strate.Demo.Persistence;
using Strate.Demo.Processing;
using Strate.Demo.Worker;

namespace Strate.Demo
{
    /// <summary>
    ///     The entry point into the Strate.Demo application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var jobProcessingContext = new JobProcessingContext(new BasicReadOnlyConfigurationManager(new AppSettingsSettingStore()));
            var worker = new JobWorker(
                jobProcessingContext,
                new[] { new ModifyJobProcessor() });
            worker.DoWorkAsync().GetAwaiter().GetResult();
        }
    }
}
