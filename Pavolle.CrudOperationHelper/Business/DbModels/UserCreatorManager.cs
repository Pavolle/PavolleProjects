using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class UserCreatorManager : Singleton<UserCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private UserCreatorManager()
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
            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "JobRunLog", "job_run_logs");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
