using System;
using System.Collections.Generic;

namespace Strate.Demo.Persistence
{
    public interface IRepository<TType>
    {
        IEnumerable<TType> GetAll();

        void Add(TType entity);

        void Remove(TType entity);

        IEnumerable<TType> Where(Func<TType, bool> predicateExpression);
    }
}