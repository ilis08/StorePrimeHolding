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
        /// <summary>
        /// Return total price for all products in a List.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static decimal GetTotalSum(List<Product> products)
        {
            decimal total = 0;

            foreach (var product in products)
            {
                ArgumentNullException.ThrowIfNull(product);

                if (product is ICountable countableProd)
                {
                    total += product.Price * countableProd.Count;
                }
                else if (product is INonCountable nonCountableProd)
                {
                    total += product.Price * nonCountableProd.Weight;
                }
            }

            return total;
        }

        /// <summary>
        /// Return discount amount for a concrete Product.
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
