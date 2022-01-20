using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Clothes : Product, ICountable
    {
        public Clothes(string name, string brand, decimal price, string color, Size size, int count) : base(name, brand, price)
        {
            Color = color;
            Size = size;
            Count = count;
        }

        public string Color { get; set; }

        public Size Size { get; set; }

        public int Count { get; set; }

        public override StringBuilder Info()
        {
            info.Append($"\n{String.Join(" | ", Name, Brand, Size, Color)}");

            info.Append($"\n{Count} x {string.Format($"{TextFormatters.moneyFormat}", Price)} = {string.Format($"{TextFormatters.moneyFormat}", Price * Count)}");

            return info;
        }
    }

    public enum Size
    {
        XS,
        S,
        M,
        L,
        LX
    }
}
