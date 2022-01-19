using BLL;
using BLL.CashierFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public static class StoreSession
    {
        public static void Start()
        {
            ICashier cashier = new Cashier();

            Cart cart = new Cart();

            cashier.CreateReceipt(cart.Products, DateTime.Now);
        }
    }
}
