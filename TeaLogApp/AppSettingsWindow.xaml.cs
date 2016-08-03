using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeaLog.Settings;

namespace TeaLog
{
    /// <summary>
    /// Interaction logic for AppSettingsWindow.xaml
    /// </summary>
    public partial class AppSettingsWindow : Window
    {
        public AppSettings Settings { get; private set; }
        public AppSettingsWindowAction Action { get; private set; }


        public AppSettingsWindow(AppSettings settings)
        {
            InitializeComponent();

            Settings = settings;
            Action = AppSettingsWindowAction.Cancel;

            using (var fs = new FileStream("tea.ico", FileMode.Open, FileAccess.Read))
            {
                Icon = BitmapFrame.Create(fs);
            }
        }


        public enum AppSettingsWindowAction
        {
            Cancel,
            Save
        }
    }
}
