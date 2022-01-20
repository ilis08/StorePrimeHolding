using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Throw exception if product is expired
    /// </summary>
    public class PerishableProductException : Exception
    {
        public double ExpireDays { get; set; }
        public PerishableProduct Product { get; set; }

        public PerishableProductException(double days,PerishableProduct product)
        {
            Product = product;
            ExpireDays = days;
        }
    }
}
