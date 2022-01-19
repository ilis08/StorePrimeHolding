using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Product
    {
        public Product(string name, string brand, decimal price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        public string Name { get; set; }

        public string Brand { get; set; }   

        public decimal Price { get; set; }

        public abstract void Info();
    }
}
