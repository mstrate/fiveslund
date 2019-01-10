using System;
using System.Collections.Generic;
using System.Linq;
using Strate.Demo.Common;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Provides methods for interacting with a repository.
    /// </summary>
    /// <typeparam name="TType">The type of the entities in the repository.</typeparam>
    public class Repository<TType> : IRepository<TType>
    {
        private IList<TType> entities;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{TType}"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context used to interact with a data store.</param>
        public Repository(IRepositoryContext<TType> repositoryContext)
        {
            repositoryContext.ShouldNotBeNull(nameof(repositoryContext));

            this.RepositoryContext = repositoryContext;
            this.entities = this.RepositoryContext.ReadData().ToList();
        }

        /// <summary>
        ///     The repository context used to interact with the underlying data store.
        /// </summary>
        protected IRepositoryContext<TType> RepositoryContext { get; }

        /// <summary>
        ///     Gets all of the entities in the repository.
        /// </summary>
        /// <returns>An enumeration of all entities in the repository.</returns>
        public IEnumerable<TType> GetAll()
        {
            return this.entities;
        }

        /// <summary>
        ///     Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Add(TType entity)
        {
            this.entities.Add(entity);
        }

        /// <summary>
        ///     A method to filter the entities in the repository
        ///     according to the provided predicate.
        /// </summary>
        /// <param name="predicateExpression">The predicate used to filter the entities.</param>
        /// <returns>An enumeration of entities that conform to the provided predicate.</returns>
        public IEnumerable<TType> Where(Func<TType, bool> predicateExpression)
        {
            return this.entities.Where(predicateExpression).ToList();
        }
    }
}
