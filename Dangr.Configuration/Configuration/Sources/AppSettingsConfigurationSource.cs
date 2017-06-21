// -----------------------------------------------------------------------
//  <copyright file="AppSettingsConfigurationSource.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Configuration.Sources
{
    using System.Configuration;

    /// <summary>
    /// <para><see cref="ConfigurationSource" /> that populates settings in a 
    /// <see cref="System.Configuration.Configuration" /></para>
    /// <para>from the App.config file.</para>
    /// </summary>
    public class AppSettingsConfigurationSource : ConfigurationSource
    {
        /// <summary>
        /// Populates all of this <see cref="ConfigurationSource" /> s settings in the registered <see cref="System.Configuration.Configuration" /> .
        /// </summary>
        public override void UpdateConfiguration()
        {
            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
            {
                string value = ConfigurationManager.AppSettings[key];
                this.TryAddOrUpdateSetting(key, value);
            }
        }
    }
}