using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class BankAccount : User
    {
        public int Money { get; set; }
        public BankAccount(string username, string password, int money)
        {
            Username = username;
            Password = password;
            Money = money;
        }

        // Method to perform a transaction(transfer money)
        public void Transaction(string ID, int value)
        {
            Money = Money - value;
            SaveAccountData();
        }
        // Method to deposit money into the account
        public void depositMoney(int value)
        {
            Money += value;
            SaveAccountData();
        }
        // Method to withdraw money from the account
        public void withdrawMoney(int value)
        {
            Money -= value;
            SaveAccountData();
        }
        // Method to get the current balance of the account
        public int balance()
        {
            return Money;
        }
        // Method to create a new account data file
        public void CreateAccountData()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\BankAccounts";
            string filePath = directoryPath + @$"\{Username}_BankAccount.txt";

            // Writing account data to file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine($"{Username}");
                sw.WriteLine($"{Password}");
                sw.WriteLine(Money);

            }
        }
        // Method to save the account data to file
        public void SaveAccountData()
        {
            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\BankAccounts";
            string filePath = directoryPath + @$"\{Username}_BankAccount.txt";

            // Writing account data to file
            using (StreamWriter sw = new StreamWriter(filePath, append: false))
            {
                sw.WriteLine($"{Username}");
                sw.WriteLine($"{Password}");
                sw.WriteLine(Money);
            }
        }
        // Method to load account data from file
        public static BankAccount LoadAccountData(string filePath)
        {
            // Reading account data from file
            string[] lines = File.ReadAllLines(filePath);
            string username = lines[0];
            string password = lines[1];
            int money = int.Parse(lines[2]);

            // Creating and returning a BankAccount object with loaded data
            BankAccount account = new BankAccount(username, password, money);
            return account;
        }
    }
}
