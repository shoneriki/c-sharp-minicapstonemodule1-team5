using Capstone.Plush;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone
{
    public class VendingMachine
    {
        public List<Plushy> Inv { get { return Inventory.SetInventory(); } private set { } }

        public void Run()
        {
            bool isRunning = true;
            Cashier cashier = new Cashier();
            while (isRunning)
            { 
                Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit\n");
                int input =  int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Console.Clear();
                    DisplayItems();
                }
                else if (input == 2)
                {
                    while (true)
                    {
                    Console.WriteLine($"Current Money Provided: {cashier.Balance} \n\n (1) Feed Money \n (2) Select Product \n (3) Finish Transaction");
                    int nextInput = int.Parse(Console.ReadLine());
                    int moneyInserted;
                        if (nextInput == 1)
                        {
                            Console.WriteLine("Enter in whole dollar amount or enter 0 to return to main menu");
                            string hold = Console.ReadLine();
                            moneyInserted = int.Parse(hold);
                            cashier.TakeMoney(cashier, moneyInserted);
                        }
                        else if (nextInput == 2)
                        {
                            DisplayItems();
                            Console.WriteLine();
                            Console.WriteLine("Please enter a code to select an item");
                            string codeInput = Console.ReadLine();
                            bool itemIsFound = false;
                            int selectedItemCount = 0;
                            decimal selectedItemPrice = 0;
                            for (int i = 0; i < Inv.Count; i++)
                            {
                                if (codeInput == Inv[i].Location)
                                {
                                    itemIsFound = true;
                                    selectedItemCount = Inv[i].Count;
                                    selectedItemPrice = Inv[i].Price;
                                }
                            }
                            if (itemIsFound && selectedItemCount == 0)
                            {
                                Console.WriteLine("SOLD OUT!");
                            }
                            else if (!itemIsFound)
                            {
                                Console.WriteLine("Item was not found at this location");
                            }
                            else
                            {
                                cashier.Transaction(selectedItemPrice, codeInput);
                            }
                        }
                        else if (nextInput == 3)
                        {
                            cashier.EndTransaction();
                            break;
                        }

                    }
                }
                else if (input == 3)
                {
                    isRunning = false;
                }

            }
        }

        public void DisplayItems()
        {
            for (int i = 0; i < Inv.Count; i++)
            {
                if (Inv[i].Count == 0)
                {
                    Console.WriteLine($"{Inv[i].Location}| {Inv[i].Name}| {Inv[i].Price}| SOLD OUT!");
                }
                Console.WriteLine($"{Inv[i].Location}| {Inv[i].Name}| {Inv[i].Price}| {Inv[i].Count}");
            }
        }

        public void Dispense(string codeInput)
        {
            for (int i = 0; i < Inv.Count; i++)
            {
                if (codeInput == Inv[i].Location)
                {
                    Console.WriteLine($"{Inv[i].DisplayMessage}");
                    Inv[i].Count--;
                }
            }
        }

    }
}
