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
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            var NewCategoryInfo = new Category()
            {
                Category_Name = categoryTextbox.Text.ToString().ToUpper(),
            };
            db.Categories.Add(NewCategoryInfo);
            db.SaveChanges();

            DialogResult = true;
        }
    }
}