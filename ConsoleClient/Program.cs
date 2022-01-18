using BLL;
using DAL;

namespace ConsoleClient;

public class Program
{
    public static void Main()
    {
        Cashier cashier = new Cashier();

        cashier.PrintReceipt(Cart.Products);
    }
}