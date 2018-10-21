using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Models
{
    public class HashMD5
    {
        public string Str { get; set; }

        public HashMD5(string str)
        {
            Str = str;
        }

        public string Hashstr()
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(Str);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
