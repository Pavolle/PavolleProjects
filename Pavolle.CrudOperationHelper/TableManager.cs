using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper
{
    public class TableManager:Singleton<TableManager>
    {
        private Table _table=null;
        private TableManager()
        {
            _table = new Table();
        }

        public Table GetTable()
        {
            return _table;
        }

        public void AddColumn(ColumnModel column)
        {
            _table.Columns.Add(column);
        }

        public void SaveColumn(ColumnModel column)
        {
            _table.Columns.Add(column);
        }

        public void DeleteColumn(ColumnModel column)
        {
            _table.Columns.Add(column);
        }

        internal void SetProjectNameRoot(string text)
        {
            _table.ProjectNameRoot = text;
        }

        internal void SetTableName(string text)
        {
            _table.TableDbName = text;
        }

        internal void SetClasstName(string text)
        {
            _table.TableClassName = text;
        }

        internal void SetListService(bool ischecked)
        {
            _table.ListService= ischecked;
        }

        internal void SetLookupService(bool ischecked)
        {
            _table.LookupService = ischecked;
        }

        internal void SetDetailService(bool ischecked)
        {
            _table.DetailService = ischecked;
        }

        internal void SetAddService(bool ischecked)
        {
            _table.AddService = ischecked;
        }

        internal void SetEditService(bool ischecked)
        {
            _table.EditService = ischecked;
        }

        internal void SetDeleteService(bool ischecked)
        {
            _table.DeleteService = ischecked;
        }

        internal void SetProjectName(string text)
        {
            _table.ProjectName = text;
        }
    }
}
