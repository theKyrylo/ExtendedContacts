using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace ExtendedContacts
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Page
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccountNameTextBox.Text != "" && AccountSurnameTextBox.Text != "" &&
                AccountEmailTextBox.Text != "" && AccountLoginTextBox.Text != "" &&
                AccountPasswordTextBox.Text != "" && AccountPassConfirmTextBox.Text == AccountPasswordTextBox.Text)
            {
                bool isExist = false;
                foreach (var a in Data.accounts)
                {
                    if (AccountLoginTextBox.Text == a.Login)
                    {
                        isExist = true;
                        MessageBox.Show("Account with this login is already exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
                if (!isExist) 
                {
                    Account account = new Account()
                    {
                        Email = AccountEmailTextBox.Text,
                        Login = AccountLoginTextBox.Text,
                        Name = AccountNameTextBox.Text,
                        Password = AccountPasswordTextBox.Text,
                        Surname = AccountSurnameTextBox.Text
                    };
                    Data.accounts.Add(account);
                    // Serialize the list to JSON
                    string json = JsonSerializer.Serialize(Data.accounts, new JsonSerializerOptions { WriteIndented = true });
                    // Write the JSON string to a file
                    File.WriteAllText(Data.accountsFilePath, json);
                    this.NavigationService.Navigate(new Page1(), DateTime.Now);
                }
            }
            else
            {
                MessageBox.Show("Enter all data correctly please", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
