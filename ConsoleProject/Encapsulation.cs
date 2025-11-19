using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Encapsulation
    {
        public class BankAccount
        {
            private static int nextAccountNumber = 1000;

            private int accountNumber;
            private string accountHolderName;
            private int balance;


            public BankAccount(string Name, int Balance)
            {
                accountNumber = nextAccountNumber++;
                accountHolderName = Name;
                balance = Balance;
            }

            public void Display()
            {
                Console.Write($"Account number: {accountNumber} Account holder name: {accountHolderName} Account balance: {balance}");
            }
        }
    }
}
