using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    internal class JobChangeLogCreatorManager : Singleton<JobChangeLogCreatorManager>
    {
        DbModelCreatorManager creator;

        private JobChangeLogCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();
            columns.Add(new ColumnModel
            {
                Name = "Job",
                DbName = "job_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "Job"
            });

            columns.Add(new ColumnModel
            {
                Name = "OldName",
                DbName = "old_name",
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
                Name = "NewName",
                DbName = "new_name",
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
                Name = "OldCron",
                DbName = "old_cron",
                Size = 30,
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
                Name = "NewCron",
                DbName = "new_cron",
                Size = 30,
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
                Name = "OldActive",
                DbName = "old_active",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "NewActive",
                DbName = "new_active",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });



            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "JobChangeLog", "job_change_logs");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
