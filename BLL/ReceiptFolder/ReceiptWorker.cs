using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ReceiptFolder
{
    public class ReceiptWorker : IReceiptWorker
    {
        private StringBuilder receiptText = new StringBuilder();
        private string path = @$"C:\StorePrimeHolding\BLL\Receipts\check{DateTime.Now.ToFileTime()}.txt";

        public void AddText(string text)
        {
            receiptText.AppendFormat($"\n{text}");
        }

        public void AddText(StringBuilder text)
        {
            receiptText.AppendFormat($"\n{text}");
        }

        public StringBuilder PrintCheck()
        {
            SaveReceipt(receiptText);

            return receiptText;
        }

        public void SaveReceipt(StringBuilder text)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text.ToString());
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
