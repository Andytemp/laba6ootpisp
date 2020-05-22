using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;

namespace EncryptProcessor
{
    public class Encryptor
    {
        private string Key = "b14ca5898a4e4133bbce2ea2315a1916";
        public void Encrypt(string value, string FileToWrite)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(value);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            File.WriteAllText(FileToWrite, Convert.ToBase64String(array));
        }
    }
}
