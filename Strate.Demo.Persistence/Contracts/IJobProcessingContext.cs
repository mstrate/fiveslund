namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Represents the context within which <see cref="Job"/> processing
    ///     takes place.
    /// </summary>
    public interface IJobProcessingContext
    {
        /// <summary>
        ///     The repository containing the source data.
        /// </summary>
        IJobRepository SourceRepository { get; }

        /// <summary>
        ///     The repository containing the destination data.
        /// </summary>
        IJobRepository DestinationRepository { get; }

        /// <summary>
        ///     Saves all the changes for the current operation.
        /// </summary>
        void SaveChanges();
    }
}
