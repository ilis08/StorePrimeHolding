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

        public void SaveReceipt(StringBuilder text);

        public StringBuilder PrintCheck();
    }
}
