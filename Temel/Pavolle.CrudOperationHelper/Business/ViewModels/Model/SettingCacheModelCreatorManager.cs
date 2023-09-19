using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class SettingCacheModelCreatorManager : Singleton<SettingCacheModelCreatorManager>, ICreatorManager
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
