﻿using System;

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
            }
            else
            {
                Console.WriteLine("Please enter in a valid whole dollar amount");
                Console.ReadKey();
            }
        }
        public void Transaction(decimal price)
        {
            if (Balance >= price)
            {
                Balance -= price;
            }
            else
            {
                Console.WriteLine("This item costs more than the current balance. Please insert more bills.");
                Console.ReadKey();
            }
        }
        public void EndTransaction()
        {
            decimal total = Balance;
            int quarters =0;
            int nickels =0;
            int dimes =0;

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

            Console.WriteLine($"Transaction Complete, your change is: {total} /n Quarters: {quarters} /n Dimes: {dimes} /n Nickels: {nickels}");
            Console.ReadKey();
        }
    }
}