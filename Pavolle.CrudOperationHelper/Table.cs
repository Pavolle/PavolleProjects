using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper
{
    public class Table
    {
        public string ProjectName { get; set; } = string.Empty;
        public string TableClassName { get; set; } = string.Empty;
        public string TableDbName { get; set; } = string.Empty;
        public bool ListService { get; set; }
        public bool LookupService { get; set; }
        public bool DetailService { get; set; }
        public bool AddService { get; set; }
        public bool EditService { get; set; }
        public bool DeleteService { get; set; }

        public List<ColumnModel> Columns { get; set; } = new List<ColumnModel>();
    }

    public class ColumnModel
    {
        public string Name { get; set; } = string.Empty; //Unique
        public string DbName { get; set; } = string.Empty; //Unique
        public EDataType DataType { get; set; }
        public int Size { get; set; }
        public string EnumClass { get; set; } = string.Empty;
        public bool Nullable { get; set; }
        public string TableClass { get; set; }
        public bool Index { get; set; }
        public bool UniqueIndex { get; set; }


        public bool AddToListService { get; set; }
        public bool AddToLookupService { get; set; }
        public bool AddToDetailService { get; set; }
        public bool Addable { get; set; }
        public bool Editable { get; set; }
        public bool AddToCriteria { get; set; }


    }

    public enum EDataType
    {
        LONG,
        STRING,
        INT,
        FLOAT,
        DOUBLE,
        ENUM,
        CLASS
    }
}
