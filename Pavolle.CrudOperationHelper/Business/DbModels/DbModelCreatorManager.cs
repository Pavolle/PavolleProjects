using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class DbModelCreatorManager
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string DbClass { get; set; }

        public DbModelCreatorManager(string companyName, string projectName, string projectPath, string className)
        {
            ClassName = className;
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ProjectNameRoot=CompanyName+"."+ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".DbModels.Entities" + Environment.NewLine;
            Path = ProjectNameRoot + "." + "DbModels/Entities";
            DbClass = "";

        }
    }
}
