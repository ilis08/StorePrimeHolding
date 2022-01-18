using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Food : PerishableProduct
    {
        public Food(string name, string brand, decimal price, DateOnly creationDate) : base(name, brand, price, creationDate)
        {
        }

        protected override DateOnly GenerateExpirationDate(DateOnly creationDate)
        {
            Random random = new Random();

            DateOnly expirationDate = creationDate.AddDays(random.Next(8, 30));

            return expirationDate;
        }
    }
}
