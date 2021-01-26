using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImportImageToSql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class PhotoU
        {
            public ObservableCollection<string> data { get; set; }
        }
        ObservableCollection<PhotoU> _photo { get; set; }
        private PhotoU _p;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void upload_Click(object sender, RoutedEventArgs e)
        {
            _photo = new ObservableCollection<PhotoU>();
            _p = new PhotoU();
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();
            if (result == true)
            {
                _p.data = new ObservableCollection<string>() { };
                foreach (string item in open.FileNames)
                {
                    _p.data.Add(item);
                }
                _photo.Add(_p);
                datalistView.ItemsSource = _p.data;
            }
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            datalistView.ItemsSource = null;
            // Save to SQL
            foreach(var filename in _p.data)
            {
                var image = new BitmapImage(new Uri(filename, UriKind.Absolute));
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    var photo = new Photo()
                    {
                        Data = stream.ToArray()
                    };
                    var db = new MyStoreEntities();
                    db.Photos.Add(photo);
                    db.SaveChanges();
                }
            }
            MessageBox.Show("Success!");
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            var db = new MyStoreEntities();
            var photos = db.Photos.ToArray();
            datalistView.ItemsSource = photos;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            datalistView.ItemsSource = null;
        }
    }
}
