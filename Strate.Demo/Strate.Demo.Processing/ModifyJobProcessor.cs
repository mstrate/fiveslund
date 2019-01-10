using System;
using Strate.Demo.Data;

namespace Strate.Demo.Processing
{
    public class ModifyJobProcessor : IProcessor<Job>
    {
        public void Process(Job entity)
        {
            entity.ModifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
