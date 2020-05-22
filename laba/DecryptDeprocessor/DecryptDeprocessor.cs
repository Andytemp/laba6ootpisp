using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DecryptDeprocessor
{
    public class Decryptor
    {
        private string Key = "b14ca5898a4e4133bbce2ea2315a1916";
        public string Decrypt(string FileToReadFrom)
        {
            string cipherText = File.ReadAllText(FileToReadFrom);
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
