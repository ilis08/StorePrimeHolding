using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Beverage : PerishableProduct, ICountable
    {
        public Beverage(string name, string brand, decimal price, DateOnly creationDate, int count) : base(name, brand, price, creationDate)
        {
            Count = count;
        }

        public int Count { get; set; }

        public override void Info()
        {
            Console.WriteLine("\n" + string.Join(" | ", Name, Brand));

            Console.WriteLine($"{Count} x {string.Format($"{moneyFormat}", Price)} = {string.Format($"{moneyFormat}", Price * Count)}");
        }

        protected override DateOnly GenerateExpirationDate(DateOnly creationDate)
        {
            Random random = new Random();

            DateOnly expirationDate = creationDate.AddDays(random.Next(15, 100));

            return expirationDate;
        }
    }
}
