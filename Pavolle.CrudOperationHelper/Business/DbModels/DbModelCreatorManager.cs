using Pavolle.CrudOperationHelper.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class DbModelCreatorManager
    {
        private List<ColumnModel> columns;
        private string v1;
        private string v2;

        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string DbClass { get; set; }

        public DbModelCreatorManager(string companyName, string projectName, string projectPath, List<ColumnModel> columns, string className, string tableName)
        {
            ClassName = className;
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ProjectNameRoot=CompanyName+"."+ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".DbModels.Entities" + Environment.NewLine;
            Path = ProjectNameRoot + "." + "DbModels/Entities";

            DbClass = "";
            DbClass += "using DevExpress.Xpo;" + Environment.NewLine;
            DbClass += "using " + ProjectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + ";" + Environment.NewLine;
            DbClass += "" + Environment.NewLine;
            DbClass += Namespace;
            DbClass += "{" + Environment.NewLine;
            DbClass += "    [Persistent(\""+tableName+"\")]" + Environment.NewLine;
            DbClass += "    public class " + ClassName + " : " + AppConsts.DBModelsBaseObjectClassName + "" + Environment.NewLine;
            DbClass += "    {" + Environment.NewLine;
            DbClass += "        public " + ClassName + "(Session session) : base(session) {}" + Environment.NewLine;
            DbClass += "" + Environment.NewLine;
            foreach (var column in columns)
            {
                DbClass += "        [Persistent(\"" + column.DbName + "\")]" + Environment.NewLine;
                if (column.Index)
                {
                    DbClass += "        [Indexed(Unique = " + (column.UniqueIndex ? "true" : "false") + ", Name = \"index_" + tableName + "_" + column.DbName + "\")]" + Environment.NewLine;
                }
                if (column.DataType == EDataType.STRING && !column.TranslatableStringData)
                {
                    DbClass += "        [Size(" + column.Size + ")]" + Environment.NewLine;
                }
                switch (column.DataType)
                {
                    case EDataType.LONG:
                        DbClass += "        public long" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.STRING:
                        if (column.TranslatableStringData)
                        {
                            DbClass += "        public TranslateData " + column.Name + " { get; set; }" + Environment.NewLine;
                        }
                        else
                        {
                            DbClass += "        public string " + column.Name + " { get; set; }" + Environment.NewLine;
                        }
                        break;
                    case EDataType.INT:
                        DbClass += "        public int" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.FLOAT:
                        DbClass += "        public float" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DOUBLE:
                        DbClass += "        public double" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.BOOL:
                        DbClass += "        public bool" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.DATETIME:
                        DbClass += "        public DateTime" + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.ENUM:
                        DbClass += "        public " + column.EnumClass + (column.Nullable ? "?" : "").ToString() + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    case EDataType.CLASS:
                        DbClass += "        public " + column.TableClass + " " + column.Name + " { get; set; }" + Environment.NewLine;
                        break;
                    default:
                        break;
                }

                DbClass += "" + Environment.NewLine;
            }
            DbClass += "    }" + Environment.NewLine;
            DbClass += "}" + Environment.NewLine;

        }
    }
}
