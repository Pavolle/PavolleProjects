using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Request
{
    public class RequestBaseCreatorManager : Singleton<RequestBaseCreatorManager>
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
            classString += "using " + projectNameRoot + ".Common.Enums;" + Environment.NewLine;
            classString += "using "+companyName+".Core.ViewModels.Request;"+Environment.NewLine;
            classString += "using " + companyName + ".Core.Enums;" + Environment.NewLine;
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

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".ViewModels/Request", projectName + "RequestBase.cs", classString);
        }
    }
}
