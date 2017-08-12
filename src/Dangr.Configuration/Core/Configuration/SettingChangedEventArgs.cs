// -----------------------------------------------------------------------
//  <copyright file="SettingChangedEventArgs.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Configuration
{
    using System;

    /// <summary>
    /// Event args for the <see cref="Configuration" /> SettingChanged event.
    /// </summary>
    public class SettingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the name of the setting that was updated.
        /// </summary>
        public string SettingName { get; private set; }

        /// <summary>
        /// Gets the value the setting was updated to.
        /// </summary>
        public string SettingValue { get; private set; }

        internal SettingChangedEventArgs(string settingName, string settingValue)
        {
            this.SettingName = settingName;
            this.SettingValue = settingValue;
        }
    }
}