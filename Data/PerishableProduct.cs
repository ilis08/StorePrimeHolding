using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class PerishableProduct : Product
    {
        DateOnly CreationDate { get; set; }

        DateOnly ExpirationDate { get; set; }


    }
}
