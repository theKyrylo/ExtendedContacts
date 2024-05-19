using Microsoft.Win32;
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
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : Page
    {
        public int counter = 0;
        public Contacts()
        {
            InitializeComponent();
            Data.LoadContacts();
            InitContacts();
        }
        public void InitContacts()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Data.contacts[counter].ImagePath);
            bitmap.EndInit();
            Img.Source = bitmap;
            CName.Text = Data.contacts[counter].Name;
            CSurname.Text = Data.contacts[counter].Surname;
            CEmail.Text = Data.contacts[counter].Email;
            CAdress.Text = Data.contacts[counter].Address;
            CAge.Text = Data.contacts[counter].Age.ToString();
            CSex.Text = Data.contacts[counter].Sex;
            CPhone.Text = Data.contacts[counter].Phone;
            CDateOfBirth.Text = Data.contacts[counter].DateOfBitrh.ToString();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if (counter < Data.contacts.Count())
                InitContacts();
            else
            {
                Data.contacts.Add(new Contact());
                InitContacts();
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (counter - 1 >= 0)
            {
                counter--;
                InitContacts();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Data.contacts[counter].ImagePath = Img.Source.ToString();
            Data.contacts[counter].Name = CName.Text;
            Data.contacts[counter].Surname = CSurname.Text;
            Data.contacts[counter].Email = CEmail.Text;
            Data.contacts[counter].Address = CAdress.Text;
            Data.contacts[counter].Age = int.Parse(CAge.Text);
            Data.contacts[counter].Sex = CSex.Text;
            Data.contacts[counter].Phone = CPhone.Text;
            Data.contacts[counter].DateOfBitrh = DateTime.Parse(CDateOfBirth.Text);

            // Serialize the list to JSON
            string json = JsonSerializer.Serialize(Data.contacts, new JsonSerializerOptions { WriteIndented = true });
            // Write the JSON string to a file
            File.WriteAllText($"{Data.login}Contacts.json", json);
        }

        private void ChangeImgButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            // Show the dialog and get the result
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                // Get the selected file name
                string fileName = openFileDialog.FileName;

                // Display the selected image in the Image control
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fileName);
                bitmap.EndInit();
                Img.Source = bitmap;
            }
        }
    }
}
