namespace Strate.Demo.Persistence
{
    /// <summary>
    ///     Contains constants for use by the persistence layer.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        ///     Enum containing keys to settings configuration.
        /// </summary>
        public enum SettingsKeys
        {
            /// <summary>
            ///     The path to the logging file.
            /// </summary>
            LoggingFilePath,

            /// <summary>
            ///     The path to the source data file.
            /// </summary>
            SourceDataFilePath,

            /// <summary>
            ///     The path to the destination data file.
            /// </summary>
            DestinationDataFilePath,
        }
    }
}
