using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class JobCreatorManager : Singleton<JobCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private JobCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();

            columns.Add(new ColumnModel
            {
                Name = "JobType",
                DbName = "job_type",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.ENUM,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = "EJobType",
                TableClass = ""
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
                TableClass = "Country"
            });
            columns.Add(new ColumnModel
            {
                Name = "Cron",
                DbName = "cron",
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
                Name = "LastRunTime",
                DbName = "last_run_time",
                Size = 0,
                TranslatableStringData = true,
                DataType = EDataType.DATETIME,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });
            columns.Add(new ColumnModel
            {
                Name = "Active",
                DbName = "active",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });



            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "Job", "jobs");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
