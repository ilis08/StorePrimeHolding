using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Interface for countable products
    /// </summary>
    public interface ICountable
    {
        public int Count { get; set; }
    }
}
