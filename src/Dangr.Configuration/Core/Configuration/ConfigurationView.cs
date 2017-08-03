// -----------------------------------------------------------------------
//  <copyright file="ConfigurationView.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Configuration
{
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Util;

    /// <summary>
    /// An object that exposes settings in a <see cref="Configuration" /> .
    /// </summary>
    public abstract class ConfigurationView : ICheckedDisposable
    {
        private Configuration config;

        /// <summary>
        /// Gets a value indicating whether this <see cref="ICheckedDisposable" /> has been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Disposes the resources managed by this <see cref="ICheckedDisposable" /> .
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Disposes the resources managed by this <see cref="ICheckedDisposable" /> .
        /// </summary>
        /// <param name="isDisposing">
        /// Indicates whether the method call comes from a <see cref="Dispose()"/> method (true) or from a finalizer.
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