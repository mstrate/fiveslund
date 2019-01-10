namespace Strate.Demo.Processing
{
    public interface IProcessor<TType>
    {
        void Process(TType entity);
    }
}
