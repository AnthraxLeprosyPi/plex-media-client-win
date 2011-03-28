using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PlexMediaClient.Util {
    static class Encryption {
        /// <summary>
        /// Gets the SH a1 hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string GetSHA1Hash(string text) {
            var SHA1 = new SHA1CryptoServiceProvider();

            byte[] arrayData;
            byte[] arrayResult;
            string result = null;
            string temp = null;

            arrayData = Encoding.ASCII.GetBytes(text);
            arrayResult = SHA1.ComputeHash(arrayData);
            for (int i = 0; i < arrayResult.Length; i++) {
                temp = Convert.ToString(arrayResult[i], 16);
                if (temp.Length == 1)
                    temp = "0" + temp;
                result += temp;
            }
            return result;
        }
    }
}
