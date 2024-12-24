using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace EncryptedChat.Bll.Services
{
    public class CryptoService
    {
        public static readonly string messageCachePath = Directory.GetCurrentDirectory() + "/message_cache.txt";
        private readonly IConfiguration _configuration;
        private readonly byte[] Key;
        private readonly byte[] IV;

        public CryptoService(IConfiguration configuration)
        {
            _configuration = configuration;
            Key = Encoding.ASCII.GetBytes(_configuration["SecretKey"] ?? throw new ArgumentNullException("SeretKey is null"));
            IV = Encoding.ASCII.GetBytes(_configuration["IV"] ?? throw new ArgumentNullException("IV is null"));
        }

        public void WriteEncryptedCache(string user, string message, string time)
        {
            if (File.Exists(messageCachePath))
            {
                using var aesAlg = Aes.Create();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                var text = ReadDecryptedCache() ?? string.Empty;

                if (text.Length > 1000000)
                {
                    var r = text.IndexOf("</m>");
                    text = text[(text.IndexOf("</m>") + 4)..];
                }

                using var fileStreamWrite = File.OpenWrite(messageCachePath);
                using var cryptoStream = new CryptoStream(fileStreamWrite, encryptor, CryptoStreamMode.Write);
                using var streamWriter = new StreamWriter(cryptoStream);

                streamWriter.Write($"{text}{user}<m>{message}<t>{time}</m>");
            }
        }

        public string? ReadDecryptedCache()
        {
            string? text = null;

            if (File.Exists(messageCachePath))
            {
                using var aesAlg = Aes.Create();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                var dencryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using var fileStream = File.OpenRead(messageCachePath);
                using var cryptoStream = new CryptoStream(fileStream, dencryptor, CryptoStreamMode.Read);
                using var streamReader = new StreamReader(cryptoStream);

                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}
