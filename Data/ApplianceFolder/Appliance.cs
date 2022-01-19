using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Appliance : Product, ICountable
    {
        public Appliance(string name, string brand, decimal price, string model, DateOnly productionDate, int weight, int count) : base(name, brand, price)
        {
            Model = model;
            ProductionDate = productionDate;
            Weight = weight;
            Count = count;
        }

        public string Model { get; set; }

        public DateOnly ProductionDate { get; set; }
   
        public int Weight { get; set; }

        public int Count { get; set; }

        public override void Info()
        {
            Console.WriteLine("\n" + String.Join(" | ", Name, Brand, Model));

            Console.WriteLine($"{Count} x {string.Format($"{TextFormatters.moneyFormat}", Price)} = {string.Format($"{TextFormatters.moneyFormat}", Price * Count)}");
        }
    }
}
