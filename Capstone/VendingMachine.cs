using Capstone.Plush;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<Plushy> Inv { get; private set; } = Inventory.SetInventory();

        public void Run()
        {
            bool isRunning = true;
            Cashier cashier = new Cashier();
            while (isRunning)
            { 
                Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) Exit\n");
                // TODO: Try Catch following:
                int input =  int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    DisplayItems();
                    Console.WriteLine();
                }
                else if (input == 2)
                {
                    Console.Clear();
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
                            Console.Clear();
                        }
                        else if (nextInput == 2)
                        {
                            DisplayItems();
                            Console.WriteLine();
                            Console.WriteLine("Please enter a code to select an item");
                            string codeInput = Console.ReadLine();
                            bool itemIsFound = false;
                            int selectedItemCount = 0;
                            string selectedItemName = "";
                            decimal selectedItemPrice = 0;
                            for (int i = 0; i < Inv.Count; i++)
                            {
                                if (codeInput == Inv[i].Location)
                                {
                                    itemIsFound = true;
                                    selectedItemCount = Inv[i].Count;
                                    selectedItemPrice = Inv[i].Price;
                                    selectedItemName = Inv[i].Name;
                                }
                            }
                            if (itemIsFound && selectedItemCount == 0)
                            {
                                Console.WriteLine("SOLD OUT!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (!itemIsFound)
                            {
                                Console.WriteLine("Item was not found at this location");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                cashier.Transaction(selectedItemPrice, codeInput);
                                Dispense(codeInput);
                                LogPurchase(cashier.Balance, codeInput, selectedItemName, selectedItemPrice);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else if (nextInput == 3)
                        {
                            Console.Clear();
                            cashier.EndTransaction();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
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
            Console.Clear();
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
                    Console.WriteLine(Inv[i].Count);
                    Inv[i].Count--;
                    Console.WriteLine(Inv[i].Count);
                }
            }
        }

        public void LogPurchase(decimal totalBalance, string codeInput, string selectedName, decimal price)
        {

            using (StreamWriter writer = new StreamWriter("../../../../Log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} {selectedName} {codeInput} ${price} ${totalBalance}");
                // 01/01/2019 12:00:20 PM Emperor Penguin B4 $1.75 $8.25 
            }
        }

    }
}
