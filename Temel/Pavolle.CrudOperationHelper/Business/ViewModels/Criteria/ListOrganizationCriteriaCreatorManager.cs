using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    internal class ListOrganizationCriteriaCreatorManager : Singleton<ListOrganizationCriteriaCreatorManager>, ICreatorManager
    {
        private ListOrganizationCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public bool? HasSubOrganization { get; set; }" + Environment.NewLine;
            properties += "        public long? CountryOid { get; set; }" + Environment.NewLine;
            properties += "        public long? CityOid { get; set; }" + Environment.NewLine;
            properties += "        public long? UpperOrganizationOid { get; set; }" + Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "ListOrganizationCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
