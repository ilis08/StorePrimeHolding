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

        public override void Info()
        {
            Console.WriteLine("\n" + string.Join(" | ", Name, Brand));

            Console.WriteLine($"{string.Format("{0:f3}", Weight)} x {string.Format($"{moneyFormat}", Price)} = {string.Format($"{moneyFormat}", Price * Weight)}");
        }
    }
}
