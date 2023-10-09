using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class UserGroupAuthViewDataCreatorManager : Singleton<UserGroupAuthViewDataCreatorManager>
    {
        private UserGroupAuthViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long ApiServiceOid { get; set; }" + Environment.NewLine;
            properties += "        public string ApiServiceName { get; set; }" + Environment.NewLine;
            properties += "        public bool IsAuhority { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "UserGroupAuthViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
