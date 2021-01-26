using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddPurchaseWindow.xaml
    /// </summary>
    public partial class AddPurchaseWindow : Window
    {
        public AddPurchaseWindow()
        {
            InitializeComponent();
        }

        BadHabitsStoreEntities db = new BadHabitsStoreEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            categoriesComboBox.ItemsSource = db.Categories.ToList();
            categoriesComboBox.SelectedIndex = 0;
            //var query = db.Products.ToList();
            //productsListView.ItemsSource = query.ToList();
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }


        BindingList<object> list = new BindingList<object>();

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = pagesComboBox.SelectedIndex;
            if (currentIndex <= pagesComboBox.Items.Count - 1 && currentIndex > 0)
            {
                pagesComboBox.SelectedIndex = currentIndex - 1;
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

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var next = pagesComboBox.SelectedItem as PagingRow;
            if (next != null)
            {
                _currentPage = next.Page;
                UpdateProductView();
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

        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        int _rowsPerPage = 9; // Số sản phẩm trên 1 trang
        int _currentPage;
        PagingInfo pagingInfo;
        List<Category> _categories;
        private void UpdateProductView()
        {
            var _selectedCategoryIndex = categoriesComboBox.SelectedIndex;
            if (_selectedCategoryIndex < 0) _selectedCategoryIndex = 0;
            if (_selectedCategoryIndex > _categories.Count() - 1) _selectedCategoryIndex = 0;
            var products = _categories[_selectedCategoryIndex].Products;
            var query = from product in products
                        select new
                        {
                            Id = product.Product_ID,
                            Name = product.Product_Name,
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
           
            var query = from product in products
                        select new
                        {
                            Id = product.Product_ID,
                            Name = product.Product_Name,
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
            productsListView.ItemsSource = query.Take(_rowsPerPage);
        }

        private void textBoxPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerTelTextBox.Text = Regex.Replace(customerTelTextBox.Text, "[^0-9]+", "");
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dynamic item = productsListView.SelectedItem;

            // Kiểm tra sản phẩm đã có sẵn hay chưa
            var foundIndex = -1;
            for (int i = 0; i < list.Count; i++)
            {
                dynamic p = list[i];
                if (p.Product_ID == item.Id)
                {
                    var updatedProduct = new
                    {
                        Product_ID = item.Id,
                        Product_Name = item.Name,
                        SubTotal = (p.Quantity + 1) * p.Unit_Price,
                        Quantity = p.Quantity + 1,
                        Unit_Price = p.Unit_Price,
                        Photo = item.Thumbnail
                    };
                    list.RemoveAt(i);
                    list.Insert(i, updatedProduct);

                    foundIndex = i; // báo hiệu đã tìm thấy
                }
            }

            if (foundIndex == -1) // Chưa cập nhật
            {
                list.Add(new
                {
                    Product_ID = item.Id,
                    Product_Name = item.Name,
                    Quantity = 1,
                    Unit_Price = item.Price,
                    SubTotal = item.Price,
                    Photo = item.Thumbnail
                });
            }
            selectedProductsListView.ItemsSource = list;
            double newValue = double.Parse(list.Sum((dynamic p) => Convert.ToInt32(p.SubTotal)).ToString());
            totalTextBlock.Text = $"{newValue.ToString("N0").Replace(",", ".") + " VNĐ"}";
        }

        private void productsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            var purchase = new Purchase()
            {
                Created_At = DateTime.Now,
                Total = list.Sum((dynamic p) => Convert.ToInt32(p.SubTotal)),
                Customer_Tel = customerTelTextBox.Text,
                Status = 1,
            };

            var customer = new Customer()
            {
                Tel = customerTelTextBox.Text,
                Customer_Name = customerNameTextBox.Text,
                Address = customerAddressTextBox.Text,
                Email = customerEmailTextBox.Text
            };

            foreach (dynamic item in list)
            {
                var orderDetail = new PurchaseDetail()
                {
                    Product_ID = item.Product_ID,
                    Price = item.Unit_Price,
                    Quantity = item.Quantity,
                    Total = item.SubTotal
                };
                purchase.PurchaseDetails.Add(orderDetail);
                db.PurchaseDetails.Add(orderDetail);
            }
            db.Customers.Add(customer);
            db.Purchases.Add(purchase);
            db.SaveChanges();

            MessageBox.Show("Thêm đơn hàng mới thành công!");

            DialogResult = true;
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = (sender as FrameworkElement).DataContext;
            int index = selectedProductsListView.Items.IndexOf(item);
            list.RemoveAt(index);
            double newValue = double.Parse(list.Sum((dynamic p) => Convert.ToInt32(p.SubTotal)).ToString());
            totalTextBlock.Text = $"{newValue.ToString("N0").Replace(",", ".") + " VNĐ"}";
        }
    }
}