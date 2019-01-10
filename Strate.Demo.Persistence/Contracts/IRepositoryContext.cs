using System.Collections.Generic;

namespace Strate.Demo.Persistence
{
    public interface IRepositoryContext<TType>
    {
        IEnumerable<TType> ReadData();

        void WriteData(IEnumerable<TType> data);
    }
}