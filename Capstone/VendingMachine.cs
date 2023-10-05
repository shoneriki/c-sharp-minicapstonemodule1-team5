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

namespace Capstone
{
    public class VendingMachine
    {
        public List<Plushy> Inv { get { return Inventory.SetInventory(); } private set { } }

        public void Run()
        {
            bool isRunning = true;
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
                    // TODO: selecting an object for purchase
                    Cashier cashier = new Cashier();
                    Console.WriteLine($"Current Money Provided: {cashier.Balance} \n\n (1) Feed Money \n (2) Select Product \n (3) Finish Transaction");
                    int nextInput = int.Parse(Console.ReadLine());
                    int moneyInserted;
                    if (nextInput == 1)
                    {
                        Console.WriteLine("Enter in whole dollar amount or enter 0 to return to main menu");
                        moneyInserted = int.Parse(Console.ReadLine());
                        cashier.TakeMoney(moneyInserted);
                    }
                    else if (nextInput == 2)
                    {
                        DisplayItems();
                        Console.WriteLine("Please enter a code to select an item");
                        string codeInput = Console.ReadLine().ToLower();
                        bool itemIsFound = false;
                        for (int i = 0; i < Inv.Count; i++)
                        {
                            if (codeInput == Inv[i].Location)
                            {
                                itemIsFound = true;
                            }
                        }

                        if (!itemIsFound)
                        {
                            Console.WriteLine("Code was not found.");
                        }
                    }
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
