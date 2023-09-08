using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class JobRunLogCreatorManager : Singleton<JobRunLogCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private JobRunLogCreatorManager()
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
                Name = "StartTime",
                DbName = "start_time",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.DATETIME,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "Country"
            });
            columns.Add(new ColumnModel
            {
                Name = "EndTime",
                DbName = "end_time",
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
                Name = "Success",
                DbName = "success",
                Size = 0,
                TranslatableStringData = true,
                DataType = EDataType.BOOL,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });
            columns.Add(new ColumnModel
            {
                Name = "Result",
                DbName = "result",
                Size = 1000,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });



            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "JobRunLog", "job_run_logs");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
