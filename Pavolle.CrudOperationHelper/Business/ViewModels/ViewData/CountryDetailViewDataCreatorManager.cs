using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class CountryDetailViewDataCreatorManager : Singleton<CountryDetailViewDataCreatorManager>, ICreatorManager
    {
        private CountryDetailViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ISOCode2 { get; set; }" + Environment.NewLine;
            properties += "        public string ISOCode3 { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneCode { get; set; }" + Environment.NewLine;
            properties += "        public long NameTranslateDataOid { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "CountryDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
