using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class ApiServiceDetailViewDataCreatorManager : Singleton<ApiServiceDetailViewDataCreatorManager>
    {
        private ApiServiceDetailViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ApiKey { get; set; }" + Environment.NewLine;
            properties += "        public string ApiDefinition { get; set; }" + Environment.NewLine;
            properties += "        public EApiServiceMethodType MethodType { get; set; }" + Environment.NewLine;
            properties += "        public bool EditableForAdmin { get; set; }" + Environment.NewLine;
            properties += "        public bool EditableForOrganization { get; set; }" + Environment.NewLine;
            properties += "        public bool Anonymous { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "ApiServiceDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
