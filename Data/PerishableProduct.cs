using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class PerishableProduct : Product
    {
        public PerishableProduct(string name, string brand, decimal price, DateTime creationDate) : base(name, brand, price)
        {
            CreationDate = creationDate;
            ExpirationDate = GenerateExpirationDate(CreationDate);
        }

        public DateTime CreationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        protected abstract DateTime GenerateExpirationDate(DateTime creationDate);
    }
}
