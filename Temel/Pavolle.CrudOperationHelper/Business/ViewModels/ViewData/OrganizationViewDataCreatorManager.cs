using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class OrganizationViewDataCreatorManager : Singleton<OrganizationViewDataCreatorManager>, ICreatorManager
    {
        private OrganizationViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Code { get; set; }" + Environment.NewLine;
            properties += "        public string Address { get; set; }" + Environment.NewLine;
            properties += "        public string LogoBase64 { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "OrganizationViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
