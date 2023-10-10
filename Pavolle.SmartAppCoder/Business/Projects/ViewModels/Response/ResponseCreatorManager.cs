using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Response
{
    public class ResponseCreatorManager
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string ClassString { get; set; }

        public ResponseCreatorManager(string companyName, string projectName, string projectPath, string properties, string className, string inheritance)
        {
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ClassName = className;

            ProjectNameRoot = CompanyName + "." + ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".ViewModels.Response" + Environment.NewLine;
            Path = ProjectNameRoot + ".ViewModels/Response";

            ClassString = "";
            ClassString += "using " + companyName + ".Core.Enums;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".ViewModels.ViewData;" + Environment.NewLine;
            ClassString += "using " + companyName + ".Core.ViewModels.Response;" + Environment.NewLine;
            ClassString += "" + Environment.NewLine;
            ClassString += Namespace;
            ClassString += "{" + Environment.NewLine;
            ClassString += "    public class " + className + " : " + inheritance + Environment.NewLine;
            ClassString += "    {" + Environment.NewLine;
            ClassString += properties;
            ClassString += "    }" + Environment.NewLine;
            ClassString += "}" + Environment.NewLine;
        }
    }
}
