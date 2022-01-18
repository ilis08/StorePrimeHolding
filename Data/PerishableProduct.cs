using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class PerishableProduct : Product
    {
        public PerishableProduct(string name, string brand, decimal price, DateOnly creationDate) : base(name, brand, price)
        {
            CreationDate = creationDate;
            ExpirationDate = creationDate;
        }

        public DateOnly CreationDate { get; set; }

        public DateOnly ExpirationDate { get; set; }

        protected abstract DateOnly GenerateExpirationDate(DateOnly creationDate);

        /*protected static DateOnly GenerateExpirationDate(DateOnly creationDate)
        {
            Random random = new Random();

            DateOnly expirationDate = creationDate.AddDays(random.Next(8, 30));

            return expirationDate;
        }*/
    }
}
