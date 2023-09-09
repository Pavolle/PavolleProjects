using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    public class RequestBaseCreatorManager : Singleton<RequestBaseCreatorManager>, ICreatorManager
    {
        private RequestBaseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string projectNameRoot = companyName + "." + projectName;
            string Namespace = "namespace " + projectNameRoot + ".ViewModels.Request" + Environment.NewLine;
            string path = projectNameRoot + ".ViewModels/Request;";

            string classString = "";
            classString += "using " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            classString += "using Pavolle.Core.ViewModels.Request"+Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += Namespace;
            classString += "{" + Environment.NewLine;
            classString += "    public class " + projectName + "RequestBase : RequestBase" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public string? Username { get; set; }" + Environment.NewLine;
            classString += "        public EUserType? UserType { get; set; }" + Environment.NewLine;
            classString += "        public long? UserGroupOid { get; set; }" + Environment.NewLine;
            classString += "        public string? SessionId { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.ViewModelsProjectName + "/" + AppConsts.ViewModelsRequestFolderName, projectName + AppConsts.ViewModelsRequestBaseClassName + ".cs", classString);
        }
    }
}
