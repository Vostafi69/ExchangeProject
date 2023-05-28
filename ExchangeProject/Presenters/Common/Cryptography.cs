using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ExchangeProject.Presenters.Common
{
    /// <summary>
    /// Класс для шифрования/дешифрования объектов БД
    /// </summary>
    static class Cryptography
    {
        private static readonly byte[] salt = Encoding.ASCII.GetBytes("SecretKey");

        /// <summary>
        /// Метод шифрования
        /// </summary>
        /// <param name="plainText">Текст для шифрования</param>
        /// <param name="password">Ключ</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            using (Aes aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(password, salt, 1000);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        encryptedBytes = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Метод для дешифрования
        /// </summary>
        /// <param name="encryptedText">Текст для шифрования</param>
        /// <param name="password">Ключ</param>
        /// <returns></returns>
        public static string Decrypt(string encryptedText, string password)
        {
            byte[] plainBytes;
            bool isBase64AesCipherText = Regex.IsMatch(encryptedText, @"^[A-Za-z0-9+/]*={0,2}$") && (encryptedText.Length % 4 == 0);

            if (isBase64AesCipherText)
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

                using (Aes aes = Aes.Create())
                {
                    var key = new Rfc2898DeriveBytes(password, salt, 1000);
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                            cryptoStream.FlushFinalBlock();
                            plainBytes = memoryStream.ToArray();
                        }
                    }
                }
            }
            else
            {
                return encryptedText;
            }

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}
