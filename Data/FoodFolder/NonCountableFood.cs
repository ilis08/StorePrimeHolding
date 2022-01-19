using DAL.InterfacesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NonCountableFood : Food, INonCountable
    {
        public NonCountableFood(string name, string brand, decimal price, DateTime creationDate, decimal weight) : base(name, brand, price, creationDate)
        {
            Weight = weight;
        }

        //Weight in kilo
        public decimal Weight { get; set; }

        public override StringBuilder Info()
        {
            info.Append($"\n{string.Join(" | ", Name, Brand)}");

            info.Append($"{string.Format("\n{0:f3}", Weight)} x {string.Format($"{TextFormatters.moneyFormat}", Price)} = {string.Format($"{TextFormatters.moneyFormat}", Price * Weight)}");

            return info;
        }
    }
}
