using System;
using System.Security.Cryptography;
using System.Text;

namespace Almacen2
{
    public class Encriptador
    {
        public static string Encriptar(string str)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] passEncoded = new UnicodeEncoding().GetBytes(str);
            byte[] result = sha.ComputeHash(passEncoded);
            str = Convert.ToBase64String(result);
            return str;
        }
    }
}
