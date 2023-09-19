using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    public class CriteriaCreatorManager
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string ClassString { get; set; }

        public CriteriaCreatorManager(string companyName, string projectName, string projectPath, string properties, string className)
        {
            CompanyName = companyName; 
            ProjectName = projectName; 
            ProjectPath = projectPath;
            ClassName = className;

            ProjectNameRoot = CompanyName + "." + ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".ViewModels.Criteria" + Environment.NewLine;
            Path = ProjectNameRoot + ".ViewModels/Criteria";

            ClassString = "";
            ClassString += "using " + ProjectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            ClassString += "" + Environment.NewLine;
            ClassString += Namespace;
            ClassString += "{" + Environment.NewLine;
            ClassString += "    public class "+ className + " : "+projectName+"CriteriaBase" + Environment.NewLine;
            ClassString += "    {" + Environment.NewLine;
            ClassString += properties;
            ClassString += "    }" + Environment.NewLine;
            ClassString += "}" + Environment.NewLine;
        }
    }
}
