using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Threading;

namespace Capstone
{
    public class Cashier
    {
        public decimal Balance { get; private set; }

        public void TakeMoney(int moneyGiven)
        {
            if (moneyGiven > 0)
            {
                Balance += moneyGiven;
                using var writer = new StreamWriter("../../../../Log.txt", true);
                writer.WriteLine($"{DateTime.Now} FEED MONEY: ${moneyGiven} ${Balance} ");
            }
            else if (moneyGiven == 0)
            {
                Console.WriteLine("Going back to purchase menu...");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Please enter in a valid whole dollar amount");
                Thread.Sleep(1000);
            }
        }
        public bool Transaction(decimal price, string codeInput)
        {
            if (Balance >= price)
            {
                Balance -= price;
                return true;
            }
            else
            {
                Console.WriteLine("This item costs more than the current balance. Please insert more bills.");
                Thread.Sleep(1000);
                return false;
            }
        }
        public void EndTransaction()
        {
            decimal total = Balance;
            string change = GetChange();
            string[] splitForChange = change.Split(" ");

            Console.WriteLine($"Transaction Complete, your change is: {total} \n Quarters: {splitForChange[0]} \n Dimes: {splitForChange[1]} \n Nickels: {splitForChange[2]}");

            using (StreamWriter writer = new StreamWriter("../../../../Log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} GIVE CHANGE: ${total} ${Balance} ");
            }
        }
        public string GetChange()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            while (Balance >= .25M)
            {
                Balance -= .25M;
                quarters++;
            }
            while (Balance >= .10M)
            {
                Balance -= .10M;
                dimes++;
            }
            while (Balance >= .05M)
            {
                Balance -= .05M;
                nickels++;
            }

            string result = $"{quarters} {dimes} {nickels}";
            return result;
        }
    }
}
