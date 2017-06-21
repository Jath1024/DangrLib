// -----------------------------------------------------------------------
//  <copyright file="AllSettingsConfigurationView.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Configuration.Views
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A <see cref="ConfigurationView" /> that exposes all of the settings in
    /// the <see cref="Configuration" /> as a dictionary.
    /// </summary>
    public class AllSettingsConfigurationView : ConfigurationView
    {
        /// <summary>
        /// Gets the dictionary of settings exposed in the <see cref="Configuration" /> .
        /// </summary>
        public Dictionary<string, string> Settings { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllSettingsConfigurationView" /> class.
        /// </summary>
        public AllSettingsConfigurationView()
        {
            this.Settings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Updates the specified setting within the <see cref="ConfigurationView" /> .
        /// </summary>
        /// <param name="settingName">The name of the setting to update.</param>
        /// <param name="settingValue">The new value of the setting.</param>
        protected override void UpdateSetting(string settingName, string settingValue)
        {
            if (this.Settings.ContainsKey(settingName))
            {
                this.Settings[settingName] = settingValue;
            }
            else
            {
                this.Settings.Add(settingName, settingValue);
            }
        }

        /// <summary>
        /// Returns a string representation of all of the settings and their values.
        /// </summary>
        /// <returns>
        /// A string representation of all of the settings and their values.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in this.Settings)
            {
                sb.AppendFormat("{0} : {1}", kvp.Key, kvp.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}