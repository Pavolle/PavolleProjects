using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    public class OrganizationCreatorManager : Singleton<OrganizationCreatorManager>
    {
        DbModelCreatorManager creator;

        private OrganizationCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            List<ColumnModel> columns = new List<ColumnModel>();

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
                Name = "Code",
                DbName = "code",
                Size = 5,
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
                Name = "Address",
                DbName = "address",
                Size = 1000,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "Langitude",
                DbName = "langitude",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.DOUBLE,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "Latitude",
                DbName = "latitude",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.DOUBLE,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = null
            });

            columns.Add(new ColumnModel
            {
                Name = "UpperOrganization",
                DbName = "upper_organization_oid",
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
                Name = "Country",
                DbName = "country_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "Country"
            });

            columns.Add(new ColumnModel
            {
                Name = "City",
                DbName = "city_oid",
                Size = 0,
                TranslatableStringData = false,
                DataType = EDataType.CLASS,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = "City"
            });

            columns.Add(new ColumnModel
            {
                Name = "ZipCode",
                DbName = "zip_code",
                Size = 20,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = ""
            });

            columns.Add(new ColumnModel
            {
                Name = "LogoBase64",
                DbName = "logo_base64",
                Size = 3000,
                TranslatableStringData = false,
                DataType = EDataType.STRING,
                Nullable = true,
                Index = false,
                UniqueIndex = false,
                EnumClass = null,
                TableClass = ""
            });

            creator = new DbModelCreatorManager(companyName, projectName, projectPath, columns, "Organization", "organizations");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.DbClass);
        }
    }
}
