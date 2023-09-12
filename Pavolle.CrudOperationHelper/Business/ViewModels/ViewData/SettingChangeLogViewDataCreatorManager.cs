using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class SettingChangeLogViewDataCreatorManager : Singleton<SettingChangeLogViewDataCreatorManager>, ICreatorManager
    {
        private SettingChangeLogViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string User { get; set; }" + Environment.NewLine;
            properties += "        public string OldValue { get; set; }" + Environment.NewLine;
            properties += "        public string NewValue { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "SettingChangeLogViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
