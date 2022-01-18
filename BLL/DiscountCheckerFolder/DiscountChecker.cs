using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DiscountCheckerFolder
{
    public class DiscountChecker : IDiscountChecker
    {
        public int CheckDiscount(Product product)
        {
            throw new NotImplementedException();
        }

        private bool CheckPerishableProductDiscount(PerishableProduct product)
        {
            var days = product.ExpirationDate.Day - product.ExpirationDate.Day;

            return true;
        }
    }
}
