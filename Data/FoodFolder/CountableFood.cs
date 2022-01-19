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

        public override StringBuilder Info()
        {
            info.Append($"\n{String.Join(" | ", Name, Brand)}");

            info.Append($"\n{Count} x {string.Format($"{TextFormatters.moneyFormat}", Price)} = {string.Format($"{TextFormatters.moneyFormat}", Price * Count)}");

            return info;
        }
    }
}
