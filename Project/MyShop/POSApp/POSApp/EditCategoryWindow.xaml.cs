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

namespace POSApp
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

        private void editCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            var category = db.Categories.Find(_data.Category_ID);
            if (!string.IsNullOrEmpty(categoryTextbox.Text.ToString()))
            {
                category.Category_Name = categoryTextbox.Text.ToString().ToUpper();
                db.SaveChanges();
            }
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            categoryTextbox.Text = _data.Category_Name;
        }
    }
}