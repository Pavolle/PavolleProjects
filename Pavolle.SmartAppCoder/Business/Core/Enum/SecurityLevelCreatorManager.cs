using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.Enum
{
    public class SecurityLevelCreatorManager : Singleton<SecurityLevelCreatorManager>
    {
        private SecurityLevelCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string content = "";
            content += "        Low = 1," + Environment.NewLine;
            content += "        Strong = 2," + Environment.NewLine;
            content += "        Master = 2" + Environment.NewLine;
            string classString = EnumClassGenerator.Instance.Generate(organizationName + ".Core.Enums", "ESecurityLevel", content);
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "Enums", "ESecurityLevel.cs", classString);

        }
    }
}
