using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business
{
    public class EnumClassGenerator : Singleton<EnumClassGenerator>
    {
        private EnumClassGenerator() { }

        public string Generate(string namespaceHeader, string className, string content) 
        {
            string classString = "";
            classString += "using System.ComponentModel;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + namespaceHeader + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public enum " + className + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += content;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return classString;
        }
    }
}
