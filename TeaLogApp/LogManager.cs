﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        private SettingsForm settingsForm;


        public LogManager(NotifyIcon notifyIcon)
        {
            this.notifyIcon = notifyIcon;
            settingsForm = null;

            LoadAppSettings();
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

        public void BuildContextMenu(ContextMenuStrip menu, ToolStripMenuItem exitItem)
        {
            menu.Items.Add(exitItem);

            var configItem = new ToolStripMenuItem("Config");
            configItem.Click += ConfigItem_Click;
            menu.Items.Add(configItem);
        }

        private void ConfigItem_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                /* Pass a clone, otherwise the settings form could permanently edit the current settings
                 * even if the user chooses not to save. */
                settingsForm = new SettingsForm(settings.DeepClone());
                settingsForm.FormClosed += SettingsForm_FormClosed;
                settingsForm.Show();
            }
            else
            {
                if (settingsForm.WindowState == FormWindowState.Minimized)
                {
                    settingsForm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    settingsForm.Focus();
                }
            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var sf = sender as SettingsForm;
            Debug.Assert(sf != null, "Closed settingsForm but sf object is null.");

            settingsForm = null;

            if (sf.Action == SettingsForm.SettingsFormAction.Save)
            {
                try
                {
                    var newSettings = sf.Settings;
                    AppSettings.SaveSettings(newSettings);
                    settings = newSettings;
                }
                catch (Exception ex)
                {
                    Util.ShowException("Error saving new application settings.", ex);
                }

                // TODO: switch log files if necessary.
            }
        }
    }
}