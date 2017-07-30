// -----------------------------------------------------------------------
//  <copyright file="ConfigurationSource.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Configuration
{
    /// <summary>
    /// An object that populates settings in a <see cref="Configuration" /> .
    /// </summary>
    public abstract class ConfigurationSource
    {
        private Configuration config;

        /// <summary>
        /// Populates all of this <see cref="ConfigurationSource" /> s settings in the registered <see cref="Configuration" /> .
        /// </summary>
        public abstract void UpdateConfiguration();

        /// <summary>
        /// Tries to add or update a setting in the registered <see cref="Configuration" /> .
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The new value for the setting.</param>
        /// <returns>False if the setting is locked.</returns>
        protected bool TryAddOrUpdateSetting(string name, string value)
        {
            return this.config.TryAddOrUpdateSetting(name, value, this);
        }

        /// <summary>
        /// Tries to lock the setting with the specified name.
        /// </summary>
        /// <param name="settingName">The name of the setting to lock.</param>
        /// <returns>True if the setting was successfully locked.</returns>
        protected bool TryLockSetting(string settingName)
        {
            return this.config.TryLockSetting(settingName, this);
        }

        /// <summary>
        /// Tries to unlock the setting with the specified name.
        /// </summary>
        /// <param name="settingName">The name of the setting to unlock.</param>
        /// <returns>True if the setting was successfully unlocked.</returns>
        protected bool TryUnlockSetting(string settingName)
        {
            return this.config.TryUnlockSetting(settingName, this);
        }

        /// <summary>
        /// Sets the <see cref="Configuration" /> that this <see cref="ConfigurationSource" /> populates settings in.
        /// </summary>
        /// <param name="configuration">
        /// The <see cref="Configuration" /> to populate settings in.
        /// </param>
        internal void SetConfiguration(Configuration configuration)
        {
            this.config = configuration;
        }
    }
}