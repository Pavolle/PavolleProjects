using System.Security.Cryptography;
using System.Text;

namespace Pavolle.Security.Symmetric
{
    public class RC2Algorithm : ISymmetric
    {
        public string Encrypt(string message, string password)
        {
            byte[] messageBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(message);
            byte[] passwordBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(password.Substring(0,8));
            var provider = new RC2CryptoServiceProvider();
            ICryptoTransform transform = provider.CreateEncryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] encryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            return Convert.ToBase64String(encryptedMessageBytes);
        }

        public string Decrypt(string encryptedMessage, string password)
        {
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);
            byte[] passwordBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(password.Substring(0, 8));
            var provider = new RC2CryptoServiceProvider();
            ICryptoTransform transform = provider.CreateDecryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] decryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);
            return ASCIIEncoding.BigEndianUnicode.GetString(decryptedMessageBytes);
        }
    }
}
