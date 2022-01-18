using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Product
    {
        public string Name { get; set; }

        public string Brand { get; set; }   

        public decimal Price { get; set; }

    }
}
