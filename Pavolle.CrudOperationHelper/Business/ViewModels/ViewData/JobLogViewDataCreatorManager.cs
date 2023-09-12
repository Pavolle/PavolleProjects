using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class JobLogViewDataCreatorManager : Singleton<JobLogViewDataCreatorManager>, ICreatorManager
    {
        private JobLogViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public DateTime StartTime { get; set; }" + Environment.NewLine;
            properties += "        public DateTime EndTime { get; set; }" + Environment.NewLine;
            properties += "        public bool Success { get; set; }" + Environment.NewLine;
            properties += "        public string Result { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "JobLogViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
