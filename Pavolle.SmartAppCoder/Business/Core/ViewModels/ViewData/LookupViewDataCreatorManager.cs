using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.ViewData
{
    public class LookupViewDataCreatorManager : Singleton<LookupViewDataCreatorManager>
    {
        private LookupViewDataCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Core.ViewModels.ViewData" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class LookupViewData" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public long Key { get; set; }" + Environment.NewLine;
            classString += "        public string Value { get; set; }" + Environment.NewLine;
            classString += "        public bool IsDefault { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\ViewData", "LookupViewData.cs", classString);

        }
    }
}
