using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.Enum
{
    public class JobStatusCreatorManager : Singleton<JobStatusCreatorManager>
    {
        private JobStatusCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string content = "";
            content += "        Start = 1," + Environment.NewLine;
            content += "        Started = 2," + Environment.NewLine;
            content += "        Paused = 3," + Environment.NewLine;
            content += "        Resumed = 4," + Environment.NewLine;
            content += "        Stopped = 5" + Environment.NewLine;
            string classString = EnumClassGenerator.Instance.Generate(organizationName + ".Core.Enums", "EJobStatus", content);
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "Enums", "EJobStatus.cs", classString);

        }
    }
}
