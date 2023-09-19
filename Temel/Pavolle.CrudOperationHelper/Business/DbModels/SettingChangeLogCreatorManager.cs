using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class SettingChangeLogCreatorManager : Singleton<SettingChangeLogCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private SettingChangeLogCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();

            columns.Add(new ColumnModel
            {
                Name = "Setting",
                DbName = "setting_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "Setting"
            });

            columns.Add(new ColumnModel
            {
                Name = "User",
                DbName = "user_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "User"
            });

            columns.Add(new ColumnModel
            {
                Name = "OldValue",
                DbName = "old_value",
                Size = 1000,
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
                Name = "NewValue",
                DbName = "new_value",
                Size = 1000,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "SettingChangeLog", "setting_change_logs");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
