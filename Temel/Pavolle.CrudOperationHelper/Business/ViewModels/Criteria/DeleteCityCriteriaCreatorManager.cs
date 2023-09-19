using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.Metadata.ReflectionClassInfo;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    public class DeleteCityCriteriaCreatorManager : Singleton<DeleteCityCriteriaCreatorManager>, ICreatorManager
    {
        private DeleteCityCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties="";
            properties += "        public bool? ForceDelete { get; set; }" + Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "DeleteCityCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
