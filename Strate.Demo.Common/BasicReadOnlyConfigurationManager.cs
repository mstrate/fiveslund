﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Strate.Demo.Common
{
    /// <summary>
    ///     Provides methods for accessing configuration data
    ///     in a readonly manner.
    /// </summary>
    public class BasicReadOnlyConfigurationManager : IReadOnlyConfigurationManager
    {
        private readonly IReadOnlySettingsStore settingsStore;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BasicReadOnlyConfigurationManager"/> class.
        /// </summary>
        /// <param name="settingsStore">The settings store to access.</param>
        public BasicReadOnlyConfigurationManager(IReadOnlySettingsStore settingsStore)
        {
            settingsStore.ShouldNotBeNull(nameof(settingsStore));
            this.settingsStore = settingsStore;
        }

        /// <summary>
        ///     Gets the value of a setting given its key.
        /// </summary>
        /// <param name="key">Name of the setting.</param>
        /// <returns>The value of the setting.</returns>
        public string GetSetting(string key)
        {
            key.ShouldNotBeNullEmptyOrWhiteSpace(nameof(key));

            return this.settingsStore.GetSetting(key);
        }

        /// <summary>
        ///     Helps validate that all the required settings are in place. Typically during construction.
        /// </summary>
        /// <param name="requiredSettings">Enumeration of the required settings.</param>
        public void ShouldContainSettings(IEnumerable<object> requiredSettings)
        {
            var requiredSettingsAsString =
                requiredSettings as IEnumerable<string>
                ?? requiredSettings.Select(s => s.ToString());

            var listOfMissingSettings = new List<string>();

            foreach (var requiredSetting in requiredSettingsAsString)
            {
                if (string.IsNullOrEmpty(this.GetSetting(requiredSetting)))
                {
                    listOfMissingSettings.Add(requiredSetting);
                }
            }

            if (listOfMissingSettings.Any())
            {
                throw new ArgumentException(ConstructMissingSettingsMessage(listOfMissingSettings));
            }
        }

        private static string ConstructMissingSettingsMessage(IEnumerable<string> missingRequiredSettings)
        {
            var requiredSettings = missingRequiredSettings as string[] ?? missingRequiredSettings.ToArray();

            return requiredSettings.Length == 1
                ? $"The following setting is required but is missing from the settings source: {requiredSettings.First()}"
                : $"The following settings are required and not found in the settings source: {string.Join(",", requiredSettings)}";
        }
    }
}
