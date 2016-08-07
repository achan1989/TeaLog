using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeaLog.Settings;

namespace TeaLog.Controls
{
    /// <summary>
    /// Interaction logic for LoggablesEditor.xaml
    /// </summary>
    public partial class LoggablesEditor : UserControl
    {
        public LoggablesEditor()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newLoggable = new Loggable()
            {
                Name = "New item",
                DisplayColour = "",
                Category = "",
                ShowInMenu = false
            };

            var loggables = loggablesDataGrid.Items as IEditableCollectionViewAddNewItem;
            loggables.AddNewItem(newLoggable);

            loggablesDataGrid.SelectedItem = newLoggable;
            loggablesDataGrid.ScrollIntoView(newLoggable);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var loggable = loggablesDataGrid.SelectedItem as Loggable;
            if (loggable != null)
            {
                var loggables = loggablesDataGrid.ItemsSource as IList<Loggable>;
                loggables.Remove(loggable);
            }
        }
    }
}
