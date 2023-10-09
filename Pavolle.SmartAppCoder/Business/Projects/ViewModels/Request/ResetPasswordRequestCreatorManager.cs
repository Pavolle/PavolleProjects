using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Request
{
    public class ResetPasswordRequestCreatorManager : Singleton<ResetPasswordRequestCreatorManager>
    {
        private ResetPasswordRequestCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string NewPassword { get; set; }" + Environment.NewLine;
            properties += "        public string NewPasswordAgain { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "ResetPasswordRequest", "VerifyCodeRequest");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}