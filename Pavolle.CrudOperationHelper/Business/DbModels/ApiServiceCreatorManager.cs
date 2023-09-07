using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    internal class ApiServiceCreatorManager : Singleton<ApiServiceCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private ApiServiceCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            bool response = true;
            creator=new DbModelCreatorManager(companyName, projectName, projectPath, "ApiService", "api_services");

            string dbEntityContent = "";
            dbEntityContent += "        [Persistent(\"api_key\")]" + Environment.NewLine;
            dbEntityContent += "        [Size(255)]" + Environment.NewLine;
            dbEntityContent += "        public string ApiKey { get; set; }" + Environment.NewLine;
            dbEntityContent += "" + Environment.NewLine;
            dbEntityContent += "        [Persistent(\"api_definition_td_oid\")]" + Environment.NewLine;
            dbEntityContent += "        [Size(255)]" + Environment.NewLine;
            dbEntityContent += "        public TranslateData ApiDefinition { get; set; }" + Environment.NewLine;
            dbEntityContent += "" + Environment.NewLine;
            dbEntityContent += "        [Persistent(\"method_type\")]" + Environment.NewLine;
            dbEntityContent += "        public EApiServiceMethodType MethodType { get; set; }" + Environment.NewLine;
            dbEntityContent += "" + Environment.NewLine;
            dbEntityContent += "        [Persistent(\"editable_for_admin\")]" + Environment.NewLine;
            dbEntityContent += "        public bool EditableForAdmin { get; set; }" + Environment.NewLine;
            dbEntityContent += "" + Environment.NewLine;
            dbEntityContent += "        [Persistent(\"editable_for_organization\")]" + Environment.NewLine;
            dbEntityContent += "        public bool EditableForOrganization { get; set; }" + Environment.NewLine;
            dbEntityContent += "" + Environment.NewLine;
            dbEntityContent += "        [Persistent(\"Anonymous\")]" + Environment.NewLine;
            dbEntityContent += "        public bool Anonymous { get; set; }" + Environment.NewLine;

            response = FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass.Replace("//<DbClassContent>", dbEntityContent));

            return response;
        }
    }
}
