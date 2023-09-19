using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    public class EditJobRequestCreatorManager : Singleton<EditJobRequestCreatorManager>, ICreatorManager
    {
        private EditJobRequestCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Cron { get; set; }" + Environment.NewLine;
            properties += "        public bool? Active { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "EditJobRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}