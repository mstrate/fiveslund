using System;

namespace Strate.Demo.Data
{
    /// <summary>
    ///     The Job entity for use in processing.
    /// </summary>
    public class Job
    {
        /// <summary>
        ///     The identifier of the Job.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     The current Job processing status.
        /// </summary>
        public ProcessingStatus Status { get; set; }

        /// <summary>
        ///     The date the Job was created.
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        ///     The date the Job was modified.
        /// </summary>
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
