using Capstone.Plush;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public static class Inventory
    { 

        public static List<Plushy> SetInventory()
        {
            using (StreamReader reader = new StreamReader("../../../../vendingmachine.csv"))
            {
                List<Plushy> result = new List<Plushy>();
                while (!reader.EndOfStream)
                {
                    string lineOfText = reader.ReadLine();
                    string[] splitLine = lineOfText.Split("|");
                    string type = splitLine[3];
                    switch (type)
                    {
                        case "Duck":
                            Duck duck = new Duck(splitLine[1], decimal.Parse(splitLine[2]), splitLine[0], 5);
                            result.Add(duck);
                            break;
                        case "Penguin":
                            Penguin penguin = new Penguin(splitLine[1], decimal.Parse(splitLine[2]), splitLine[0], 5);
                            result.Add(penguin);
                            break;
                        case "Cat":
                            Cat cat = new Cat(splitLine[1], decimal.Parse(splitLine[2]), splitLine[0], 5);
                            result.Add(cat);
                            break;
                        case "Pony":
                            Pony pony = new Pony(splitLine[1], decimal.Parse(splitLine[2]), splitLine[0], 5);
                            result.Add(pony);
                            break;
                    }
                }
                return result;
            }
        }
    }
}
