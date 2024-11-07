using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Ultimus.Application.Contracts.Infrastructure.Encryption;

namespace Ultimus.Infrastructure.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private static readonly string encryptionKey = "33ouaYq/SjbiMsw5rvPhqA==";
        public string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey); // AES Key (16 bytes for AES-128)
                aesAlg.GenerateIV();  // Generate random IV
                byte[] iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Write the IV at the start of the stream (so frontend can extract it later)
                    msEncrypt.Write(iv, 0, iv.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);  // Write the serialized object to the stream
                    }

                    // Return encrypted data as Base64 string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public string Encryptdd(object data)
        {
            // Serialize the object to JSON string
            string plainText = JsonConvert.SerializeObject(data);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey); // AES Key (16 bytes for AES-128)
                aesAlg.GenerateIV();  // Generate a random IV
                byte[] iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Write the IV at the beginning of the stream (so frontend can extract it later)
                    msEncrypt.Write(iv, 0, iv.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);  // Write the serialized object to the stream
                    }

                    // Return encrypted data as Base64 string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Encrypts(object data)
        {
            string plainText = JsonConvert.SerializeObject(data);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = new byte[16];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}
