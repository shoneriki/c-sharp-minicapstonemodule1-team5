using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capstone
{
    public class VendingMachine
    {
        public Dictionary<Plush, Dictionary<string, int>> Inventory { get; set; } = new Dictionary<Plush, Dictionary<string, int>>();


        //using (StreamReader fileInput = new StreamReader(filePath))
        /* 
            while (!fileInput.EndOfStream)
                        {
                            string lineOfText = fileInput.ReadLine();
                            string lowerCaseLineOfText = lineOfText.ToLower();
                            
                            if (lowerCaseLineOfText.Contains(word.ToLower()))
                            {
                                //5. If the line contains the search string, print it out along with its line number
                                Console.WriteLine($"{lineCount}:{lineOfText}");
                            }
                            lineCount++;
                        }
         */

        // plush
        // Name: Count, Location
        
    }
}
