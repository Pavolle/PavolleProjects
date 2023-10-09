using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class SettingChangeLogViewDataCreatorManager : Singleton<SettingChangeLogViewDataCreatorManager>
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
