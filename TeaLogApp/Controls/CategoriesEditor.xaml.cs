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
    /// Interaction logic for CategoriesEditor.xaml
    /// </summary>
    public partial class CategoriesEditor : UserControl
    {
        public CategoriesEditor()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newCat = new Category("new category");
            var categories = categoriesList.Items as IEditableCollectionViewAddNewItem;
            categories.AddNewItem(newCat);

            categoriesList.SelectedItem = newCat;
            categoriesList.ScrollIntoView(newCat);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var cat = categoriesList.SelectedItem as Category;
            if (cat != null)
            {
                var categories = categoriesList.ItemsSource as IList<Category>;
                categories.Remove(cat);
            }
        }

        /// <summary>
        /// Selects the category when clicked (TextBox normally blocks this).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                var cp = Util.FindAncestor<ContentPresenter>(tb);
                if (cp != null)
                {
                    categoriesList.SelectedItem = cp.Content;
                }
            }
        }
    }
}
