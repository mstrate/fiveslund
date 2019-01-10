using System;

namespace Strate.Demo.Data
{
    public class Job
    {
        public Guid Id { get; set; }

        public ProcessingStatus Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }
    }
}
