using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ReceiptFolder
{
    public interface IReceiptWorker
    {
        public void AddText(string text);

        public void AddText(StringBuilder text);
        /// <summary>
        /// Using FileStream create new receipt.txt and fills it with info
        /// </summary>
        /// <param name="text"></param>
        public Task SaveReceiptAsync(StringBuilder text);
        /// <summary>
        /// Return receipt text
        /// </summary>
        /// <returns></returns>
        public StringBuilder ReturnReceipt();
        /// <summary>
        /// Method search for a receipt file and return if exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<string> ReturnReceiptAsync(string fileName);
    }
}
