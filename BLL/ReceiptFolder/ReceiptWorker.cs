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
        private string path = @$"C:\StorePrimeHolding\BLL\Receipts"; // Path for saving .txt receipts

        public void AddText(string text)
        {
            ArgumentNullException.ThrowIfNull(text);

            receiptText.AppendFormat($"\n{text}");
        }

        public void AddText(StringBuilder text)
        {
            ArgumentNullException.ThrowIfNull(text);

            receiptText.AppendFormat($"\n{text}");
        }

        public StringBuilder PrintCheck()
        {
            SaveReceipt(receiptText);

            return receiptText;
        }
        /// <summary>
        /// Method search for a receipt file and return if exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReturnReceipt(string fileName)
        {
            string textFromFile = "";

            try
            {
                using (FileStream fs = File.OpenRead(@$"{path}\{fileName}"))
                {
                    byte[] array = new byte[fs.Length];

                    fs.Read(array, 0, array.Length);

                    textFromFile = System.Text.Encoding.Default.GetString(array);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n--------------------------------");

                Console.WriteLine($"\nFile {fileName} not found.\n");

                Console.WriteLine("--------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n {ex.Message} \n");
            }

            return textFromFile;
        }

        /// <summary>
        /// Using FileStream create new receipt.txt and fills it with info
        /// </summary>
        /// <param name="text"></param>
        public void SaveReceipt(StringBuilder text)
        {
            try
            {
                using (FileStream fs = File.Create(@$"{path}\check{DateTime.Now.ToFileTime()}.txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(text.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Receipt was not saved.");
            }

        }
    }
}
