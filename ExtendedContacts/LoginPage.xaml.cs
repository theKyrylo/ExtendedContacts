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
using System.IO;
using System.Text.Json;

namespace ExtendedContacts
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Data.LoadAccounts();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isLogin = false;
            foreach (var a in Data.accounts)
            {
                if (LoginTextBox.Text == a.Login)
                {
                    if (PasswordTextBox.Password.ToString() == a.Password)
                    {
                        isLogin = true;
                        Data.login = a.Login;
                        this.NavigationService.Navigate(new Contacts(), DateTime.Now);
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        isLogin = true;
                        break;
                    }
                }
            }
            if (!isLogin)
                MessageBox.Show("Login is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void CreateOneButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateAccount(), DateTime.Now);
        }
    }
}
