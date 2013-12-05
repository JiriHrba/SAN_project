using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Knihovna_SAN.App_Code
{
    /// <summary>
    /// Obsahuje statickou metodu pro hashovani hesla.
    /// </summary>
    public static class Cryptography
    {

        /// <summary>
        /// Vraci MD5 hash.
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        static public string CalculateHashMD5(string clearText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] tmpSource;
            byte[] tmpHash;

            tmpSource = System.Text.Encoding.UTF8.GetBytes(clearText);
            tmpHash = md5.ComputeHash(tmpSource);

            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in tmpHash)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string hash = s.ToString();
            return hash;
        }

    }
}