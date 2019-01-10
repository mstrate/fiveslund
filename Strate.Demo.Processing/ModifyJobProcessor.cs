using System;
using Strate.Demo.Data;

namespace Strate.Demo.Processing
{
    /// <summary>
    ///     Provides methods to modify a <see cref="Job"/>.
    /// </summary>
    public class ModifyJobProcessor : IProcessor<Job>
    {
        /// <summary>
        ///     Processes the provided <see cref="Job"/> entity.
        /// </summary>
        /// <param name="entity">The job entity to process.</param>
        public void Process(Job entity)
        {
            entity.ModifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
