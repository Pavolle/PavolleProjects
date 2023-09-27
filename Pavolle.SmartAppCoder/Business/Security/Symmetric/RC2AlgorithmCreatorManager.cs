using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security.Symmetric
{
    internal class RC2AlgorithmCreatorManager : Singleton<RC2AlgorithmCreatorManager>
    {
        private RC2AlgorithmCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using System.Security.Cryptography;" + Environment.NewLine;
            classString += "using System.Text;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Security.Symmetric" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class RC2Algorithm : ISymmetric" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public string Encrypt(string message, string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            byte[] messageBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(message);" + Environment.NewLine;
            classString += "            byte[] passwordBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(password.Substring(0,8));" + Environment.NewLine;
            classString += "            var provider = new RC2CryptoServiceProvider();" + Environment.NewLine;
            classString += "            ICryptoTransform transform = provider.CreateEncryptor(passwordBytes, passwordBytes);" + Environment.NewLine;
            classString += "            CryptoStreamMode mode = CryptoStreamMode.Write;" + Environment.NewLine;
            classString += "            MemoryStream memStream = new MemoryStream();" + Environment.NewLine;
            classString += "            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);" + Environment.NewLine;
            classString += "            cryptoStream.Write(messageBytes, 0, messageBytes.Length);" + Environment.NewLine;
            classString += "            cryptoStream.FlushFinalBlock();" + Environment.NewLine;
            classString += "            byte[] encryptedMessageBytes = new byte[memStream.Length];" + Environment.NewLine;
            classString += "            memStream.Position = 0;" + Environment.NewLine;
            classString += "            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);" + Environment.NewLine;
            classString += "            return Convert.ToBase64String(encryptedMessageBytes);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string Decrypt(string encryptedMessage, string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);" + Environment.NewLine;
            classString += "            byte[] passwordBytes = ASCIIEncoding.BigEndianUnicode.GetBytes(password.Substring(0, 8));" + Environment.NewLine;
            classString += "            var provider = new RC2CryptoServiceProvider();" + Environment.NewLine;
            classString += "            ICryptoTransform transform = provider.CreateDecryptor(passwordBytes, passwordBytes);" + Environment.NewLine;
            classString += "            CryptoStreamMode mode = CryptoStreamMode.Write;" + Environment.NewLine;
            classString += "            MemoryStream memStream = new MemoryStream();" + Environment.NewLine;
            classString += "            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);" + Environment.NewLine;
            classString += "            cryptoStream.Write(encryptedMessageBytes, 0, encryptedMessageBytes.Length);" + Environment.NewLine;
            classString += "            cryptoStream.FlushFinalBlock();" + Environment.NewLine;
            classString += "            byte[] decryptedMessageBytes = new byte[memStream.Length];" + Environment.NewLine;
            classString += "            memStream.Position = 0;" + Environment.NewLine;
            classString += "            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);" + Environment.NewLine;
            classString += "            return ASCIIEncoding.BigEndianUnicode.GetString(decryptedMessageBytes);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "Symmetric", "RC2Algorithm.cs", classString);

        }
    }
}
