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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DashboardAdmin
{
    /// <summary>
    /// Interaction logic for TransactionUserControl.xaml
    /// </summary>
    public partial class TransactionUserControl : UserControl
    {
        public TransactionUserControl()
        {
            InitializeComponent();
        }


        enum PurchaseStatus
        {
            All = -1,
            New = 1,
            Cancelled = 2,
            Completed = 3,
            Shipping = 4
        }
        MyStoreEntities db = new MyStoreEntities();
        void loadAllPurchases()
        {
               var query = db.Purchases.GroupJoin(db.Customers,
               p => p.CustomerTel,
               c => c.Tel,
               (x, y) => new { Purchases = x, Customers = y }
               )
               .SelectMany(
                    x => x.Customers.DefaultIfEmpty(),
                    (x, y) => new { Purchase = x.Purchases, Customer = y }
                )
                .Select(item => new {
                    item.Purchase.Id,
                    item.Purchase.Total,
                    Status = "Mới tạo",
                    item.Purchase.CreatedAt,
                    item.Customer.Fullname,
                    item.Customer.Tel,
                    OrderID = "DH" + item.Purchase.Id.ToString(),
                    Details = item.Purchase.OrderDetails.Select(i => new
                    {
                        Product_Name = i.Product.Name,
                        Pirce = i.Price,
                        Quantity = i.Quantity,
                        Total = i.Total,
                        CreatedAt = i.CreatedAt,
                    })
                });;
            // Tính toán các thông tin phân trang
            var _totalProducts = db.Purchases.Count(); // Tổng số sản phẩm
            var _totalPages = _totalProducts / _rowsPerPage; // Tổng số trang, chia lấy phần nguyên
            if (_totalProducts % _rowsPerPage != 0) // Nếu còn dư thì thêm một trang
            {
                _totalPages++;
            }
            _currentPage = 1;
            pagingInfo = new PagingInfo(_totalPages);
            pagesComboBox.ItemsSource = pagingInfo.Items;
            pagesComboBox.SelectedIndex = 0;
            purchaseDataGrid.ItemsSource = query.ToList().Take(_rowsPerPage);
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            loadAllPurchases();
            var purchaseStateOptions = new List<object>() {
                new { Key="Tất cả", Value = PurchaseStatus.All},
                new { Key="Mới tạo", Value=PurchaseStatus.New},
                new { Key="Đã hủy", Value=PurchaseStatus.Cancelled},
                new { Key="Hoàn thành", Value=PurchaseStatus.Completed},
                new { Key="Đang giao", Value=PurchaseStatus.Shipping},
            };
            purchaseStatesComboBox.ItemsSource = purchaseStateOptions;
            purchaseStatesComboBox.SelectedIndex = 0;
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


        int _rowsPerPage = 10; // Số sản phẩm trên 1 trang
        int _currentPage;
        PagingInfo pagingInfo;

        private void pagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = db.Purchases.GroupJoin(db.Customers,
              p => p.CustomerTel,
              c => c.Tel,
              (x, y) => new { Purchases = x, Customers = y }
              )
              .SelectMany(
                   x => x.Customers.DefaultIfEmpty(),
                   (x, y) => new { Purchase = x.Purchases, Customer = y }
               )
               .Select(item => new {
                   item.Purchase.Id,
                   item.Purchase.Total,
                   Status = "Mới tạo",
                   item.Purchase.CreatedAt,
                   item.Customer.Fullname,
                   item.Customer.Tel,
                   OrderID = "DH" + item.Purchase.Id.ToString(),
                   Details = item.Purchase.OrderDetails.Select(i => new
                   {
                       Product_Name = i.Product.Name,
                       Pirce = i.Price,
                       Quantity = i.Quantity,
                       Total = i.Total,
                       CreatedAt = i.CreatedAt,
                   })
               });

            var next = pagesComboBox.SelectedItem as PagingRow;
            if (next != null)
            {
                _currentPage = next.Page;
                var skip = (_currentPage - 1) * _rowsPerPage;
                var take = _rowsPerPage;
                purchaseDataGrid.ItemsSource = query.ToList().Skip(skip).Take(take);
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

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = pagesComboBox.SelectedIndex;
            if (currentIndex < pagesComboBox.Items.Count - 1)
            {
                pagesComboBox.SelectedIndex = currentIndex + 1;
            }
        }

        private void addPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AddPurchaseWindow();
            if (screen.ShowDialog() == true)
            {
                loadAllPurchases();
            }
        }

        private void editPurchase_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = purchaseDataGrid.SelectedItem;
            var purchase = db.Purchases.Find(item.Id);
            var screen = new EditPurchaseWindow(purchase);
            if (screen.ShowDialog() == true)
            {
                loadAllPurchases();
            }
        }

        private void deletePurchase_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = purchaseDataGrid.SelectedItem;
            var oderDetail = db.OrderDetails.ToList().FindAll(i => i.OrderId == item.Id);
            var purchase = db.Purchases.Find(item.Id);
            var customer = db.Customers.Find(item.Tel);
            foreach (var o in oderDetail)
            {
                db.OrderDetails.Remove(o);
                db.SaveChanges();
            }
            db.Purchases.Remove(purchase);
            db.Customers.Remove(customer);
            db.SaveChanges();

            // Reload giao dien
            loadAllPurchases();

            // Thong bao phan hoi
            MessageBox.Show("Đơn hàng đã được xóa thành công!");
        }

        private void purchaseDataGrid_SelectedCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic item = purchaseDataGrid.SelectedItem;
            purchaseStackPanel.Visibility = Visibility.Visible;
            purchaseStackPanel.DataContext = item;
        }
    }
}
