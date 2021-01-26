using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            loginProgressBar.IsIndeterminate = true;
            for (int i = 3; i >= 1; i--) // Keep running progress Ring for 3 seconds  
            {
                await Task.Delay(1000);
            }

            var server = ConfigurationManager.AppSettings["server"];
            var database = ConfigurationManager.AppSettings["database"];
            var username = usernameTextBox.Text;
            var password = passwordTextBox.Password;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (rememberCheckBox.IsChecked == true)
            {
                config.AppSettings.Settings["username"].Value = username;
                var passwordInBytes = Encoding.UTF8.GetBytes(password);
                var entropy = new byte[20];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(entropy);
                }

                var cypherText = ProtectedData.Protect(passwordInBytes, entropy, DataProtectionScope.CurrentUser);

                config.AppSettings.Settings["password"].Value = Convert.ToBase64String(cypherText);
                config.AppSettings.Settings["entropy"].Value = Convert.ToBase64String(entropy);
            }
            else
            {
                config.AppSettings.Settings["username"].Value = "";
                config.AppSettings.Settings["password"].Value = "";
                config.AppSettings.Settings["entropy"].Value = "";
            }

            config.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("appSettings");

            var db = new BadHabitsStoreEntities();
            var account = db.Accounts.Find(username);
            loginProgressBar.IsIndeterminate = false;

            if (account != null)
            {
                if (account.rolename == "admin")
                {
                    var m = new MainWindow();
                    m.Show();
                    this.Close();
                }
                else
                {
                    var s = new SaleWindow();
                    s.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"Login failed!");
            }


        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.ShowDialog();
        }
    }
}