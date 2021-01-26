using Aspose.Cells;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DashboardAdmin
{
    /// <summary>
    /// Interaction logic for MasterDataUserControl.xaml
    /// </summary>
    public partial class MasterDataUserControl : UserControl
    {
        public MasterDataUserControl()
        {
            InitializeComponent();
        }

        public void UserControl_Initialized(object sender, EventArgs e)
        {
            statusLabel.Content = "Application is ready";

            var db = new MyStoreEntities();
            categoriesComboBox.ItemsSource = db.Categories.ToList();
            categoriesComboBox.SelectedIndex = 0;
            listViewPriceFilter.SelectedItem = -1;
            List<ListItemPrice> items = new List<ListItemPrice>();
            items.Add(new ListItemPrice("Trên 10 triệu"));
            items.Add(new ListItemPrice("Từ 5 - 10 triệu"));
            items.Add(new ListItemPrice("Từ 2 - 5 triệu"));
            items.Add(new ListItemPrice("Từ 1 - 2 triệu"));
            items.Add(new ListItemPrice("Dưới 1 triệu"));
            listViewPriceFilter.ItemsSource = items;
        }

        public class ListItemPrice
        {
            public string Text { get; set; }

            public ListItemPrice(string t)
            {
                Text = t;
            }
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
        List<Category> _categories;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        public void ImportExcel(string filename)
        {
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
                        Price = tab.Cells[$"E{row}"].IntValue,
                        Quantity = tab.Cells[$"F{row}"].IntValue
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
        }

        public void Refresh()
        {
            var db = new MyStoreEntities();
            categoriesComboBox.ItemsSource = db.Categories.ToList();
            categoriesComboBox.SelectedIndex = 0;
        }

        public void addCategory()
        {
            Refresh();
        }

        public void updateCategory()
        {
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            var qCategory = _categories[_selectedCategoryIndex];
            var screen = new EditCategoryWindow(qCategory);
            if (screen.ShowDialog() == true)
            {
                var db = new MyStoreEntities();
                categoriesComboBox.ItemsSource = db.Categories.ToList();
                categoriesComboBox.SelectedIndex = _selectedCategoryIndex;
            }
        }

        public void deleteCategory()
        {
            var db = new MyStoreEntities();
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            var c = _categories[_selectedCategoryIndex];

            var categories = db.Categories.ToList();
            var qCategory = categories.FirstOrDefault(i => i.Id == c.Id);
            var products = db.Products.ToList();
            var qProduct = products.FindAll(i => i.CatId == c.Id);
            var photos = db.Photos.ToList();
            foreach (var p in qProduct)
            {
                var qPhoto = photos.FirstOrDefault(i => i.Product_id == p.Id);
                db.Photos.Remove(qPhoto);
                db.SaveChanges();
                db.Products.Remove(p);
                db.SaveChanges();
            }
            db.Categories.Remove(qCategory);
            db.SaveChanges();
            Refresh();
        }
        int getId = -1;
        public void addProduct()
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        public void updateProduct()
        {
            if (getId != -1)
            {
                var db = new MyStoreEntities();
                var products = db.Products.ToList();
                var photos = db.Photos.ToList();
                var qProduct = products.FirstOrDefault(i => i.Id == getId);
                var qPhoto = photos.FirstOrDefault(i => i.Product_id == getId);
                var screen = new EditProductWindow(qProduct, qPhoto);
                if (screen.ShowDialog() == true)
                {
                    CalculatePagingInfo();
                    UpdateProductView();
                }
            }

        }
        public void deleteProduct()
        {
            if (getId != -1)
            {
                var db = new MyStoreEntities();
                var products = db.Products.ToList();
                var photos = db.Photos.ToList();
                var qProduct = products.FirstOrDefault(i => i.Id == getId);
                var qPhoto = photos.FirstOrDefault(i => i.Product_id == getId);
                db.Photos.Remove(qPhoto);
                db.SaveChanges();
                db.Products.Remove(qProduct);
                db.SaveChanges();
                CalculatePagingInfo();
                UpdateProductView();
            }
        }

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var next = pagesComboBox.SelectedItem as PagingRow;
            if (next != null)
            {
                _currentPage = next.Page;
                UpdateProductView();
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

        private void UpdateProductView()
        {
            var db = new MyStoreEntities();
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            if (_selectedCategoryIndex < 0) _selectedCategoryIndex = 0;
            if (_selectedCategoryIndex > _categories.Count() - 1) _selectedCategoryIndex = 0;
            var products = _categories[_selectedCategoryIndex].Products;
            var keyword = keywordTextBox.Text;

            int start = Int32.MinValue;
            int end = Int32.MaxValue;

            var filter = listViewPriceFilter.SelectedIndex;
            switch (filter)
            {
                case 0:
                    start = 10000000;
                    break;
                case 1:
                    start = 5000000;
                    end = 10000000;
                    break;
                case 2:
                    start = 2000000;
                    end = 5000000;
                    break;
                case 3:
                    start = 1000000;
                    end = 2000000;
                    break;
                case 4:
                    end = 1000000;
                    break;
                default:
                    break;
            }

            var query = from product in products
                        where product.Name.ToLower().Contains(keyword.ToLower())
                        && product.Price >= start && product.Price <= end
                        select new
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Thumbnail = product.Photos
                                .First().Data
                        };

            var skip = (_currentPage - 1) * _rowsPerPage;
            var take = _rowsPerPage;
            productsListView.ItemsSource = query.Skip(skip).Take(take);
        }

        void CalculatePagingInfo()
        {
            var db = new MyStoreEntities();
            _categories = new List<Category>(db.Categories);
            var selectedCategory = categoriesComboBox.SelectedItem as Category;
            if (selectedCategory == null) selectedCategory = _categories[0];
            var products = db.Categories.Find(_categories[0].Id).Products;
            bool alreadyExists = _categories.Any(x => x.Id == selectedCategory.Id);
            if (!alreadyExists)
            {
                products = db.Categories.Find(_categories[0].Id).Products;
            }
            else
            {
                products = db.Categories.Find(selectedCategory.Id).Products;
            }
            var keyword = keywordTextBox.Text;
            int start = Int32.MinValue;
            int end = Int32.MaxValue;

            var filter = listViewPriceFilter.SelectedIndex;
            switch (filter)
            {
                case 0:
                    start = 10000000;
                    break;
                case 1:
                    start = 5000000;
                    end = 10000000;
                    break;
                case 2:
                    start = 2000000;
                    end = 5000000;
                    break;
                case 3:
                    start = 1000000;
                    end = 2000000;
                    break;
                case 4:
                    end = 1000000;
                    break;
                default:
                    break;
            }

            var query = from product in products
                        where product.Name.ToLower().Contains(keyword.ToLower())
                        && product.Price >= start && product.Price <= end
                        select new
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Thumbnail = product.Photos
                                .First().Data
                        };
            var count = query.Count();
            // Tính toán các thông tin phân trang
            var _totalProducts = count; // Tổng số sản phẩm
            var _totalPages = _totalProducts / _rowsPerPage; // Tổng số trang, chia lấy phần nguyên
            if (_totalProducts % _rowsPerPage != 0) // Nếu còn dư thì thêm một trang
            {
                _totalPages++;
            }
            _currentPage = 1;
            pagingInfo = new PagingInfo(_totalPages);
            pagesComboBox.ItemsSource = pagingInfo.Items;
            pagesComboBox.SelectedIndex = 0;
            statusTextBlock.Text = $"Total products found: {count} ";
            productsListView.ItemsSource = query.Take(_rowsPerPage);
        }

        private void keywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        private void filter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (filterOptions.Visibility == Visibility.Collapsed)
            {
                filterOptions.Visibility = Visibility.Visible;
            }
            else
            {
                filterOptions.Visibility = Visibility.Collapsed;
            }
        }

        private void listViewPriceFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        private void unselectFilter_Click(object sender, RoutedEventArgs e)
        {
            listViewPriceFilter.SelectedIndex = -1;
        }

        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic item = (sender as ListView).SelectedItem;
            if (item != null)
                getId = item.Id;
        }
    }
}
