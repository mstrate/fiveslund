namespace Strate.Common
{
    /// <summary>
    ///     Provides an interface to classes that serve as configuration stores.
    /// </summary>
    public interface IReadOnlySettingsStore
    {
        /// <summary>
        ///     Gets the value of a setting given its key.
        /// </summary>
        /// <param name="key">Key of the app setting.</param>
        /// <returns>The value of the setting.</returns>
        string GetSetting(string key);
    }
}
