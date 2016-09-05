using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BEL
{
    public class Utilidades
    {
        /// <summary>
        /// Metodo encriptador de entrada string a md5
        /// </summary>
        /// <param name="md5Hash">hash md5 input</param>
        /// <param name="input">entrada a modificar</param>
        /// <returns>string resultado de encriptar  el input</returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        
    }
}
