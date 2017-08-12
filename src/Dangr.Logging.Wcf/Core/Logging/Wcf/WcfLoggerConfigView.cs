// -----------------------------------------------------------------------
//  <copyright file="WcfLoggerConfigView.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging.Wcf
{
    using Dangr.Core.Configuration;

    /// <summary>
    /// A <see cref="ConfigurationView" /> that exposes all
    /// of the settings in the <see cref="Configuration" /> used in the
    /// wcf logger.
    /// </summary>
    public class WcfLoggerConfigView : ConfigurationView
    {
        /// <summary>
        /// Gets the type of binding to use.
        /// </summary>
        public string Binding { get; private set; }

        /// <summary>
        /// Gets the directory to save the log files in.
        /// </summary>
        public string LogFileDirectory { get; private set; }

        /// <summary>
        /// Gets the prefix to prepend onto the log file name.
        /// </summary>
        public string LogFilePrefix { get; private set; }

        /// <summary>
        /// Gets the name of the WCF Service to contact.
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// Gets to URI location of the WCF Service.
        /// </summary>
        public string Uri { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WcfLoggerConfigView" /> class.
        /// </summary>
        public WcfLoggerConfigView()
        {
            this.Binding = "namedpipe";
            this.LogFileDirectory = "Logs";
            this.LogFilePrefix = "Live Viewer Log - ";
            this.ServiceName = DefaultWcfEndpoints.DefaultNamedPipeServiceName;
            this.Uri = DefaultWcfEndpoints.GetNetNamedPipeUri().AbsolutePath;
        }

        /// <summary>
        /// Updates the specified setting within the <see cref="ConfigurationView" /> .
        /// </summary>
        /// <param name="settingName">The name of the setting to update.</param>
        /// <param name="settingValue">The new value of the setting.</param>
        protected override void UpdateSetting(string settingName, string settingValue)
        {
            switch (settingName.ToLowerInvariant())
            {
                case "binding":
                    this.Binding = settingValue;
                    break;
                case "logfiledirectory":
                    this.LogFileDirectory = settingValue;
                    break;
                case "logfileprefix":
                    this.LogFilePrefix = settingValue;
                    break;
                case "servicename":
                    this.ServiceName = settingValue;
                    break;
                case "uri":
                    this.Uri = settingValue;
                    break;
            }
        }
    }
}