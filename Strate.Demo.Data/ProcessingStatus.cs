namespace Strate.Demo.Data
{
    /// <summary>
    ///     Represents the various stages of Job processing.
    /// </summary>
    public enum ProcessingStatus
    {
        /// <summary>
        ///     The default value.
        /// </summary>
        None,

        /// <summary>
        ///     Represents a Job in a pending state.
        /// </summary>
        Pending,

        /// <summary>
        ///     Represents a completed Job.
        /// </summary>
        Complete
    }
}
