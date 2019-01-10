using System.Configuration;

namespace Strate.Demo.Common
{
    /// <summary>
    ///     Represents a class that serves configuration options from an
    ///     app.config file.
    /// </summary>
    public class AppSettingsSettingStore : IReadOnlySettingsStore
    {
        /// <summary>
        ///     Gets the value of a setting given its key.
        /// </summary>
        /// <param name="key">Key of the app setting.</param>
        /// <returns>The value of the setting.</returns>
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
