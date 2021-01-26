using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DashboardAdmin
{
    /// <summary>
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private Category _data;
        public EditCategoryWindow(Category c)
        {
            InitializeComponent();
            _data = c;
        }

        private void updateCategory_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();
            var category = db.Categories.Find(_data.Id);
            if (!string.IsNullOrEmpty(categoryNameTextbox.Text.ToString()))
            {
                category.Name = categoryNameTextbox.Text.ToString();
                db.SaveChanges();
            }
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            categoryNameTextbox.Text = _data.Name;
        }
    }
}
