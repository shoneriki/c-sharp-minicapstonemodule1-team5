using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Plush
{
    public class Cat : Plushy
    {
        public Cat(string name, decimal price, string location, int count) : base(name, price, location, count)
        { 
            DisplayMessage = "Meow, Meow, Meow!";
        }
    }
}
