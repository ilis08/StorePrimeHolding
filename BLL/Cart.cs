using DAL;
using DAL.InterfacesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cart
    {
        public void AddToCart(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            Products.Add(product);
        }

        public void RemoveFromCart(string productName)
        {
            var product = Products.FirstOrDefault(x => x.Name == productName);

            ArgumentNullException.ThrowIfNull(product);

            Products.Remove(product);          
        }

        public void RemoveFromCart(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            Products.Remove(product);
        }

        public void RemoveRangeFromCart(List<Product> products)
        {
            ArgumentNullException.ThrowIfNull(products);

            foreach (var product in products)
            {
                Products.Remove(product);
            }
        }

        public void GetNotificationFromCashier(List<Product> products)
        {
            RemoveRangeFromCart(products);
        }

        public List<Product> Products = new()
        {
            new Clothes("T-shirt", "Nike", 100, "Red", Size.M, 5) ,
            new Beverage("Fanta", "Coca-Cola", 5, new DateTime(2021, 12, 21, 08, 12, 23), 2) ,
            new Appliance("MacBook Air 2021", "Apple Inc.", 2000, "MacBook", new DateOnly(2021, 09, 10), 2, 4) ,
            new NonCountableFood("Apple", "Envy", 8, new DateTime(2022, 01, 05, 11, 12, 35), 2.320m) ,
            new CountableFood("Philadelphia cheese", "Kraft Heinz", 15, new DateTime(2022, 01, 08, 23, 33, 01), 3) 
        };

    }
}
