using System;
using System.Collections.Generic;
using System.Linq;
using Strate.Common;

namespace Strate.Demo.Persistence
{
    public class Repository<TType> : IRepository<TType>
    {
        private IList<TType> entities;

        public Repository(IRepositoryContext<TType> repositoryContext)
        {
            repositoryContext.ShouldNotBeNull(nameof(repositoryContext));

            this.RepositoryContext = repositoryContext;
            this.entities = this.RepositoryContext.ReadData().ToList();
        }

        protected IRepositoryContext<TType> RepositoryContext { get; }

        public IEnumerable<TType> GetAll()
        {
            return this.entities;
        }

        public void Add(TType entity)
        {
            this.entities.Add(entity);
        }

        public void Remove(TType entity)
        {
            this.entities.Remove(entity);
        }

        public IEnumerable<TType> Where(Func<TType, bool> predicateExpression)
        {
            return this.entities.Where(predicateExpression).ToList();
        }
    }
}
