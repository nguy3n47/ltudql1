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
            var db = new MyStoreEntities();
            var c = db.Categories.ToList();
            var qC = c.FirstOrDefault(i => i.Id == _data.CatId);
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
                productPhoto.Source = image;
            }
        }

        private void updateProduct_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();
            var product = db.Products.Find(_data.Id);

            if (!string.IsNullOrEmpty(_filename))
            {
                product.Name = productNameTextbox.Text.ToString();
                product.Price = Convert.ToDecimal(productPriceTextbox.Text.ToString());
                product.Quantity = int.Parse(productQuantityTextbox.Text.ToString());
                db.SaveChanges();

                var image = new BitmapImage(new Uri(_filename, UriKind.Absolute));
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                var photo = db.Photos.Find(_photo.Photo_Id);
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
                product.Name = productNameTextbox.Text.ToString();
                product.Price = Convert.ToDecimal(productPriceTextbox.Text.ToString());
                product.Quantity = int.Parse(productQuantityTextbox.Text.ToString());
                db.SaveChanges();
                DialogResult = true;
            }
        }

        string _filename = string.Empty;
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
    }
}
