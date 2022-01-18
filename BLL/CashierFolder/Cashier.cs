using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CashierFolder
{
    public class Cashier : ICashier
    {
        public void PrintReceipt(List<Product> products)
        {
            Console.WriteLine($"Date : {DateTime.UtcNow}");

            Console.WriteLine("\n---------------------Products-------------------------");

            foreach (Product product in products)
            {
                product.Info();
            }

            Console.WriteLine("\n--------------------------------------------------------");
        }
    }
}
