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
    public delegate void OnProductsExpiredEventHandler(List<Product> products);

    public class Cashier : ICashier
    {
        IDiscountChecker checker;
        IReceiptWorker receiptWorker;

        public Cashier()
        {
            checker = new DiscountChecker();
            receiptWorker = new ReceiptWorker();
        }

        /// <summary>
        /// Event for action at the expiration date of product
        /// </summary>
        public event OnProductsExpiredEventHandler ProductsExpired;

        private decimal discountTotal = 0;

        public void CreateReceipt(List<Product> products, DateTime timeOfPurchase)
        {
            try
            {
                receiptWorker.AddText($"Date : {timeOfPurchase.ToString(TextFormatters.dateTimeFormatter)}");

                receiptWorker.AddText("\n---------------------Products-------------------------");

                PrintInfo(products);

                receiptWorker.AddText("\n--------------------------------------------------------");

                receiptWorker.AddText($"SUBTOTAL: {string.Format(TextFormatters.moneyFormat, PriceCalculator.GetTotalSum(products))}");
                receiptWorker.AddText($"DISCOUNT: -{string.Format(TextFormatters.moneyFormat, discountTotal)}");

                receiptWorker.AddText($"\nTOTAL: {string.Format(TextFormatters.moneyFormat, PriceCalculator.GetTotalSum(products) - discountTotal)}\n");

                Console.WriteLine(receiptWorker.ReturnReceipt());
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot create a receipt");
            }
        }

        /// <summary>
        /// Method print info and calculate discount for all product in List
        /// </summary>
        /// <param name="products"></param>
        private void PrintInfo(List<Product> products)
        {
            ArgumentNullException.ThrowIfNull(products);

            List<Product> productsForRemoving = new();// It's a collection where i keep the expiration products that should be removed from Cart

            try
            {
                foreach (var product in products)
                {
                    if (product is not null)
                    {
                        receiptWorker.AddText(product.Info());

                        try
                        {
                            var discount = checker.CheckDiscount(product);

                            if (discount > 0)
                            {
                                var discValue = PriceCalculator.CalculateWithDiscount(discount, product);

                                discountTotal += discValue;

                                receiptWorker.AddText($"#discount {discount}% -{string.Format(TextFormatters.moneyFormat, discValue)}");
                            }
                        }
                        catch (PerishableProductException ex)
                        {
                            productsForRemoving.Add(product);
                            receiptWorker.AddText($"Product {product.Name} is expired for {Math.Abs(ex.ExpireDays)} days and cannot be bought");
                        }
                    }
                    else
                    {
                        throw new Exception("Product is null");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // If productsForRemoving contains items, remove it from Cart
                if (productsForRemoving.Any())
                {
                    OnProductsExpired(productsForRemoving);
                }
            }
        }

        protected virtual void OnProductsExpired(List<Product> p)
        {
            if (ProductsExpired != null)
            {
                ProductsExpired(p);
            }
        }
    }
}

