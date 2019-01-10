using System;
using System.Collections.Generic;

namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Provides methods to interact with a generic repository.
    /// </summary>
    /// <typeparam name="TType">The type of the entities in the repository.</typeparam>
    public interface IRepository<TType>
    {
        /// <summary>
        ///     Gets all of the entities in the repository.
        /// </summary>
        /// <returns>An enumeration of all entities in the repository.</returns>
        IEnumerable<TType> GetAll();

        /// <summary>
        ///     Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(TType entity);

        /// <summary>
        ///     A method to filter the entities in the repository
        ///     according to the provided predicate.
        /// </summary>
        /// <param name="predicateExpression">The predicate used to filter the entities.</param>
        /// <returns>An enumeration of entities that conform to the provided predicate.</returns>
        IEnumerable<TType> Where(Func<TType, bool> predicateExpression);
    }
}