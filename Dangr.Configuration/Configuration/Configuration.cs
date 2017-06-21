// -----------------------------------------------------------------------
//  <copyright file="Configuration.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Configuration
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     A container for configuration settings.
    /// </summary>
    public class Configuration
    {
        private readonly Dictionary<string, string> settings;
        private readonly List<ConfigurationSource> sources;
        private readonly Dictionary<string, ConfigurationSource> locks;

        /// <summary>
        ///     Event that is triggered when a setting in this configuration is changed.
        /// </summary>
        public event EventHandler<SettingChangedEventArgs> SettingChanged;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        public Configuration()
        {
            this.settings = new Dictionary<string, string>();
            this.sources = new List<ConfigurationSource>();
            this.locks = new Dictionary<string, ConfigurationSource>();
        }

        /// <summary>
        ///     Forces the configuration to update it's settings from each of it's <see cref="ConfigurationSource" />s.
        /// </summary>
        public void ForceUpdate()
        {
            foreach (ConfigurationSource source in this.sources)
            {
                source.UpdateConfiguration();
            }
        }

        /// <summary>
        ///     Registers an <see cref="ConfigurationSource" /> as a configuration source for this <see cref="Configuration" />.
        /// </summary>
        /// <param name="source"> The <see cref="ConfigurationSource" /> to register. </param>
        /// <returns> The <see cref="ConfigurationSource" /> that was registered. </returns>
        public ConfigurationSource RegisterConfigurationSource(ConfigurationSource source)
        {
            if (!this.sources.Contains(source))
            {
                this.sources.Add(source);
                source.SetConfiguration(this);
                source.UpdateConfiguration();
            }

            return source;
        }

        /// <summary>
        ///     Registers an <see cref="ConfigurationView" /> as a configuration view for this <see cref="Configuration" />.
        /// </summary>
        /// <param name="view"> The <see cref="ConfigurationView" /> to register. </param>
        /// <returns> The <see cref="ConfigurationView" /> that was registered. </returns>
        public ConfigurationView RegisterConfigurationView(ConfigurationView view)
        {
            view.SetConfiguration(this);
            return view;
        }

        /// <summary>
        ///     Gets the setting with the specified name.
        /// </summary>
        /// <param name="name"> The name of the setting to get. </param>
        /// <returns> The value of the setting with the specified name. </returns>
        /// <exception cref="ArgumentException"> Thrown when there is no setting with the specified key. </exception>
        internal string GetSetting(string name)
        {
            string n = name.ToLowerInvariant();
            string setting;
            if (this.settings.TryGetValue(n, out setting))
            {
                return setting;
            }

            throw new ArgumentException($"Setting '{n}' was not found.");
        }

        /// <summary>
        ///     Tries to add or update a setting in the <see cref="Configuration" />.
        /// </summary>
        /// <param name="settingName"> The name of the setting. </param>
        /// <param name="value"> The new value for the setting. </param>
        /// <param name="source"> The <see cref="ConfigurationSource" /> that is trying to update the setting. </param>
        /// <returns> False if the setting is locked to the given <see cref="ConfigurationSource" />. </returns>
        internal bool TryAddOrUpdateSetting(string settingName, string value, ConfigurationSource source)
        {
            string n = settingName.ToLowerInvariant();
            lock (this.locks)
            {
                ConfigurationSource lockSource;
                if (this.locks.TryGetValue(n, out lockSource))
                {
                    if ((source == null) || !object.ReferenceEquals(source, lockSource))
                    {
                        return false;
                    }
                }
            }

            if (this.settings.ContainsKey(n))
            {
                this.settings[n] = value;
            }
            else
            {
                this.settings.Add(n, value);
            }

            this.OnSettingChanged(n, value);
            return true;
        }

        /// <summary>
        ///     Tries to lock the setting with the specified name.
        /// </summary>
        /// <param name="settingName"> The name of the setting to lock. </param>
        /// <param name="source"> The <see cref="ConfigurationSource" /> that is trying to lock the setting. </param>
        /// <returns> True if the setting was successfully locked. </returns>
        internal bool TryLockSetting(string settingName, ConfigurationSource source)
        {
            string n = settingName.ToLowerInvariant();
            lock (this.locks)
            {
                ConfigurationSource lockSource;
                if (this.locks.TryGetValue(n, out lockSource))
                {
                    if (object.ReferenceEquals(lockSource, source))
                    {
                        return true;
                    }

                    return false;
                }

                this.locks.Add(n, source);
                return true;
            }
        }

        /// <summary>
        ///     Tries to unlock the setting with the specified name.
        /// </summary>
        /// <param name="settingName"> The name of the setting to unlock. </param>
        /// <param name="source"> The <see cref="ConfigurationSource" /> that is trying to lock the setting. </param>
        /// <returns> True if the setting was successfully unlocked. </returns>
        internal bool TryUnlockSetting(string settingName, ConfigurationSource source)
        {
            string n = settingName.ToLowerInvariant();
            lock (this.locks)
            {
                ConfigurationSource lockSource;
                if (this.locks.TryGetValue(n, out lockSource))
                {
                    if (object.ReferenceEquals(lockSource, source))
                    {
                        this.locks.Remove(n);
                        return true;
                    }

                    return false;
                }
            }

            return true;
        }

        private void OnSettingChanged(string settingName, string settingValue)
        {
            this.SettingChanged?.Invoke(this, new SettingChangedEventArgs(settingName, settingValue));
        }
    }
}