using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CashierFolder
{
    public interface ICashier
    {
        public void PrintReceipt(List<Product> products);
    }
}
