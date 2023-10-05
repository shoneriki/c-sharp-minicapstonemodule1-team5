using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Plush
{
    public class Plushy
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DisplayMessage { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }

        public Plushy(string name, decimal price, string location, int count)
        {
            Name = name;
            Price = price;
            Location = location;
            Count = count;
        }
    }
}
