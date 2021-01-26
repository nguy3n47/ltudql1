using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DashboardAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "Application is ready";

            var db = new MyStoreEntities();
            categoriesComboBox.ItemsSource = db.Categories.ToList();
            categoriesComboBox.SelectedIndex = 0;
        }

        class PagingRow
        {
            public int Page { get; set; }
            public int TotalPages { get; set; }
        }

        class PagingInfo
        {
            public List<PagingRow> Items { get; set; }
            public PagingInfo(int totalPages)
            {
                Items = new List<PagingRow>();

                for (int i = 1; i <= totalPages; i++)
                {
                    Items.Add(new PagingRow()
                    {
                        Page = i,
                        TotalPages = totalPages
                    });
                }
            }
        }

        int _rowsPerPage = 4; // Số sản phẩm trên 1 trang
        int _currentPage;
        PagingInfo pagingInfo;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new MyStoreEntities();
            var selectedCategory = categoriesComboBox.SelectedItem as Category;
            var products = db.Categories.Find(selectedCategory.Id).Products;
            var query = from product in products
                        select new
                        {
                            Name = product.Name,
                            Thumbnail = product.Photos
                                .First().Data
                        };
            // Tính toán các thông tin phân trang
            var _totalProducts = products.Count; // Tổng số sản phẩm
            var _totalPages = _totalProducts / _rowsPerPage; // Tổng số trang, chia lấy phần nguyên
            if (_totalProducts % _rowsPerPage != 0) // Nếu còn dư thì thêm một trang
            {
                _totalPages++;
            }
            _currentPage = 1;
            pagingInfo = new PagingInfo(_totalPages);
            pagesComboBox.ItemsSource = pagingInfo.Items;
            pagesComboBox.SelectedIndex = 0;
            productsListView.ItemsSource = query.Take(_rowsPerPage);
        }

        private void exitMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void excelImportButton_Clicked(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var filename = screen.FileName;
                var fileinfo = new FileInfo(filename);

                var excelFile = new Workbook(filename);
                var tabs = excelFile.Worksheets;

                var db = new MyStoreEntities();
                foreach (var tab in tabs)
                {
                    var category = new Category()
                    {
                        Name = tab.Name
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();

                    var row = 3;

                    var cell = tab.Cells[$"C3"];
                    while (cell.Value != null)
                    {
                        var product = new Product()
                        {
                            SKU = tab.Cells[$"C{row}"].StringValue,
                            Name = tab.Cells[$"D{row}"].StringValue,
                            Price = tab.Cells[$"E{row}"].IntValue
                        };

                        category.Products.Add(product);
                        db.SaveChanges();

                        var imageName = tab.Cells[$"H{row}"].StringValue;
                        var imageFull = $"{fileinfo.Directory}\\images\\{imageName}";
                        var image = new BitmapImage(new Uri(imageFull, UriKind.Absolute));
                        var encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(image));

                        using (var stream = new MemoryStream())
                        {
                            encoder.Save(stream);
                            var photo = new Photo()
                            {
                                Product_id = product.Id,
                                Data = stream.ToArray()
                            };
                            db.Photos.Add(photo);

                            db.SaveChanges();
                        }
                        row++;
                        cell = tab.Cells[$"C{row}"];
                    }
                }
                MessageBox.Show("Data Imported");
                RibbonWindow_Loaded(sender, e);
            }
        }

        private void addCategoryButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void deleteCategoryButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void addProductButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void updateProductButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void deleteProductButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new MyStoreEntities();
            var category = categoriesComboBox.SelectedItem as Category;
            var products = db.Categories.Find(category.Id).Products;
            var query = from product in products
                        select new
                        {
                            Name = product.Name,
                            Thumbnail = product.Photos
                                .First().Data
                        };
            var next = pagesComboBox.SelectedItem as PagingRow;
            if (next != null)
            {
                _currentPage = next.Page;

                productsListView.ItemsSource = query
                    .Skip((_currentPage - 1) * _rowsPerPage)
                    .Take(_rowsPerPage);
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = pagesComboBox.SelectedIndex;
            if (currentIndex < pagesComboBox.Items.Count - 1)
            {
                pagesComboBox.SelectedIndex = currentIndex + 1;
            }

        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = pagesComboBox.SelectedIndex;
            if (currentIndex <= pagesComboBox.Items.Count - 1 && currentIndex > 0)
            {
                pagesComboBox.SelectedIndex = currentIndex - 1;
            }
        }
    }
}