using BLL;
using BLL.CashierFolder;
using DAL;

namespace ConsoleClient;

public class Program
{
    public static void Main()
    {
        Cashier cashier = new Cashier();

        Cart cart = new Cart();

        cashier.PrintReceipt(cart.Products);
    }
}