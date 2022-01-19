using BLL.CalculatorFolder;
using BLL.DiscountCheckerFolder;
using BLL.ReceiptFolder;
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
        IDiscountChecker checker;
        IReceiptWorker receiptWorker;

        public Cashier()
        {
            checker = new DiscountChecker();
            receiptWorker = new ReceiptWorker();
        }

        private decimal discountTotal = 0;

        public void CreateReceipt(List<Product> products, DateTime timeOfPurchase)
        {
            receiptWorker.AddText($"Date : {timeOfPurchase.ToString(TextFormatters.dateTimeFormatter)}");

            receiptWorker.AddText("\n---------------------Products-------------------------");

            PrintInfo(products);

            receiptWorker.AddText("\n--------------------------------------------------------");

            receiptWorker.AddText($"SUBTOTAL: {string.Format(TextFormatters.moneyFormat, PriceCalculator.GetTotalSum(products))}");
            receiptWorker.AddText($"DISCOUNT: -{string.Format(TextFormatters.moneyFormat, discountTotal)}");

            receiptWorker.AddText($"\nTOTAL: {string.Format(TextFormatters.moneyFormat, PriceCalculator.GetTotalSum(products) - discountTotal)}");

            Console.WriteLine(receiptWorker.PrintCheck());
        }

        private void PrintInfo(List<Product> products)
        {
            foreach (Product product in products)
            {
                receiptWorker.AddText(product.Info());

                var discount = checker.CheckDiscount(product);

                if (discount > 0)
                {
                    var discValue = PriceCalculator.CalculateWithDiscount(discount, product);

                    discountTotal += discValue;

                    receiptWorker.AddText($"#discount {discount}% -{string.Format(TextFormatters.moneyFormat, discValue)}");
                }
            }
        }
    }
}
