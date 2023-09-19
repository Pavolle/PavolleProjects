using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.Common.Enums
{
    public class SettingTypeCreatorManager : Singleton<SettingTypeCreatorManager> , ICreatorManager
    {
        CommonEnumCreatorManager _creator;
        private SettingTypeCreatorManager() { }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            _creator = new CommonEnumCreatorManager(companyName, projectName, projectPath, "ESettingType");
            string icerik = "";
            icerik += "        SchedulerControlCron = 1," + Environment.NewLine;
            icerik += "        SecurityLevel = 2," + Environment.NewLine;
            icerik += "        DefaultLanguage = 3," + Environment.NewLine;
            icerik += "        ResetCodeLenght = 4," + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs", _creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}

