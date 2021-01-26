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
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();
            var NewCategoryInfo = new Category()
            {
                Name = categoryNameTextbox.Text.ToString(),
            };
            db.Categories.Add(NewCategoryInfo);
            db.SaveChanges();

            DialogResult = true;
        }
    }
}
