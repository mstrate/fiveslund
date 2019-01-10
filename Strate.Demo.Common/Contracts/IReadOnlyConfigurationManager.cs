using System.Collections.Generic;

namespace Strate.Demo.Common
{
    public interface IReadOnlyConfigurationManager
    {
        /// <summary>
        ///     Gets the value of a setting given its key.
        /// </summary>
        /// <param name="key">Name of the app setting.</param>
        /// <returns>The value of the setting.</returns>
        string GetSetting(string key);

        void ShouldContainSettings(IEnumerable<object> requiredSettings);

        T GetSetting<T>(object key);
    }
}
