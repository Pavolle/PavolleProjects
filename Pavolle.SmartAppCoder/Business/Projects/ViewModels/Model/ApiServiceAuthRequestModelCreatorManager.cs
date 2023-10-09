using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Model
{
    public class ApiServiceAuthRequestModelCreatorManager : Singleton<ApiServiceAuthRequestModelCreatorManager>
    {
        private ApiServiceAuthRequestModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long UserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public bool IsAuthority { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "ApiServiceAuthRequestModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
