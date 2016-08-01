using System;
using System.Collections.Generic;
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
        public string LogFilePath;
        /// <summary>
        /// Optional list of categories that each loggable thing can be associated with.
        /// </summary>
        public List<string> Categories;
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
            Categories = new List<string>();
            LoggableThings = new List<LoggableThing>();
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
    }
}
