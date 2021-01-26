using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
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

        TransactionUserControl transaction = new TransactionUserControl();
        MasterDataUserControl master = new MasterDataUserControl();
        SaleUserControl sale = new SaleUserControl();
        ReportUserControl report = new ReportUserControl();
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tabsContent.ItemsSource = new ObservableCollection<TabItem>()
            {
                new TabItem() { Content = master, Visibility = Visibility.Collapsed,},
                new TabItem() { Content = sale, Visibility = Visibility.Collapsed},
                new TabItem() { Content = transaction, Visibility = Visibility.Collapsed},
                new TabItem() { Content = report, Visibility = Visibility.Collapsed}
            };
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
                master.ImportExcel(screen.FileName);
                master.UserControl_Initialized(sender, e);
            }
        }

        private void addCategoryButton_Clicked(object sender, RoutedEventArgs e)
        {
            var screen = new AddCategoryWindow();
            if (screen.ShowDialog() == true)
            {
                master.addCategory();
            }
        }

        private void updateCategoryButton_Clicked(object sender, RoutedEventArgs e)
        {
            master.updateCategory();
        }

        private void deleteCategoryButton_Clicked(object sender, RoutedEventArgs e)
        {
            master.deleteCategory();
        }

        private void addProductButton_Clicked(object sender, RoutedEventArgs e)
        {
            var screen = new AddProductWindow();
            if (screen.ShowDialog() == true)
            {
                master.addProduct();
            }
        }

        private void updateProductButton_Clicked(object sender, RoutedEventArgs e)
        {
            master.updateProduct();
        }

        private void deleteProductButton_Clicked(object sender, RoutedEventArgs e)
        {
            master.deleteProduct();
        }
    }
}