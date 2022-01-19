using DAL;
using DAL.InterfacesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CalculatorFolder
{
    public static class PriceCalculator 
    {
        public static decimal CalculateWithDiscount(int discount, Product product)
        {
            if (product is ICountable countableProduct)
            {
                decimal priceWithDiscount = ((product.Price * discount) / 100);

                var totalPrice = priceWithDiscount * countableProduct.Count;

                return totalPrice;
            }
            else if(product is INonCountable nonCountableProduct)
            {
                decimal priceWithDiscount = ((product.Price * discount) / 100);

                var totalPrice = priceWithDiscount * nonCountableProduct.Weight;

                return totalPrice;
            }
            else
            {
                throw new NotImplementedException();
            }
           
        }
    }
}
