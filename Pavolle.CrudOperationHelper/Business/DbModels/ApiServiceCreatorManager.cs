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
            creator=new DbModelCreatorManager(companyName, projectName, projectPath, "ApiService");

            string apiServiceClass = "";
            apiServiceClass += "using DevExpress.Xpo;" + Environment.NewLine;
            apiServiceClass += "using " + creator.ProjectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += creator.Namespace;
            apiServiceClass += "{" + Environment.NewLine;
            apiServiceClass += "    [Persistent(\"api_services\")]" + Environment.NewLine;
            apiServiceClass += "    public class " + creator.ClassName + " : " + AppConsts.DBModelsBaseObjectClassName + "" + Environment.NewLine;
            apiServiceClass += "    {" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        public " + creator.ClassName + "(Session session) : base(session) {}" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"api_key\")]" + Environment.NewLine;
            apiServiceClass += "        [Size(255)]" + Environment.NewLine;
            apiServiceClass += "        public string ApiKey { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"api_definition_td_oid\")]" + Environment.NewLine;
            apiServiceClass += "        [Size(255)]" + Environment.NewLine;
            apiServiceClass += "        public TranslateData ApiDefinition { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"method_type\")]" + Environment.NewLine;
            apiServiceClass += "        public EApiServiceMethodType MethodType { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"editable_for_admin\")]" + Environment.NewLine;
            apiServiceClass += "        public bool EditableForAdmin { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"editable_for_organization\")]" + Environment.NewLine;
            apiServiceClass += "        public bool EditableForOrganization { get; set; }" + Environment.NewLine;
            apiServiceClass += "" + Environment.NewLine;
            apiServiceClass += "        [Persistent(\"Anonymous\")]" + Environment.NewLine;
            apiServiceClass += "        public bool Anonymous { get; set; }" + Environment.NewLine;
            apiServiceClass += "    }" + Environment.NewLine;
            apiServiceClass += "}" + Environment.NewLine;

            response = FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", apiServiceClass);

            return response;
        }
    }
}
