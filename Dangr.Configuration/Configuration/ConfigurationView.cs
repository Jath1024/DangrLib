// -----------------------------------------------------------------------
//  <copyright file="ConfigurationView.cs" company="DangerDan9631">
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
    using Dangr.Diagnostics;
    using Dangr.Util;

    /// <summary>
    /// An object that exposes settings in a <see cref="Configuration" /> .
    /// </summary>
    public abstract class ConfigurationView : ICancelable
    {
        private Configuration config;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Dangr.Util.ICancelable" /> has been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Disposes the resources managed by this <see cref="Dangr.Util.ICancelable" /> .
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Disposes the resources managed by this <see cref="Dangr.Util.ICancelable" /> .
        /// </summary>
        /// <param name="isDisposing">
        /// Indicates whether the method call comes from a <see cref="Dispose"/> method (true) or from a finalizer.
        /// </param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing && !this.IsDisposed)
            {
                if (this.config != null)
                {
                    this.config.SettingChanged -= this.Configuration_SettingChanged;
                    this.config = null;
                }

                this.IsDisposed = true;
            }
        }

        /// <summary>
        /// Gets the setting with the specified name.
        /// </summary>
        /// <param name="name">The name of the setting to get.</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when there is no setting with the specified key.
        /// </exception>
        /// <returns>The value of the setting with the specified name.</returns>
        public string GetSetting(string name)
        {
            Assert.Validate.NotDisposed(this, nameof(ConfigurationView));
            if (this.config == null)
            {
                throw new InvalidOperationException($"No configuration set on {nameof(ConfigurationView)}");
            }

            return this.config.GetSetting(name);
        }

        /// <summary>
        /// Updates the specified setting within the <see cref="ConfigurationView" /> .
        /// </summary>
        /// <param name="settingName">The name of the setting to update.</param>
        /// <param name="settingValue">The new value of the setting.</param>
        protected abstract void UpdateSetting(string settingName, string settingValue);

        /// <summary>
        /// Sets the <see cref="Configuration" /> that this <see cref="ConfigurationView" /> exposes settings from.
        /// </summary>
        /// <param name="configuration">
        /// The <see cref="Configuration" /> to expose settings from.
        /// </param>
        internal void SetConfiguration(Configuration configuration)
        {
            Assert.Validate.NotDisposed(this, nameof(ConfigurationView));
            this.config = configuration;
            this.config.SettingChanged += this.Configuration_SettingChanged;
        }

        private void Configuration_SettingChanged(object sender, SettingChangedEventArgs args)
        {
            this.UpdateSetting(args.SettingName, args.SettingValue);
        }
    }
}