using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
        public void EndTransaction()
        {
            Console.WriteLine($"Transaction Complete, your change is {Balance}");
            
        }
    }
}
