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
            classString += "using System.Text;" + Environment.NewLine;
            classString += "namespace Pavolle.Security" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class SecurityHelper" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public class ConvertOperation" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public static byte[] StringToByte(string text)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                return Encoding.UTF8.GetBytes(text);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "            public static string ByteToString(byte[] data)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                return BitConverter.ToString(data);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class ReplaceHelper" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public static string ReplaceHashFunctionResult(string result)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                return result.Replace(\"-\", \"\");" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public class StringHelper" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            public static string ReverseXor(string s)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (s == null) return null;" + Environment.NewLine;
            classString += "                char[] charArray = s.ToCharArray();" + Environment.NewLine;
            classString += "                int len = s.Length - 1;" + Environment.NewLine;
            classString += "                for (int i = 0; i < len; i++, len--)" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    charArray[i] ^= charArray[len];" + Environment.NewLine;
            classString += "                    charArray[len] ^= charArray[i];" + Environment.NewLine;
            classString += "                    charArray[i] ^= charArray[len];" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "                return new string(charArray);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "            public static string Reverse(string text)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (text == null) return null;" + Environment.NewLine;
            classString += "                char[] array = text.ToCharArray();" + Environment.NewLine;
            classString += "                Array.Reverse(array);" + Environment.NewLine;
            classString += "                return new String(array);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "            public static string ReverseString(string srtVarable)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                return new string(srtVarable.Reverse().ToArray());" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "", "SecurityHelper.cs", classString);

        }
    }
}
