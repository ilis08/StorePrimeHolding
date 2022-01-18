using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DiscountCheckerFolder
{
    public interface IDiscountChecker
    {
        public int CheckDiscount(Product product);
    }
}
