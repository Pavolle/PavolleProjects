using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Request
{
    public class EditApiServiceRequestCreatorManager : Singleton<EditApiServiceRequestCreatorManager>
    {
        private EditApiServiceRequestCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ApiDefinition { get; set; }" + Environment.NewLine;
            properties += "        public List<ApiServiceAuthRequestModel> Auhtorizations { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "EditApiServiceRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
