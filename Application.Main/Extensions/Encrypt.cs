using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
namespace Application.Main.Extention
{
    public class Encrypt
    {
        public async Task<string> Apply3DES(string raw) 
        {
            var encritedString = "";
            var decritedString = "";
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                byte[] encrypted = EncryptData(raw, tdes.Key, tdes.IV);
                encritedString = System.Text.Encoding.UTF8.GetString(encrypted);
                decritedString = DecryptData(encrypted, tdes.Key, tdes.IV);
            }
            return await Task.Run(() => encritedString);
        }
        public byte[] EncryptData(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            { 
                ICryptoTransform encryptor = tdes.CreateEncryptor(Key, IV); 
                using (MemoryStream ms = new MemoryStream())
                { 
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    { 
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            } 
            return encrypted;
        }
        static string DecryptData(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null; 
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            { 
                ICryptoTransform decryptor = tdes.CreateDecryptor(Key, IV); 
                using (MemoryStream ms = new MemoryStream(cipherText))
                { 
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    { 
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
