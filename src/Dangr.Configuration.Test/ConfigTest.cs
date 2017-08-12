// -----------------------------------------------------------------------
//  <copyright file="ConfigTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Configuration
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Dangr.Core.Configuration;
    using Dangr.Core.Configuration.Sources;
    using Dangr.Core.Configuration.Views;
    using Dangr.Core.Test;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [SuppressMessage(
         "Microsoft.Design",
         "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
         Justification = "This is a test class.")]
    [TestClass]
    public class ConfigTest
    {
        protected Configuration config;
        protected AllSettingsConfigurationView allSettingsView;
        protected DebugConfigurationSource testSource;
        protected AppSettingsConfigurationSource appConfigSource;
        protected DebugConfigurationSource lockingTestSource;

        [TestInitialize]
        public void TestInit()
        {
            this.config = new Configuration();
            this.allSettingsView = new AllSettingsConfigurationView();
            this.testSource = new DebugConfigurationSource();
            this.appConfigSource = new AppSettingsConfigurationSource();
            this.lockingTestSource = new DebugConfigurationSource();

            this.config.RegisterConfigurationView(this.allSettingsView);
            this.config.RegisterConfigurationSource(this.appConfigSource);
            this.config.RegisterConfigurationSource(this.testSource);
            this.config.RegisterConfigurationSource(this.lockingTestSource);

            this.lockingTestSource.TryAddOrUpdateSetting(ConfigNames.LockedSetting, "locked");
            this.lockingTestSource.TryLockSetting(ConfigNames.LockedSetting);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.allSettingsView.Dispose();
        }

        [TestMethod]
        public void ConfigTest_AddAndUpdate()
        {
            Assert.IsTrue(
                this.testSource.TryAddOrUpdateSetting(ConfigNames.Setting1, "Hello"),
                "Could not add setting.");
            Assert.IsTrue(this.allSettingsView.Settings.ContainsKey(ConfigNames.Setting1), "Setting does not exist.");
            Assert.AreEqual(
                "Hello",
                this.allSettingsView.Settings[ConfigNames.Setting1],
                "Setting has incorrect added value.");

            Assert.IsTrue(
                this.testSource.TryAddOrUpdateSetting(ConfigNames.Setting1, "Goodbye"),
                "Could not update setting.");
            Assert.AreEqual(
                "Goodbye",
                this.allSettingsView.Settings[ConfigNames.Setting1],
                "Setting has incorrect changed value.");

            Console.WriteLine(this.allSettingsView.ToString());
        }

        [TestMethod]
        public void ConfigTest_Lock()
        {
            Assert.IsFalse(
                this.testSource.TryAddOrUpdateSetting(ConfigNames.LockedSetting, "Unlocked"),
                "Modified locked setting.");
            Assert.IsTrue(
                this.lockingTestSource.TryAddOrUpdateSetting(ConfigNames.LockedSetting, "Still Locked"),
                "Could not modify setting with lock.");
            Assert.AreEqual(
                "Still Locked",
                this.allSettingsView.Settings[ConfigNames.LockedSetting],
                "Setting has incorrect value.");
        }

        [TestMethod]
        public void ConfigTest_Unlock()
        {
            Assert.IsTrue(
                this.lockingTestSource.TryUnlockSetting(ConfigNames.LockedSetting),
                "Could not unlock setting.");
            Assert.IsTrue(
                this.testSource.TryAddOrUpdateSetting(ConfigNames.LockedSetting, "Unlocked"),
                "Could not modify unlocked setting.");
            Assert.AreEqual(
                "Unlocked",
                this.allSettingsView.Settings[ConfigNames.LockedSetting],
                "Setting has incorrect value.");
        }

        [TestMethod]
        public void AppConfigSourceTest_GetValue()
        {
            Assert.IsTrue(
                this.allSettingsView.Settings.ContainsKey(ConfigNames.AppConfigSetting),
                "Setting does not exist.");
            Assert.AreEqual(
                "Hello",
                this.allSettingsView.Settings[ConfigNames.AppConfigSetting],
                "Setting has incorrect value.");
        }

        [TestMethod]
        public void AppConfigSourceTest_OverrideValue()
        {
            Assert.IsTrue(
                this.testSource.TryAddOrUpdateSetting(ConfigNames.AppConfigSetting, "Goodbye"),
                "Could not override setting.");
            Assert.AreEqual(
                "Goodbye",
                this.allSettingsView.Settings[ConfigNames.AppConfigSetting],
                "Setting has incorrect value.");

            this.config.ForceUpdate();

            Assert.AreEqual(
                "Goodbye",
                this.allSettingsView.Settings[ConfigNames.AppConfigSetting],
                "Setting override was not persisted.");
        }

        [TestMethod]
        public void Configuration_GetValue()
        {
            const string expectedValue = "Hello";
            Assert.IsTrue(
                this.testSource.TryAddOrUpdateSetting(ConfigNames.Setting1, expectedValue),
                "Could not add setting.");

            string setting = this.config.GetSetting(ConfigNames.Setting1);

            Assert.AreEqual(setting, expectedValue);
        }
        
        [TestMethod]
        public void Configuration_GetValueDoesntExist()
        {
            TestUtils.TestForError<ArgumentException>(() =>
                    this.config.GetSetting(ConfigNames.Setting1),
                    "Did not throw exception when getting unknown setting.");
        }
    }
}