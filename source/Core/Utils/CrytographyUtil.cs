using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utils
{
    public class CrytographyUtil
    {
        //For generate password
        private static readonly RandomNumberGenerator _passwordGenerator = RNGCryptoServiceProvider.Create();
        private const string _hashName = "MD5";

        public static string GeneratePassword()
        {
            byte[] secureBits = new byte[64];
            _passwordGenerator.GetBytes(secureBits);
            return Convert.ToBase64String(secureBits);
        }

        public static string GetHashToString(string value)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(value);
            byte[] inArray = HashAlgorithm.Create(_hashName).ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        public static byte[] GetHashToByte(string value)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(value);
            return HashAlgorithm.Create(_hashName).ComputeHash(bytes);
        }

        public static Guid StringToGuid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = Guid.NewGuid().ToString();
            }
            return new Guid(GetHashToByte(value));
        }

        //For encrypt and decrypt a string
        private static readonly string PasswordHash = "P@ssW0rdH@sh#Realty";
        private static readonly string SaltKey = "S@ltK3y#Realty";
        private static readonly string VIKey = "FreelancerViet#Giang#MienDatMoi";

        public static string Encrypt(string value)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(value);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string value)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(value);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
