using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Product
    {
        protected StringBuilder info  = new();

        public Product(string name, string brand, decimal price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        public string Name { get; set; }

        public string Brand { get; set; }   

        public decimal Price { get; set; }

        public abstract StringBuilder Info();
    }
}
