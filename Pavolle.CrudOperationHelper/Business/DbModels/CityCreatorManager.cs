using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class CityCreatorManager : Singleton<CityCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private CityCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();
            columns.Add(new ColumnModel
            {
                Name = "Code",
                DbName = "code",
                Size = 20,
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
                Name = "Country",
                DbName = "country_oid",
                Size = 3,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "Country"
            });
            columns.Add(new ColumnModel
            {
                Name = "Name",
                DbName = "name_td_oid",
                Size = 0,
                TranslatableStringData = true,
                DataType = EDataType.STRING,
                Nullable = false,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });



            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "City", "cities");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
