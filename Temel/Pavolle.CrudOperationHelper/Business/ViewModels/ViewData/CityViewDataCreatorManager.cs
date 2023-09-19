using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class CityViewDataCreatorManager : Singleton<CityViewDataCreatorManager>, ICreatorManager
    {
        private CityViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Code { get; set; }" + Environment.NewLine;
            properties += "        public long CountryOid { get; set; }" + Environment.NewLine;
            properties += "        public string CountryName { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "CityViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
