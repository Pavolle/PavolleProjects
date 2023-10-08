using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    internal class ApiServiceCreatorManager : Singleton<ApiServiceCreatorManager>
    {
        DbModelCreatorManager creator;

        private ApiServiceCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            bool response = true;

            List<ColumnModel> columns = new List<ColumnModel>();
            columns.Add(new ColumnModel
            {
                Name = "ApiKey",
                DbName = "api_key",
                Size = 255,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = false,
                Index = true,
                UniqueIndex = true,
                EnumClass = null,
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "ApiDefinition",
                DbName = "api_definition",
                Size = 255,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "MethodType",
                DbName = "method_type",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.ENUM,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "EApiServiceMethodType",
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "EditableForAdmin",
                DbName = "editable_for_admin",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "",
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "EditableForOrganization",
                DbName = "editable_for_organization",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "",
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "Anonymous",
                DbName = "anonymous",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "",
                TableClass = null
            });


            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "ApiService", "api_services");

            response = FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);

            return response;
        }
    }
}
