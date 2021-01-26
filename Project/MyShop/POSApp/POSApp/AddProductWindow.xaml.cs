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

namespace POSApp
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            productCategoryComboBox.ItemsSource = db.Categories.ToList();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            NewProductInfo = new Product()
            {
                Product_Name = productNameTextbox.Text.ToString(),
                Price = int.Parse(productPriceTextbox.Text.ToString().Replace(",", "")),
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
                    Product_id = NewProductInfo.Product_ID,
                    Data = stream.ToArray()
                };
                db.Photos.Add(photo);
                db.SaveChanges();
            }
            DialogResult = true;
        }
        string _filename = "";
        private void chooseImage_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                _filename = screen.FileName;
                var bitmap = new BitmapImage(new Uri(screen.FileName, UriKind.Absolute));
                productPhoto.ImageSource = bitmap;
            }
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 0)
            {
                double value = 0;
                double.TryParse(textBox.Text, out value);
                textBox.Text = value.ToString("N0");
                textBox.CaretIndex = textBox.Text.Length;
            }
        }
    }
}