using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.ViewData
{
    internal class ViewDataBaseCreatorManager : Singleton<ViewDataBaseCreatorManager>
    {
        private ViewDataBaseCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Core.ViewModels.ViewData" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class ViewDataBase" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public long Oid { get; set; }" + Environment.NewLine;
            classString += "        public DateTime CreatedTime { get; set; }" + Environment.NewLine;
            classString += "        public DateTime? LastUpdateTime { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\ViewData", "ViewDataBase.cs", classString);

        }
    }
}
