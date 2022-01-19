using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Class stores all text formatters
    /// </summary>
    public static class TextFormatters
    {
        public const string moneyFormat = "{0:$#,##0.00;($#,##0.00);Zero}"; // Format price from 8000 to $8 000,00 (example)
        public const string dateTimeFormatter = "yyyy-MM-dd H:mm:ss";// Format time to 2022-01-19 21:02:15 (example)
    }
}
