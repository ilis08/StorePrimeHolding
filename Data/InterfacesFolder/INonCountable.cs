using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfacesFolder
{
    /// <summary>
    /// Interface for non-countable products
    /// </summary>
    public interface INonCountable
    {
        public decimal Weight { get; set; }
    }
}
