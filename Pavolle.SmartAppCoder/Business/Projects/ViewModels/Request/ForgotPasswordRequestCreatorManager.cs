using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Request
{
    internal class ForgotPasswordRequestCreatorManager : Singleton<ForgotPasswordRequestCreatorManager>
    {
        private ForgotPasswordRequestCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Username { get; set; }" + Environment.NewLine;
            properties += "        public ECommunicationType? CommunicationType { get; set; }" + Environment.NewLine;
            properties += "        public string CommunicationValue { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "ForgotPasswordRequest", "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
