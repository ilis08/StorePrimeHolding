﻿using BLL.CalculatorFolder;
using BLL.DiscountCheckerFolder;
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

        public Cashier()
        {
            checker = new DiscountChecker();
        }

        private decimal discountTotal = 0;

        public void PrintReceipt(List<Product> products, DateTime timeOfPurchase)
        {
            Console.WriteLine($"Date : {timeOfPurchase.ToString(TextFormatters.dateTimeFormatter)}");

            Console.WriteLine("\n---------------------Products-------------------------");

            PrintInfo(products);

            Console.WriteLine("\n--------------------------------------------------------");

            Console.WriteLine($"SUBTOTAL: {string.Format(TextFormatters.moneyFormat, PriceCalculator.GetTotalSum(products))}");
            Console.WriteLine($"DISCOUNT: -{string.Format(TextFormatters.moneyFormat, discountTotal)}");

            Console.WriteLine($"\nTOTAL: {string.Format(TextFormatters.moneyFormat, PriceCalculator.GetTotalSum(products) - discountTotal)}");
        }

        private void PrintInfo(List<Product> products)
        {
            foreach (Product product in products)
            {
                product.Info();

                var discount = checker.CheckDiscount(product);

                if (discount > 0)
                {
                    var discValue = PriceCalculator.CalculateWithDiscount(discount, product);

                    discountTotal += discValue;

                    Console.WriteLine($"#discount {discount}% -{string.Format(TextFormatters.moneyFormat, discValue)}");
                }
            }
        }
    }
}
