using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Clothes : Product
    {
        public string Color { get; set; }

        public Size Size { get; set; }


     
    }

    public enum Size
    {
        XS,
        S,
        M,
        L,
        LX
    }
}
