// -----------------------------------------------------------------------
//  <copyright file="DebugConfigurationSource.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Configuration.Sources
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="ConfigurationSource" /> that can be used to programmatically
    /// populate settings in a <see cref="Configuration" /> .
    /// </summary>
    public class DebugConfigurationSource : ConfigurationSource
    {
        private readonly Dictionary<string, string> modifiedSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugConfigurationSource" /> class.
        /// </summary>
        public DebugConfigurationSource()
        {
            this.modifiedSettings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Populates all of this <see cref="ConfigurationSource" /> s settings in the registered <see cref="Configuration" /> .
        /// </summary>
        public override void UpdateConfiguration()
        {
            foreach (string key in this.modifiedSettings.Keys)
            {
                string value = this.modifiedSettings[key];
                base.TryAddOrUpdateSetting(key, value);
            }
        }

        /// <summary>
        /// Tries to add or update a setting in the registered <see cref="Configuration" /> .
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The new value for the setting.</param>
        /// <returns>False if the setting is locked.</returns>
        public new bool TryAddOrUpdateSetting(string name, string value)
        {
            if (base.TryAddOrUpdateSetting(name, value))
            {
                if (this.modifiedSettings.ContainsKey(name))
                {
                    this.modifiedSettings[name] = value;
                }
                else
                {
                    this.modifiedSettings.Add(name, value);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to lock the setting with the specified name.
        /// </summary>
        /// <param name="settingName">The name of the setting to lock.</param>
        /// <returns>True if the setting was successfully locked.</returns>
        public new bool TryLockSetting(string settingName)
        {
            return base.TryLockSetting(settingName);
        }

        /// <summary>
        /// Tries to unlock the setting with the specified name.
        /// </summary>
        /// <param name="settingName">The name of the setting to unlock.</param>
        /// <returns>True if the setting was successfully unlocked.</returns>
        public new bool TryUnlockSetting(string settingName)
        {
            return base.TryUnlockSetting(settingName);
        }
    }
}