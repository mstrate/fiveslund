using Strate.Common;
using Strate.Demo.Persistence;
using Strate.Demo.Processing;
using Strate.Demo.Worker;

namespace Strate.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobContext = new JobContext(new BasicReadOnlyConfigurationManager(new AppSettingsSettingStore()));
            var worker = new JobWorker(
                jobContext,
                new[]
                {
                    new ModifyJobProcessor()
                });
            worker.DoWork();
        }
    }
}
