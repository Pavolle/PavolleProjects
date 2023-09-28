using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security
{
    public class SecurityHelperManagerCreatorManager : Singleton<SecurityHelperManagerCreatorManager>
    {
        private SecurityHelperManagerCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using " + organizationName + ".Core.Utils;" + Environment.NewLine;
            classString += "using " + organizationName + ".Security.Hash;" + Environment.NewLine;
            classString += "using System.Text.RegularExpressions;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Security" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class SecurityHelperManager : Singleton<SecurityHelperManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        private string _key = \"aT{s8x56f!'dfYuPAVOLLE-s9we3''3*0AspE#wr\";" + Environment.NewLine;
            classString += "        private string _finalkey = \"Y@AAghaUi7eRH#d-k*sw9Wb4XPAVOLLE-B2B2af/{&&+fZ\";" + Environment.NewLine;
            classString += "        List<char> _specialCharacters = new List<char> { '?', '.', '#', '+', '*', '-', '!', '$', '%', '@' };" + Environment.NewLine;
            classString += "        List<char> _numbers = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };" + Environment.NewLine;
            classString += "        List<char> _upperCaseLetter = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z' };" + Environment.NewLine;
            classString += "        List<char> _lowerCaseLetter = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'r', 's', 't', 'u', 'v', 'y', 'z' };" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private SecurityHelperManager() { }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GenerateRandomCode(int length)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            string kod = \"\";" + Environment.NewLine;
            classString += "            var random = new Random();" + Environment.NewLine;
            classString += "            for (int i = 0; i < length; i++)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                kod += _numbers[random.Next(0, _numbers.Count)];" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return kod;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GenerateUserPassword()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            string sifre = \"\";" + Environment.NewLine;
            classString += "            var random = new Random();" + Environment.NewLine;
            classString += "            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];" + Environment.NewLine;
            classString += "            sifre += _numbers[random.Next(0, _numbers.Count)];" + Environment.NewLine;
            classString += "            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];" + Environment.NewLine;
            classString += "            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _numbers[random.Next(0, _numbers.Count)];" + Environment.NewLine;
            classString += "            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];" + Environment.NewLine;
            classString += "            return sifre;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GenerateAdminassword()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            string sifre = \"\";" + Environment.NewLine;
            classString += "            var random = new Random();" + Environment.NewLine;
            classString += "            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];" + Environment.NewLine;
            classString += "            sifre += _numbers[random.Next(0, _numbers.Count)];" + Environment.NewLine;
            classString += "            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];" + Environment.NewLine;
            classString += "            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _numbers[random.Next(0, _numbers.Count)];" + Environment.NewLine;
            classString += "            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];" + Environment.NewLine;
            classString += "            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];" + Environment.NewLine;
            classString += "            sifre += _numbers[random.Next(0, _numbers.Count)];" + Environment.NewLine;
            classString += "            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];" + Environment.NewLine;
            classString += "            return sifre;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public bool CheckPasswordForStandart(string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return Regex.Match(password, @\"((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,})\").Success;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public bool CheckCharacterRepeat(string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            bool isRepeat = false;" + Environment.NewLine;
            classString += "            for (int i = 0; i < password.Length; i++)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if(i+1<password.Length && i + 2 < password.Length)" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    if(password[i]==password[i+1] && password[i] == password[i + 2])" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        isRepeat = true;" + Environment.NewLine;
            classString += "                        break;" + Environment.NewLine;
            classString += "                    }" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return isRepeat;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public bool CheckCharacterSequence(string password)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            bool isSequence = false;" + Environment.NewLine;
            classString += "            for (int i = 0; i < password.Length; i++)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (i + 1 < password.Length && i + 2 < password.Length)" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    short next = Convert.ToInt16(password[i]);" + Environment.NewLine;
            classString += "                    char nextCharacter = Convert.ToChar(next+1);" + Environment.NewLine;
            classString += "                    short twoNext = Convert.ToInt16(password[i+1]);" + Environment.NewLine;
            classString += "                    char twoNextCharacter = Convert.ToChar(twoNext+1);" + Environment.NewLine;
            classString += "                    if (password[i + 1] == nextCharacter && twoNextCharacter == password[i + 2])" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        isSequence = true;" + Environment.NewLine;
            classString += "                        break;" + Environment.NewLine;
            classString += "                    }" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return isSequence;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetEncryptedPassword(string password, string username)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            var sha256 = new SHA256HashAlgorithm(); var sha384 = new SHA384HashAlgorithm(); var sha512 = new SHA512HashAlgorithm();" + Environment.NewLine;
            classString += "            var part1 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha256.ExecuteHMACHashAlgorithm(password, username));" + Environment.NewLine;
            classString += "            var part2 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha384.ExecuteHMACHashAlgorithm(password, password));" + Environment.NewLine;
            classString += "            var part3 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha512.ExecuteHMACHashAlgorithm(password, _key));" + Environment.NewLine;
            classString += "            var result = SecurityHelper.StringHelper.Reverse(part1.Substring(0, 32)) + part3.Substring(0, 64) + SecurityHelper.StringHelper.Reverse(part2.Substring(0, 32)) + part3.Substring(64, 32) + SecurityHelper.StringHelper.Reverse(part1.Substring(32, 32)) + part2.Substring(32, 32) + SecurityHelper.StringHelper.Reverse(part3.Substring(96, 32));" + Environment.NewLine;
            classString += "            return SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha256.ExecuteHMACHashAlgorithm(result, _finalkey));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "", "SecurityHelperManager.cs", classString);

        }
    }
}
