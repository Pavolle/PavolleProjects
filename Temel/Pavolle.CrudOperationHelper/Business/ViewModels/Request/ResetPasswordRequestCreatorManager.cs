using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
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