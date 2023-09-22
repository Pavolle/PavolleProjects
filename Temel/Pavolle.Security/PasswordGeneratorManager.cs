using Pavolle.Core.Utils;
using Pavolle.Security.Symmetric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Security
{
    public class PasswordGeneratorManager:Singleton<PasswordGeneratorManager>
    {
        string aeskey = "pl@gHa23";
        private PasswordGeneratorManager()
        {

        }

        public string GeneratePassword(string key)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(key))
            {
                return result;
            }

            AESAlgorithm aesAlgorithm = new AESAlgorithm();
            var aesResult = aesAlgorithm.Encrypt(key, aeskey);
            result = SecurityHelperManager.Instance.GetEncryptedPassword(aesResult, key).Substring(13, 24);

            return result;
        }
    }
}
