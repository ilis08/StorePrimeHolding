using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CountableFood : Food, ICountable
    {
        public CountableFood(string name, string brand, decimal price, DateTime creationDate, int count) : base(name, brand, price, creationDate)
        {
            Count = count;
        }

        public int Count { get; set; }

        public override void Info()
        {
            Console.WriteLine("\n" + string.Join(" | ", Name, Brand));

            Console.WriteLine($"{Count} x {string.Format($"{moneyFormat}", Price)} = {string.Format($"{moneyFormat}", Price * Count)}");
        }
    }
}
