using Pavolle.Core.Utils;
using Pavolle.Security.Symmetric;

namespace Pavolle.Security
{
    public class PasswordGeneratorManager : Singleton<PasswordGeneratorManager>
    {
        string _key = "pl@gHa23";
        private PasswordGeneratorManager() { }
        
        public string GeneratePassword(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return "";
            var aesAlgorithm = new AESAlgorithm();
            var aesResult = aesAlgorithm.Encrypt(key, _key);
            return SecurityHelperManager.Instance.GetEncryptedPassword(aesResult, key).Substring(13, 24);
        }
    }
}
