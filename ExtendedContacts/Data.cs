using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace ExtendedContacts
{
    public static class Data
    {
        public static string accountsFilePath = "accounts.json";
        public static List<Account> accounts;
        public static string login; 
        public static List<Contact> contacts;
        public static void LoadAccounts()
        {
            if (File.Exists(accountsFilePath))
            {
                // Deserialize the list of accounts from the file
                string json = File.ReadAllText(accountsFilePath);
                accounts = JsonSerializer.Deserialize<List<Account>>(json);
            }
            else
            {
                accounts = new List<Account>();
            }
        }
    }
}
