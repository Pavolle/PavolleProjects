using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.Common.Enums
{
    public class CommonEnumCreatorManager
    {
        public string CompanyName{get;set;}
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string EnumClass = "";

        public CommonEnumCreatorManager(string companyName, string projectName, string projectPath, string className)
        {
            ClassName = className;
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ProjectNameRoot = CompanyName + "." + ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".Common.Enums" + Environment.NewLine;
            Path = ProjectNameRoot + "." + "Common/Enums";
            EnumClass += Namespace;
            EnumClass += "{" + Environment.NewLine;
            EnumClass += "    public enum " +ClassName+Environment.NewLine;
            EnumClass += "    {" + Environment.NewLine;
            EnumClass += "//<EnumContent>";
            EnumClass += "    }" + Environment.NewLine;
            EnumClass += "}" + Environment.NewLine;
        }
    }
}
