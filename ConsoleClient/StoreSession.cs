using BLL;
using BLL.CashierFolder;
using BLL.ReceiptFolder;
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

            IReceiptWorker receiptWorker = new ReceiptWorker();

            Cart cart = new Cart();

            cashier.ProductsExpired += cart.GetNotificationFromCashier;

            cashier.CreateReceipt(cart.Products, DateTime.Now);

            Console.WriteLine(receiptWorker.ReturnReceiptAsync("check132871736778282401.txt").Result);
        }
    }
}
