using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Plush
{
    public class Penguin : Plushy
    {
        public Penguin(string name, decimal price,  string location, int count) : base(name, price, location, count) 
        {
            DisplayMessage = "Squawk, Squawk, Whee!";
        }
    }
}
