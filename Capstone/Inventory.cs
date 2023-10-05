using Capstone.Plush;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public static class Inventory
    { 

        public static string SetInventory()
        {
            using (StreamReader reader = new StreamReader("../../../../vendingmachine.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string lineOfText = reader.ReadLine();
                    string[] splitLine = lineOfText.Split("|");
                    string type = splitLine[3];
                    int duckCounter = 0;
                    int penguinCounter = 0;
                    int catCounter = 0;
                    int ponyCounter = 0;
                    switch (type)
                    {
                        case "Duck":
                            string duckName = $"Duck {duckCounter}";
                            Duck duckName. = new Duck(type, decimal.Parse(splitLine[2]), splitLine[0], 5);
                            break;
                        case "Penguin":
                            Penguin penguin = new Penguin(type, decimal.Parse(splitLine[2]), splitLine[0], 5);
                            break;
                        case "Cat":
                            Cat cat = new Cat(type, decimal.Parse(splitLine[2]), splitLine[0], 5);
                            break;
                        case "Pony":
                            Pony pony = new Pony(type, decimal.Parse(splitLine[2]), splitLine[0], 5);
                            break;
                            //public Plushy(string name, decimal price, string location, int count)

                    }
                }
            }
            return "";
        }
    }
}
