using System.Text;

namespace Pavolle.Security
{
    public class SecurityHelper
    {
        public class ConvertOperation
        {
            public static byte[] StringToByte(string text)
            {
                return Encoding.UTF8.GetBytes(text);
            }

            public static string ByteToString(byte[] data)
            {
                return BitConverter.ToString(data);
            }
        }

        public class ReplaceHelper
        {
            public static string ReplaceHashFunctionResult(string result)
            {
                return result.Replace("-", "");
            }
        }

        public class StringHelper
        {
            public static string ReverseXor(string s)
            {
                if (s == null) return null;
                char[] charArray = s.ToCharArray();
                int len = s.Length - 1;
                for (int i = 0; i < len; i++, len--)
                {
                    charArray[i] ^= charArray[len];
                    charArray[len] ^= charArray[i];
                    charArray[i] ^= charArray[len];
                }
                return new string(charArray);
            }

            public static string Reverse(string text)
            {
                if (text == null) return null;
                char[] array = text.ToCharArray();
                Array.Reverse(array);
                return new String(array);
            }

            public static string ReverseString(string srtVarable)
            {
                return new string(srtVarable.Reverse().ToArray());
            }
        }
    }
}
