using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;


/* 
 * Copyright (c) 2016 Adrian Chan
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */


namespace TeaLog.Settings
{
    /// <summary>
    /// Holds settings for the application.
    /// </summary>
    public class AppSettings
    {
        private static readonly string SettingsFileName = "TeaLogger.settings";

        /// <summary>
        /// Where to save the log.  Should be an absolute path with filename.
        /// </summary>
        public string LogFilePath { get; set; }
        /// <summary>
        /// Optional list of categories that each loggable thing can be associated with.
        /// </summary>
        public ObservableCollection<Category> Categories { get; private set; }
        /// <summary>
        /// A list of things that are loggable.
        /// </summary>
        public List<LoggableThing> LoggableThings;


        /// <summary>
        /// Create default, blank, settings.
        /// </summary>
        public AppSettings()
        {
            LogFilePath = null;
            Categories = new ObservableCollection<Category>();
            LoggableThings = new List<LoggableThing>();

            // Design-time data so the designer can show what things would look like at runtime.
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                LogFilePath = "D:\\Libraries\\Documents\\TeaLogs\\something.log";

                Categories.Add(new Category("tea"));
                Categories.Add(new Category("snacks"));
                Categories.Add(new Category("something longer"));

                LoggableThings.Add(new LoggableThing() {
                    Name = "Earl Grey",
                    DisplayColour = "some colour",
                    Category = "tea",
                    ShowInMenu = true
                });
            }
        }

        /// <summary>
        /// Create an entirely independant copy of the settings.
        /// </summary>
        /// <returns>a new AppSettings object.</returns>
        public AppSettings DeepClone()
        {
            var clone = new AppSettings();

            clone.LogFilePath = LogFilePath;
            clone.Categories = new ObservableCollection<Category>(Categories);

            foreach (var thing in LoggableThings)
            {
                clone.LoggableThings.Add(new LoggableThing(thing));
            }

            return clone;
        }

        /// <summary>
        /// Check if the configured LogFilePath is vaguely sane.
        /// </summary>
        /// <remarks>It is considered sane if it provides an absolute path to a file.</remarks>
        /// <returns>bool</returns>
        public bool IsLogFilePathValid()
        {
            return
                (!string.IsNullOrWhiteSpace(LogFilePath)) &&
                Path.IsPathRooted(LogFilePath) &&
                (!string.IsNullOrWhiteSpace(Path.GetFileName(LogFilePath)));
        }

        /// <summary>
        /// Load a settings file from the default location.
        /// </summary>
        /// <returns>The loaded settings.</returns>
        /// <exception cref="InvalidOperationException">if an error occurred during deserialization.</exception>
        /// <exception cref="FileNotFoundException" />
        public static AppSettings LoadSettings()
        {
            AppSettings settings;

            var ser = new XmlSerializer(typeof(AppSettings));
            using (var fs = new FileStream(
                Path.Combine(Application.LocalUserAppDataPath, SettingsFileName),
                FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                settings = ser.Deserialize(fs) as AppSettings;
                Debug.Assert(settings != null, "Deserialize succeeded but returned a null object.");
            }

            return settings;
        }

        /// <summary>
        /// Save an AppSettings to the default location.
        /// </summary>
        /// <param name="settings">The AppSettings to save. Must not be null.</param>
        /// <exception cref="InvalidOperationException">if an error occurred during serialization.</exception>
        public static void SaveSettings(AppSettings settings)
        {
            Debug.Assert(settings != null, "Called SaveSettings() with a null AppSettings object.");

            var ser = new XmlSerializer(typeof(AppSettings));
            using (var fs = new FileStream(
                Path.Combine(Application.LocalUserAppDataPath, SettingsFileName),
                FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                ser.Serialize(fs, settings);
            }
        }
    }


    /// <summary>
    /// Wraps a simple string.
    /// </summary>
    /// <remarks>
    /// WPF can't bind a collection of strings to a ListBox and make the strings editable.
    /// The collection has to be some object, with the string as a parameter.
    /// See http://stackoverflow.com/questions/5793438/how-to-make-listbox-editable-when-bound-to-a-liststring
    /// </remarks>
    public class Category
    {
        public string Name { get; set; }

        public Category() { }

        public Category(string name)
        {
            Name = name;
        }
    }


    /// <summary>
    /// Configurable settings for a category of thing that can be logged.
    /// </summary>
    public class LoggableThing
    {
        /// <summary>
        /// The name that appears in the menu and log entry.
        /// </summary>
        public string Name;
        /// <summary>
        /// The colour that appears in the menu.
        /// </summary>
        public string DisplayColour;
        /// <summary>
        /// An optional category that this thing belongs to. Appears in the log entry if provided.
        /// </summary>
        public string Category;
        /// <summary>
        /// Whether this should be shown in the context menu.
        /// </summary>
        public bool ShowInMenu;

        public LoggableThing() { }

        /// <summary>
        /// Create a LoggableThing that is identical to another LoggableThing.
        /// </summary>
        /// <param name="other">The LoggableThing to copy.</param>
        public LoggableThing(LoggableThing other)
        {
            this.Name = other.Name;
            this.DisplayColour = other.DisplayColour;
            this.Category = other.Category;
            this.ShowInMenu = other.ShowInMenu;
        }
    }
}
