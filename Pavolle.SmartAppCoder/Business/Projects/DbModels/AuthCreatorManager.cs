using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    public class AuthCreatorManager : Singleton<AuthCreatorManager>
    {
        DbModelCreatorManager creator;

        private AuthCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            bool response=false;
            List<ColumnModel> columns = new List<ColumnModel>();
            columns.Add(new ColumnModel
            {
                Name = "ApiService",
                DbName = "api_service_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "ApiService"
            });
            columns.Add(new ColumnModel
            {
                Name = "UserGroup",
                DbName = "user_group_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "UserGroup"
            });
            columns.Add(new ColumnModel
            {
                Name = "IsAuhtority",
                DbName = "is_authority",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = ""
            });


            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "Auth", "authorizations");

            response = FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);

            return response;
        }
    }
}
