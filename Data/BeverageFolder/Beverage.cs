using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Beverage : PerishableProduct, ICountable
    {
        public Beverage(string name, string brand, decimal price, DateTime creationDate, int count) : base(name, brand, price, creationDate)
        {
            Count = count;
        }

        public int Count { get; set; }

        public override void Info()
        {
            Console.WriteLine("\n" + string.Join(" | ", Name, Brand));

            Console.WriteLine($"{Count} x {string.Format($"{TextFormatters.moneyFormat}", Price)} = {string.Format($"{TextFormatters.moneyFormat}", Price * Count)}");
        }

        protected override DateTime GenerateExpirationDate(DateTime creationDate)
        {
            Random random = new Random();

            var expirationDate = creationDate.AddDays(random.Next(15, 100));

            return expirationDate;
        }
    }
}
