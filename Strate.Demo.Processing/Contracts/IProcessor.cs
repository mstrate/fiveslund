using System.Threading.Tasks;

namespace Strate.Demo.Processing
{
    /// <summary>
    ///     Provides methods for processing an entity.
    /// </summary>
    /// <typeparam name="TType">The type of entity to process.</typeparam>
    public interface IProcessor<TType>
    {
        /// <summary>
        ///     Processes the provided entity.
        /// </summary>
        /// <param name="entity">The entity to process.</param>
        /// <returns>A <see cref="Task"/> that represents the status of the operation.</returns>
        Task ProcessAsync(TType entity);
    }
}
