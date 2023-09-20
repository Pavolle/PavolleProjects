using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.Metadata.ReflectionClassInfo;

namespace Pavolle.SmartAppCoder.Business.Core.Utils
{
    public class EnumExtensionsCreatorManager :Singleton<EnumExtensionsCreatorManager>
    {
        private EnumExtensionsCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString="";
            classString += "using System.ComponentModel;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Core.Utils" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public static class EnumExtensions" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public static string Description(this Enum value)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                var enumType = value.GetType();" + Environment.NewLine;
            classString += "                var field = enumType.GetField(value.ToString());" + Environment.NewLine;
            classString += "                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);" + Environment.NewLine;
            classString += "                return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                return value.ToString();" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "Utils", "EnumExtensions.cs", classString);

        }
    }
}
