using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Cart
    {
        public static List<Product> Products = new()
        {
            new Clothes("T-shirt", "Nike", 100, "Red", Size.M, 5) ,
            new Beverage("Fanta", "Coca-Cola", 5, new DateOnly(2021, 10, 21), 2) ,
            new Appliance("MacBook Air 2021", "Apple Inc.", 2000, "MacBook", new DateOnly(2021, 09, 10), 2, 3) ,
            new NonCountableFood("Apple", "Envy", 8, new DateOnly(2021, 07, 18), 2.320m) ,
            new CountableFood("Philadelphia cheese", "Kraft Heinz", 15, new DateOnly(2021, 12, 8), 3) 
        };

    }
}
