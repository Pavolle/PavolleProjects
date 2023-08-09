using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Pavolle.Security.Symmetric
{
    public class RC2Algorithm : ISymmetric
    {
        public string Encrypt(string message, string password)
        {
            // Encode message and password
            byte[] messageBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(message);
            byte[] passwordBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(password.Substring(0, 8));

            // Set encryption settings -- Use password for both key and init. vector
            RC2CryptoServiceProvider provider = new RC2CryptoServiceProvider();
            ICryptoTransform transform = provider.CreateEncryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            // Set up streams and encrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Read the encrypted message from the memory stream
            byte[] encryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

            // Encode the encrypted message as base64 string
            string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);

            return encryptedMessage;
        }

        public string Decrypt(string encryptedMessage, string password)
        {
            // Convert encrypted message and password to bytes
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);
            byte[] passwordBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(password.Substring(0,8));

            // Set encryption settings -- Use password for both key and init. vector
            RC2CryptoServiceProvider provider = new RC2CryptoServiceProvider();
            ICryptoTransform transform = provider.CreateDecryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            // Set up streams and decrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Read decrypted message from memory stream
            byte[] decryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);

            // Encode deencrypted binary data to base64 string
            string message = ASCIIEncoding.BigEndianUnicode.GetString(decryptedMessageBytes);

            return message;
        }
    }
}
