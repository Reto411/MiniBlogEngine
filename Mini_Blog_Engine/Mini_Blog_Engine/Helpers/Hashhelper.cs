using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Mini_Blog_Engine.Helpers
{
    public static class HashHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int IterationsCount = 10001;
        private const string HashType = "M183Hash";
        private const string HashVersion = "V0.1";
        /// <summary>
        /// Creates a hash from a string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static string Hash(string text)
        {
            // generation of salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            // generation of hash
            var pbkdf2 = new Rfc2898DeriveBytes(text, salt, IterationsCount);
            var hash = pbkdf2.GetBytes(HashSize);

            // build byte array with salt and hasch
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            //format hash with extra information
            return string.Format("${0}${1}${2}${3}", HashType, HashVersion,IterationsCount, base64Hash);
        }

        public static bool CompareStringWithHash(string plaintext, string hashString)
        {
            if(!hashString.Contains(HashType + '$' + HashVersion))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            var splittedHashString = hashString.Replace(string.Format("${0}${1}$", HashType, HashVersion), "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            //get hashbytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            //get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            //create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(hashString, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            //get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}