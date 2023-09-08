using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class DbModelsCsProjectCreatorManager : Singleton<DbModelsCsProjectCreatorManager>, ICreatorManager
    {
        private DbModelsCsProjectCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string projectNameRoot=companyName+"."+projectName;
            string dbModelscsproj = "";
            dbModelscsproj += "<Project Sdk=\"Microsoft.NET.Sdk\">" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "  <PropertyGroup>" + Environment.NewLine;
            dbModelscsproj += "    <TargetFramework>net6.0</TargetFramework>" + Environment.NewLine;
            dbModelscsproj += "    <ImplicitUsings>enable</ImplicitUsings>" + Environment.NewLine;
            dbModelscsproj += "    <Nullable>enable</Nullable>" + Environment.NewLine;
            dbModelscsproj += "  </PropertyGroup>" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "  <ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "    <PackageReference Include=\"DevExpress.Xpo\" Version=\"23.1.3\" />" + Environment.NewLine;
            dbModelscsproj += "  </ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "  <ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "    <ProjectReference Include=\"..\\" + projectNameRoot + "." + AppConsts.CommonProjectName + "\\" + projectNameRoot + "." + AppConsts.CommonProjectName + ".csproj\" />" + Environment.NewLine;
            dbModelscsproj += "    <ProjectReference Include=\"..\\Pavolle.Core\\Pavolle.Core.csproj\" />" + Environment.NewLine;
            dbModelscsproj += "  </ItemGroup>" + Environment.NewLine;
            dbModelscsproj += "" + Environment.NewLine;
            dbModelscsproj += "</Project>" + Environment.NewLine;

            return FileHelperManager.Instance.EditFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName, projectNameRoot + "." + AppConsts.DBModelsProjectName + ".csproj", dbModelscsproj);
        }
    }
}
