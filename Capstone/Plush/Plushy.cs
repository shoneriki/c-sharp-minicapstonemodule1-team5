using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Plush
{
    public class Plush
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DisplayMessage { get; set; }

        public Plush(string name, decimal price, string displayMessage)
        {
            Name = name;
            Price = price;
            DisplayMessage = displayMessage;
        }
    }
}
