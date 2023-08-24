using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pavolle.CrudOperationHelper
{
    public partial class TableGenrator : Form
    {
        ColumnModel _selectedColumn = null;
        public TableGenrator()
        {
            InitializeComponent();
            RefreshColumnList();
            groupBox2.Visible = false;
        }

        private void listBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            var table = TableManager.Instance.GetTable();
            string text = (string)((ListBox)sender).SelectedItem;
            _selectedColumn = table.Columns.FirstOrDefault(t => t.Name == text);
            if (_selectedColumn != null)
            {
                textBoxColumnName.Text = _selectedColumn.Name;
                textBoxDbColumnName.Text = _selectedColumn.DbName;
                textBoxDataType.Text=_selectedColumn.DataType.ToString();
                if (_selectedColumn.DataType == EDataType.STRING)
                {
                    textBoxSize.Text=_selectedColumn.Size.ToString();
                }
                else
                {
                    textBoxSize.Text = "Gerekli Değil!";
                }

                if (_selectedColumn.DataType == EDataType.ENUM)
                {
                    textBoxEnumClassName.Text = _selectedColumn.EnumClass;
                }
                else
                {
                    textBoxEnumClassName.Text = "Gerekli Değil!";
                }

                if (_selectedColumn.DataType == EDataType.CLASS)
                {
                    textBoxTableClass.Text = _selectedColumn.TableClass;
                }
                else
                {
                    textBoxTableClass.Text = "Gerekli Değil!";
                }

                if(_selectedColumn.DataType == EDataType.CLASS || _selectedColumn.DataType == EDataType.STRING)
                {
                    textBoxNullable.Text = "Gerekli Değil";
                }
                else
                {
                    textBoxNullable.Text = _selectedColumn.Nullable ? "Zorunlu Alan" : "Zorunlu Değil!";
                }
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            AddEditColumn column = new AddEditColumn(null);
            column.ShowDialog();

            RefreshColumnList();
        }

        private void RefreshColumnList()
        {
            listBoxColumns.Items.Clear();
            var table = TableManager.Instance.GetTable();
            foreach (var item in table.Columns)
            {
                listBoxColumns.Items.Add(item.Name);
            }
        }

        private void buttonEditColumn_Click(object sender, EventArgs e)
        {
            AddEditColumn column = new AddEditColumn(_selectedColumn);
            column.ShowDialog();

        }

        private void buttonDeleteColumn_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            TableManager.Instance.SetProjectName(textBoxProjectName.Text);
            TableManager.Instance.SetTableName(textBoxDbName.Text);
            TableManager.Instance.SetClasstName(textBoxClassName.Text);
            TableManager.Instance.SetListService(checkBoxServiceList.Checked);
            TableManager.Instance.SetLookupService(checkBoxServiceLookup.Checked);
            TableManager.Instance.SetDetailService(checkBoxServiceDetail.Checked);
            TableManager.Instance.SetAddService(checkBoxServiceAdd.Checked);
            TableManager.Instance.SetEditService(checkBoxServiceEdit.Checked);
            TableManager.Instance.SetDeleteService(checkBoxServiceDelete.Checked);
            CreateOperationProcess process=new CreateOperationProcess();
            process.ShowDialog();
        }
    }
}
