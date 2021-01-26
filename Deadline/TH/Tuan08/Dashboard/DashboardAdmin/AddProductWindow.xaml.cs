using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public Product NewProductInfo { get; set; } = null;
        public AddProductWindow()
        {
            InitializeComponent();
        }

        string _filename = "";
        private void chooseButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                _filename = screen.FileName;
                var bitmap = new BitmapImage(new Uri(screen.FileName, UriKind.Absolute));
                productPhoto.Source = bitmap;
            }
        }
        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();
            NewProductInfo = new Product()
            {
                Name = productNameTextbox.Text.ToString(),
                Price = Convert.ToDecimal(productPriceTextbox.Text.ToString()),
                Quantity = int.Parse(productQuantityTextbox.Text.ToString())
            };

            var _selectedCategoryIndex = productCategoryComboBox.SelectedIndex;
            db.Categories.ToList()[_selectedCategoryIndex].Products.Add(NewProductInfo);
            db.SaveChanges();

            var image = new BitmapImage(new Uri(_filename, UriKind.Absolute));
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                var photo = new Photo()
                {
                    Product_id = NewProductInfo.Id,
                    Data = stream.ToArray()
                };
                db.Photos.Add(photo);
                db.SaveChanges();
            }
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();
            productCategoryComboBox.ItemsSource = db.Categories.ToList();
            productCategoryComboBox.SelectedIndex = 0;
        }
    }
}
