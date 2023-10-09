using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Request
{
    public class EditApiServiceRequestCreatorManager : Singleton<EditApiServiceRequestCreatorManager>
    {
        private EditApiServiceRequestCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ApiDefinition { get; set; }" + Environment.NewLine;
            properties += "        public List<ApiServiceAuthRequestModel> Auhtorizations { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "EditApiServiceRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
