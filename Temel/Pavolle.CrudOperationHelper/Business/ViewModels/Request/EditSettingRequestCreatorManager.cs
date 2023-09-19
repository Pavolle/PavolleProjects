using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    internal class EditSettingRequestCreatorManager : Singleton<EditSettingRequestCreatorManager>, ICreatorManager
    {
        private EditSettingRequestCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string SettingName { get; set; }" + Environment.NewLine;
            properties += "        public string Value { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "EditSettingRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
