using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        class Category
        {
            public int Category_Id { get; set; }
            public string Category_Name { get; set; }
            public BindingList<Product> Products { get; set; }
        }

        class Product
        {
            public int Product_Id { get; set; }
            public int Category_Id { get; set; }
            public string Product_Name { get; set; }
            public string Product_Photo { get; set; }
            public string Product_Pirce { get; set; }
            public Category Category { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        //ViewModel
        BindingList<Category> categories { get; set; }
        BindingList<Product> products { get; set; }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "Application is ready";

            //
            categories = new BindingList<Category>()
            {
                new Category()
                {
                    Category_Id = 1, Category_Name = "IPHONE",
                    Products = new BindingList<Product>()
                    {
                        new Product()
                        {
                            Product_Id = 1,
                            Product_Name = "IPhone 12 128GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/228737/iphone-12-256gb-195920-105925-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 2,
                            Product_Name = "IPhone 12 Mini 128GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/228742/iphone-12-mini-256gb-193220-023247-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 3,
                            Product_Name = "Iphone 12 Pro 256GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/228738/iphone-12-pro-256gb-190120-020118-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 4,
                            Product_Name = "Iphone 12 Pro Max 256GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/213033/iphone-12-pro-max-195420-015420-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 5,
                            Product_Name = "IPhone 11 Pro 256GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/230409/iphone-11-256gb-hop-moi-292520-102539-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 6,
                            Product_Name = "IPhone 11 128GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/230408/iphone-11-128gb-hop-moi-292520-102500-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 7,
                            Product_Name = "Iphone XR 64GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/230406/iphone-xr-64gb-hop-moi-292320-102327-600x600.jpg"
                        },
                        new Product()
                        {
                            Product_Id = 8,
                            Product_Name = "Iphone 11 Pro Max 256GB",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/210653/iphone-11-pro-max-256gb-black-600x600.jpg"
                        }
                    }
                },
                new Category()
                {
                     Category_Id = 2, Category_Name = "SAMSUNG",
                     Products = new BindingList<Product>()
                     {
                         new Product()
                         {
                            Product_Id = 9,
                            Product_Name = "Samsung Galaxy S20 FE",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/224859/samsung-galaxy-s20-fan-edition-242020-012039-600x600.jpg"
                         },
                         new Product()
                         {
                            Product_Id = 10,
                            Product_Name = "Samsung Galaxy Note 20 Ultra",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/220522/samsung-galaxy-note-20-ultra-5g-051920-101934-600x600.jpg"
                         },
                         new Product()
                         {
                            Product_Id = 11,
                            Product_Name = "Samsung Galaxy M51",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/217536/samsung-galaxy-m51-white-600x600-600x600.jpg"
                         },
                         new Product()
                         {
                            Product_Id = 12,
                            Product_Name = "Samsung Galaxy S10 Lite",
                            Product_Photo = "https://cdn.tgdd.vn/Products/Images/42/194251/samsung-galaxy-s10-lite-blue-thumb-600x600.jpg"
                         }
                     }
                }
            };

            categoriesComboBox.ItemsSource = categories;
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
            int index = categoriesComboBox.SelectedIndex;
            if (index >= 0)
            {
                // Tính toán các thông tin phân trang
                var _totalProducts = categories[index].Products.Count; // Tổng số sản phẩm
                var _totalPages = _totalProducts / _rowsPerPage; // Tổng số trang, chia lấy phần nguyên
                if (_totalProducts % _rowsPerPage != 0) // Nếu còn dư thì thêm một trang
                {
                    _totalPages++;
                }
                _currentPage = 1;
                pagingInfo = new PagingInfo(_totalPages);
                pagesComboBox.ItemsSource = pagingInfo.Items;
                pagesComboBox.SelectedIndex = 0;
                var products = categories[index].Products;
                productsListView.ItemsSource = products.Take(_rowsPerPage);
            }
        }

        private void exitMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void excelImportButton_Clicked(object sender, RoutedEventArgs e)
        {

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
            var category = categoriesComboBox.SelectedItem as Category;
            var next = pagesComboBox.SelectedItem as PagingRow;
            if (next != null)
            {
                _currentPage = next.Page;

                productsListView.ItemsSource = category.Products
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
            if (currentIndex >= pagesComboBox.Items.Count - 1 && currentIndex > 0)
            {
                pagesComboBox.SelectedIndex = currentIndex - 1;
            }
        }
    }
}
