using System.Collections.Generic;

namespace Strate.Demo.Common
{
    /// <summary>
    ///     Provides methods for accessing configuration data
    ///     in a readonly manner.
    /// </summary>
    public interface IReadOnlyConfigurationManager
    {
        /// <summary>
        ///     Gets the value of a setting given its key.
        /// </summary>
        /// <param name="key">Name of the setting.</param>
        /// <returns>The value of the setting.</returns>
        string GetSetting(string key);

        /// <summary>
        ///     Helps validate that all the required settings are in place. Typically during construction.
        /// </summary>
        /// <param name="requiredSettings">Enumeration of the required settings.</param>
        void ShouldContainSettings(IEnumerable<object> requiredSettings);
    }
}
