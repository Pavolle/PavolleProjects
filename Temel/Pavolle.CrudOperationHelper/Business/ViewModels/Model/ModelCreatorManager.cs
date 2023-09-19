using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class ModelCreatorManager
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string ClassString { get; set; }

        public ModelCreatorManager(string companyName, string projectName, string projectPath, string properties, string className)
        {
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ClassName = className;

            ProjectNameRoot = CompanyName + "." + ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".ViewModels.Model" + Environment.NewLine;
            Path = ProjectNameRoot + ".ViewModels/Model";

            ClassString = "";
            ClassString += "using " + ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            ClassString += "using " + companyName + ".Core.Enums;" + Environment.NewLine;
            ClassString += "" + Environment.NewLine;
            ClassString += Namespace;
            ClassString += "{" + Environment.NewLine;
            ClassString += "    public class " + className + Environment.NewLine;
            ClassString += "    {" + Environment.NewLine;
            ClassString += properties;
            ClassString += "    }" + Environment.NewLine;
            ClassString += "}" + Environment.NewLine;
        }
    }
}
