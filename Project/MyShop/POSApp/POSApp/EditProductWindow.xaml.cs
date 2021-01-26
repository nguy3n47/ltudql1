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
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public Product NewProductInfo { get; set; } = null;
        private Product _data;
        public Photo NewPhotoInfo { get; set; } = null;
        private Photo _photo;
        public EditProductWindow(Product prod, Photo p)
        {
            InitializeComponent();
            _data = prod;
            _photo = p;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            var c = db.Categories.ToList();
            var qC = c.FirstOrDefault(i => i.Category_ID == _data.Catgory_ID);
            productCategoryComboBox.Items.Add(qC);
            productCategoryComboBox.SelectedIndex = 0;
            var temp = (Double)_data.Price;
            productPriceTextbox.Text = temp.ToString();
            this.DataContext = _data;

            var array = _data.Photos.First().Data as byte[];
            using (var stream = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                productPhoto.ImageSource = image;
            }
        }

        string _filename = string.Empty;
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

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            var product = db.Products.Find(_data.Product_ID);

            if (!string.IsNullOrEmpty(_filename))
            {
                product.Product_Name = productNameTextbox.Text.ToString();
                product.Price = int.Parse(productPriceTextbox.Text.ToString().Replace(",", ""));
                product.Quantity = int.Parse(productQuantityTextbox.Text.ToString());
                db.SaveChanges();

                var image = new BitmapImage(new Uri(_filename, UriKind.Absolute));
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                var photo = db.Photos.Find(_photo.Photo_id);
                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    photo.Data = stream.ToArray();
                    db.SaveChanges();
                }
                DialogResult = true;
            }
            else
            {
                product.Product_Name = productNameTextbox.Text.ToString();
                product.Price = int.Parse(productPriceTextbox.Text.ToString().Replace(",", ""));
                product.Quantity = int.Parse(productQuantityTextbox.Text.ToString());
                db.SaveChanges();
                DialogResult = true;
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