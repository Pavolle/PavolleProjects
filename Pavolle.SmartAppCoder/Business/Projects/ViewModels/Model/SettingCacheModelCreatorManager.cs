using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Model
{
    public class SettingCacheModelCreatorManager : Singleton<SettingCacheModelCreatorManager>
    {
        private SettingCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long Oid { get; set; }" + Environment.NewLine;
            properties += "        public ESettingType SettingType { get; set; }" + Environment.NewLine;
            properties += "        public string Value { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "SettingCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
