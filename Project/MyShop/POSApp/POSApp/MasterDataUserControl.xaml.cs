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

namespace POSApp
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
            var db = new BadHabitsStoreEntities();
            categoriesComboBox.ItemsSource = db.Categories.ToList();
            categoriesComboBox.SelectedIndex = 0;
            sortComboBox.SelectedIndex = -1;
            filterComboBox.SelectedIndex = -1;
            keywordTextBox.Text = "";
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

        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        public void Refresh()
        {
            var db = new BadHabitsStoreEntities();
            categoriesComboBox.ItemsSource = db.Categories.ToList();
            categoriesComboBox.SelectedIndex = 0;
            sortComboBox.SelectedIndex = -1;
            filterComboBox.SelectedIndex = -1;
            keywordTextBox.Text = "";
        }

        int _rowsPerPage = 4; // Số sản phẩm trên 1 trang
        int _currentPage;
        PagingInfo pagingInfo;
        List<Category> _categories;

        private void importExecl_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                var filename = screen.FileName;
                var fileinfo = new FileInfo(filename);

                var excelFile = new Workbook(filename);
                var tabs = excelFile.Worksheets;

                var db = new BadHabitsStoreEntities();
                foreach (var tab in tabs)
                {
                    var category = new Category()
                    {
                        Category_Name = tab.Name
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();

                    var row = 3;

                    var cell = tab.Cells[$"C3"];
                    while (cell.Value != null)
                    {
                        var product = new Product()
                        {
                            //SKU = tab.Cells[$"C{row}"].StringValue,
                            Product_Name = tab.Cells[$"D{row}"].StringValue,
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
                                Product_id = product.Product_ID,
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
                UserControl_Initialized(sender, e);
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
            var db = new BadHabitsStoreEntities();
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            if (_selectedCategoryIndex < 0) _selectedCategoryIndex = 0;
            if (_selectedCategoryIndex > _categories.Count() - 1) _selectedCategoryIndex = 0;
            var products = _categories[_selectedCategoryIndex].Products;
            var keyword = keywordTextBox.Text;
            int start = Int32.MinValue;
            int end = Int32.MaxValue;
            var filter = filterComboBox.SelectedIndex;
            switch (filter)
            {
                case 0:
                    end = 200000;
                    break;
                case 1:
                    start = 200000;
                    end = 400000;
                    break;
                case 2:
                    start = 400000;
                    end = 600000;
                    break;
                case 3:
                    start = 600000;
                    break;
                default:
                    break;
            }
            var query = from product in products
                        where product.Product_Name.ToLower().Contains(keyword.ToLower())
                        && product.Price >= start && product.Price <= end
                        select new
                        {
                            Id = product.Product_ID,
                            Name = product.Product_Name,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            SoldOut = product.Quantity < 1,
                            almostOver = product.Quantity > 0 && product.Quantity < 10,
                            Thumbnail = product.Photos
                                .First().Data
                        };

            var skip = (_currentPage - 1) * _rowsPerPage;
            var take = _rowsPerPage;

            var sort = sortComboBox.SelectedIndex;
            switch (sort)
            {
                case 0:
                    productsListView.ItemsSource = query.OrderBy(q => q.Price).Skip(skip).Take(take);
                    break;
                case 1:
                    productsListView.ItemsSource = query.OrderByDescending(q => q.Price).Skip(skip).Take(take);
                    break;
                case 2:
                    productsListView.ItemsSource = query.OrderBy(q => q.Name).Skip(skip).Take(take);
                    break;
                case 3:
                    productsListView.ItemsSource = query.OrderByDescending(q => q.Name).Skip(skip).Take(take);
                    break;
                default:
                    productsListView.ItemsSource = query.Skip(skip).Take(take);
                    break;
            }
        }

        void CalculatePagingInfo()
        {
            var db = new BadHabitsStoreEntities();
            _categories = new List<Category>(db.Categories);
            var selectedCategory = categoriesComboBox.SelectedItem as Category;
            if (selectedCategory == null) selectedCategory = _categories[0];
            var products = db.Categories.Find(_categories[0].Category_ID).Products;
            bool alreadyExists = _categories.Any(x => x.Category_ID == selectedCategory.Category_ID);
            if (!alreadyExists)
            {
                products = db.Categories.Find(_categories[0].Category_ID).Products;
            }
            else
            {
                products = db.Categories.Find(selectedCategory.Category_ID).Products;
            }
            var keyword = keywordTextBox.Text;
            int start = Int32.MinValue;
            int end = Int32.MaxValue;
            var filter = filterComboBox.SelectedIndex;
            switch (filter)
            {
                case 0:
                    end = 200000;
                    break;
                case 1:
                    start = 200000;
                    end = 400000;
                    break;
                case 2:
                    start = 400000;
                    end = 600000;
                    break;
                case 3:
                    start = 600000;
                    break;
                default:
                    break;
            }
            var query = from product in products
                        where product.Product_Name.ToLower().Contains(keyword.ToLower())
                        && product.Price >= start && product.Price <= end
                        select new
                        {
                            Id = product.Product_ID,
                            Name = product.Product_Name,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            SoldOut = product.Quantity < 1,
                            almostOver = product.Quantity > 0 && product.Quantity < 10,
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
            totalProductTextBlock.Text = $"TOTAL PRODUCTS: {count} ";
            productsListView.ItemsSource = query.Take(_rowsPerPage);
        }

        private void keywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        int getId = -1;
        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic item = (sender as ListView).SelectedItem;
            if (item != null)
                getId = item.Id;
        }

        private void addCategory(object sender, RoutedEventArgs e)
        {
            var screen = new AddCategoryWindow();
            if (screen.ShowDialog() == true)
            {
                Refresh();
            }
        }

        private void editCategory(object sender, RoutedEventArgs e)
        {
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            var qCategory = _categories[_selectedCategoryIndex];
            var screen = new EditCategoryWindow(qCategory);
            if (screen.ShowDialog() == true)
            {
                var db = new BadHabitsStoreEntities();
                categoriesComboBox.ItemsSource = db.Categories.ToList();
                categoriesComboBox.SelectedIndex = _selectedCategoryIndex;
            }
        }

        private void deleteCategory(object sender, RoutedEventArgs e)
        {
            var db = new BadHabitsStoreEntities();
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            var c = _categories[_selectedCategoryIndex];

            var categories = db.Categories.ToList();
            var qCategory = categories.FirstOrDefault(i => i.Category_ID == c.Category_ID);
            var products = db.Products.ToList();
            var qProduct = products.FindAll(i => i.Catgory_ID == c.Category_ID);
            var photos = db.Photos.ToList();
            foreach (var p in qProduct)
            {
                var qPhoto = photos.FirstOrDefault(i => i.Product_id == p.Product_ID);
                db.Photos.Remove(qPhoto);
                db.SaveChanges();
                db.Products.Remove(p);
                db.SaveChanges();
            }
            db.Categories.Remove(qCategory);
            db.SaveChanges();
            Refresh();
        }

        private void addProduct(object sender, RoutedEventArgs e)
        {
            var screen = new AddProductWindow();
            if (screen.ShowDialog() == true)
            {
                CalculatePagingInfo();
                UpdateProductView();
            }
        }

        private void editProduct(object sender, RoutedEventArgs e)
        {
            if (getId != -1)
            {
                var db = new BadHabitsStoreEntities();
                var products = db.Products.ToList();
                var photos = db.Photos.ToList();
                var qProduct = products.FirstOrDefault(i => i.Product_ID == getId);
                var qPhoto = photos.FirstOrDefault(i => i.Product_id == getId);
                var screen = new EditProductWindow(qProduct, qPhoto);
                if (screen.ShowDialog() == true)
                {
                    CalculatePagingInfo();
                    UpdateProductView();
                }
            }
        }

        private void deleteProduct(object sender, RoutedEventArgs e)
        {
            if (getId != -1)
            {
                var db = new BadHabitsStoreEntities();
                var products = db.Products.ToList();
                var photos = db.Photos.ToList();
                var qProduct = products.FirstOrDefault(i => i.Product_ID == getId);
                var qPhoto = photos.FirstOrDefault(i => i.Product_id == getId);
                db.Photos.Remove(qPhoto);
                db.SaveChanges();
                db.Products.Remove(qProduct);
                db.SaveChanges();
                CalculatePagingInfo();
                UpdateProductView();
            }
        }

        private void sortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void filterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }
    }
}