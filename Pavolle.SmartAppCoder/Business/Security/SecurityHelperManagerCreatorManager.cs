using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Security
{
    public class SecurityHelperManagerCreatorManager : Singleton<SecurityHelperManagerCreatorManager>
    {
        private SecurityHelperManagerCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Security", "", "SecurityHelper.cs", classString);

        }
    }
}
