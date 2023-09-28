using Pavolle.Core.Utils;
using Pavolle.Security.Hash;
using System.Text.RegularExpressions;

namespace Pavolle.Security
{
    public class SecurityHelperManager : Singleton<SecurityHelperManager>
    {
        private string _key = "aT{s8x56f!'dfYuPAVOLLE-s9we3''3*0AspE#wr";
        private string _finalkey = "Y@AAghaUi7eRH#d-k*sw9Wb4XPAVOLLE-B2B2af/{&&+fZ";
        List<char> _specialCharacters = new List<char> { '?', '.', '#', '+', '*', '-', '!', '$', '%', '@' };
        List<char> _numbers = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        List<char> _upperCaseLetter = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z' };
        List<char> _lowerCaseLetter = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'r', 's', 't', 'u', 'v', 'y', 'z' };

        private SecurityHelperManager() { }

        public string GenerateRandomCode(int length)
        {
            string kod = "";
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                kod += _numbers[random.Next(0, _numbers.Count)];
            }
            return kod;
        }

        public string GenerateUserPassword()
        {
            string sifre = "";
            var random = new Random();
            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];
            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];
            sifre += _numbers[random.Next(0, _numbers.Count)];
            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];
            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];
            sifre += _numbers[random.Next(0, _numbers.Count)];
            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];
            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];
            return sifre;
        }

        public string GenerateAdminassword()
        {
            string sifre = "";
            var random = new Random();
            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];
            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];
            sifre += _numbers[random.Next(0, _numbers.Count)];
            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];
            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];
            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];
            sifre += _numbers[random.Next(0, _numbers.Count)];
            sifre += _lowerCaseLetter[random.Next(0, _lowerCaseLetter.Count)];
            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];
            sifre += _specialCharacters[random.Next(0, _specialCharacters.Count)];
            sifre += _numbers[random.Next(0, _numbers.Count)];
            sifre += _upperCaseLetter[random.Next(0, _upperCaseLetter.Count)];
            return sifre;
        }

        public bool CheckPasswordForStandart(string password)
        {
            return Regex.Match(password, @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,})").Success;
        }

        public bool CheckCharacterRepeat(string password)
        {
            bool isRepeat = false;
            for (int i = 0; i < password.Length; i++)
            {
                if(i+1<password.Length && i + 2 < password.Length)
                {
                    if(password[i]==password[i+1] && password[i] == password[i + 2])
                    {
                        isRepeat = true;
                        break;
                    }
                }
            }
            return isRepeat;
        }

        public bool CheckCharacterSequence(string password)
        {
            bool isSequence = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (i + 1 < password.Length && i + 2 < password.Length)
                {
                    short next = Convert.ToInt16(password[i]);
                    char nextCharacter = Convert.ToChar(next+1);
                    short twoNext = Convert.ToInt16(password[i+1]);
                    char twoNextCharacter = Convert.ToChar(twoNext+1);
                    if (password[i + 1] == nextCharacter && twoNextCharacter == password[i + 2])
                    {
                        isSequence = true;
                        break;
                    }
                }
            }
            return isSequence;
        }

        public string GetEncryptedPassword(string password, string username)
        {
            var sha256 = new SHA256HashAlgorithm(); var sha384 = new SHA384HashAlgorithm(); var sha512 = new SHA512HashAlgorithm();
            var part1 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha256.ExecuteHMACHashAlgorithm(password, username));
            var part2 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha384.ExecuteHMACHashAlgorithm(password, password));
            var part3 = SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha512.ExecuteHMACHashAlgorithm(password, _key));
            var result = SecurityHelper.StringHelper.Reverse(part1.Substring(0, 32)) + part3.Substring(0, 64) + SecurityHelper.StringHelper.Reverse(part2.Substring(0, 32)) + part3.Substring(64, 32) + SecurityHelper.StringHelper.Reverse(part1.Substring(32, 32)) + part2.Substring(32, 32) + SecurityHelper.StringHelper.Reverse(part3.Substring(96, 32));
            return SecurityHelper.ReplaceHelper.ReplaceHashFunctionResult(sha256.ExecuteHMACHashAlgorithm(result, _finalkey));
        }
    }
}
