﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using TeaLog.Settings;


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


namespace TeaLog
{
    public class LogManager
    {
        private readonly NotifyIcon notifyIcon;
        private AppSettings settings;
        private AppSettingsWindow settingsWindow;


        public LogManager(NotifyIcon notifyIcon)
        {
            this.notifyIcon = notifyIcon;
            settingsWindow = null;

            LoadAppSettings();
            WarnIfLogFileInvalid();
        }

        private void LoadAppSettings()
        {
            bool createNewSettings = false;
            try
            {
                settings = AppSettings.LoadSettings();
            }
            catch (FileNotFoundException)
            {
                createNewSettings = true;
            }
            catch (Exception ex)
            {
                createNewSettings = true;
                Util.ShowException("Error loading application settings. They will be overwritten with default settings.", ex);
            }

            /* Use default settings if none could be loaded, and save them for next time. */
            if (createNewSettings)
            {
                settings = new AppSettings();
                AppSettings.SaveSettings(settings);
            }
        }

        private FileStream OpenLog()
        {
            if (string.IsNullOrWhiteSpace(settings.LogFilePath)) { return null; }

            try
            {
                var logStream = new FileStream(
                    settings.LogFilePath.Trim(),
                    FileMode.Append, FileAccess.Write, FileShare.Read);
                return logStream;
            }
            catch (Exception ex)
            {
                Util.ShowException("Can't open log file.", ex);
                return null;
            }
        }

        private void WarnIfLogFileInvalid()
        {
            // Attempt to open the configured log file, shows error message if this isn't possible.
            var logStream = OpenLog();
            if (logStream != null) { logStream.Close(); }
        }

        private string FormatLogLine(Loggable loggable)
        {
            // { "type": "log", "item": "Earl Grey", "category": "tea", "datetime": "2016-08-07T13:05:01Z" }

            var sb = new StringBuilder(@"{ ""type"": ""log"",");

            sb.AppendFormat(@" ""item"": ""{0}"",", loggable.Name);

            string categoryValue = string.IsNullOrWhiteSpace(loggable.Category?.Trim()) ? "null" : loggable.Category.Trim();
            sb.AppendFormat(@" ""category"": ""{0}"",", categoryValue);

            string dtValue = DateTime.UtcNow.ToString(@"yyyy-MM-ddTHH\:mm\:ssZ");
            sb.AppendFormat(@" ""datetime"": ""{0}"" ", dtValue);

            sb.Append("}");

            return sb.ToString();
        }

        public void BuildContextMenu(ContextMenuStrip menu, ToolStripMenuItem exitItem)
        {
            menu.Items.Add(exitItem);

            var configItem = new ToolStripMenuItem("Config");
            configItem.Click += ConfigItem_Click;
            menu.Items.Add(configItem);

            menu.Items.Add(new ToolStripSeparator());

            foreach (var loggable in settings.Loggables)
            {
                if (!loggable.ShowInMenu) { continue; }

                Color col;
                try
                {
                    col = ColorTranslator.FromHtml(loggable.DisplayColour);
                }
                catch (Exception ex)
                {
                    Util.ShowException("Can't parse DisplayColour for " + loggable.Name, ex);
                    col = Color.White;
                }

                var bmp = new Bitmap(16, 16);
                using (var gfx = Graphics.FromImage(bmp))
                using (var brush = new SolidBrush(col))
                {
                    gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
                }

                var menuItem = new ToolStripMenuItem(loggable.Name);
                menuItem.Image = bmp;
                menuItem.Tag = loggable;
                menuItem.Click += LoggableItem_Click;
                menu.Items.Add(menuItem);
            }
        }

        private void LoggableItem_Click(object sender, EventArgs e)
        {
            var loggable = ((sender as ToolStripMenuItem)?.Tag as Loggable);
            Debug.Assert(loggable != null, "In click handler, loggable is null.");

            string toLog = FormatLogLine(loggable);

            var logStream = OpenLog();
            if (logStream != null)
            {
                using (var sw = new StreamWriter(logStream, Encoding.UTF8))
                {
                    sw.WriteLine(toLog);
                    //sw.Flush();
                }
            }
        }

        private void ConfigItem_Click(object sender, EventArgs e)
        {
            if (settingsWindow == null)
            {
                /* Pass a clone, otherwise the settings form could permanently edit the current settings
                 * even if the user chooses not to save. */
                settingsWindow = new AppSettingsWindow(settings.DeepClone());
                settingsWindow.Closed += settingsWindow_Closed;
                settingsWindow.SaveRequested += settingsWindow_SaveRequested;
                ElementHost.EnableModelessKeyboardInterop(settingsWindow);
                settingsWindow.Show();
            }
            else
            {
                if (settingsWindow.WindowState == WindowState.Minimized)
                {
                    settingsWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    settingsWindow.Focus();
                }
            }
        }

        private void settingsWindow_SaveRequested(object sender, EventArgs e)
        {
            var sw = sender as AppSettingsWindow;
            Debug.Assert(sw != null, "Saving settingsForm but sf object is null.");

            try
            {
                var newSettings = sw.Settings;
                AppSettings.SaveSettings(newSettings);
                settings = newSettings;
            }
            catch (Exception ex)
            {
                Util.ShowException("Error saving new application settings.", ex);
            }

            WarnIfLogFileInvalid();
        }

        private void settingsWindow_Closed(object sender, EventArgs e)
        {
            settingsWindow = null;
        }
    }
}
