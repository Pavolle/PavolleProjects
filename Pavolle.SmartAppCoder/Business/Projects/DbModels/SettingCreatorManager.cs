using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    public class SettingCreatorManager : Singleton<SettingCreatorManager>
    {
        DbModelCreatorManager creator;

        private SettingCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();

            columns.Add(new ColumnModel
            {
                Name = "SettingType",
                DbName = "setting_type",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.ENUM,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "ESettingType",
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "SettingName",
                DbName = "setting_name",
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
                Name = "Value",
                DbName = "value",
                Size = 1000,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "Setting", "settings");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
