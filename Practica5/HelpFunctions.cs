using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practica5
{
    internal class HelpFunctions
    {

        public static string Hashing(string input)
        {
            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }

        public static void MakeCheck(int checkid, string name, int price, int ct)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string text = "         Ghidra shop \n" +
                $"      Кассовый чек №{checkid}\n" +
                $"   {name}     -     {price}-{ct}\n" +
                $"Итого к оплате: {price * ct}\n" +
                $"Сдача: {price * ct}";

            File.AppendAllText($"{path}\\{checkid}.txt", text);

        }
    }
}
