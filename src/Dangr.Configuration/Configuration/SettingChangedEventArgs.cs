// -----------------------------------------------------------------------
//  <copyright file="SettingChangedEventArgs.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Configuration
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