namespace Strate.Demo.Persistence
{
    public interface IJobContext
    {
        IJobRepository SourceRepository { get; }

        IJobRepository DestinationRepository { get; }

        void SaveChanges();
    }
}
