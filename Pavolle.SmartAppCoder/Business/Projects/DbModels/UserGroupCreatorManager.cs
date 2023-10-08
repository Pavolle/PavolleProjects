using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    public class UserGroupCreatorManager : Singleton<UserGroupCreatorManager>
    {
        DbModelCreatorManager creator;

        private UserGroupCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();
            columns.Add(new ColumnModel
            {
                Name = "Organization",
                DbName = "organization_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "Organization"
            });
            columns.Add(new ColumnModel
            {
                Name = "Name",
                DbName = "name",
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
                Name = "UserType",
                DbName = "user_type",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.ENUM,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "EUserType",
                TableClass = null
            });
            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "UserGroup", "user_groups");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
