// -----------------------------------------------------------------------
//  <copyright file="AppSettingsConfigurationSource.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Configuration.Sources
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