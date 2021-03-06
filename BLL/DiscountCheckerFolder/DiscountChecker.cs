using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DiscountCheckerFolder
{
    /// <summary>
    /// Class contains methods for determining a discount for product.
    /// </summary>
    public class DiscountChecker : IDiscountChecker
    {
        public int CheckDiscount(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (product is Food || product is Beverage)
            {
                return GetPerishableProductDiscount((PerishableProduct)product);
            }
            else if (product is Clothes)
            {
                return GetClothesDiscount((Clothes)product);
            }
            else
            {
                return GetAppliancesDiscount((Appliance)product);
            }
        }

        private int GetPerishableProductDiscount(PerishableProduct product)
        {
            var days = product.ExpirationDate.Subtract(DateTime.UtcNow);

            var result = Math.Ceiling(days.TotalDays);

            if (result > 5)
            {
                return 0;
            }
            else if (result <= 5 && result > 1)
            {
                return 10;
            }
            else if (result == 1)
            {
                return 50;
            }
            else
            {
                throw new PerishableProductException(result, product);
            }
        }

        private int GetClothesDiscount(Clothes clothes)
        {
            var day = DateTime.Today.DayOfWeek;

            if ((day >= DayOfWeek.Monday) && (day <= DayOfWeek.Friday))
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }

        private int GetAppliancesDiscount(Appliance appliance)
        {
            var day = DateTime.Today.DayOfWeek;

            if (day == DayOfWeek.Sunday || day == DayOfWeek.Saturday && appliance.Price > 999)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
