using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    public class LookupCityCriteriaCreatorManager : Singleton<LookupCityCriteriaCreatorManager>, ICreatorManager
    {
        private LookupCityCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long? CountryOid { get; set; }" + Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "LookupCityCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}

