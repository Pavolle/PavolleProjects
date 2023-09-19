using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    public class DeleteUserCriteriaCreatorManager : Singleton<DeleteUserCriteriaCreatorManager>, ICreatorManager
    {
        private DeleteUserCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public bool? ForceDelete { get; set; }" + Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "DeleteUserCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
