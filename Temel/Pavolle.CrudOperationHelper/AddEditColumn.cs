using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pavolle.CrudOperationHelper
{
    public partial class AddEditColumn : Form
    {
        ColumnModel _columnModel;
        public AddEditColumn(ColumnModel column)
        {
            InitializeComponent();
            _columnModel = column;

            if (column == null)
            {
                _columnModel = new ColumnModel();
                labelSize.Visible = false;
                textBoxSize.Visible = false;

                labelEnumClass.Visible = false;
                textBoxEnumClassName.Visible = false;

                labelTableClass.Visible = false;
                textBoxTableClass.Visible = false;
            }
            else
            {
                textBoxName.Text = _columnModel.Name;
                textBoxDbColumnName.Text = _columnModel.DbName;
                comboBox1.SelectedItem= _columnModel.DataType.ToString();
                textBoxSize.Text=_columnModel.Size.ToString();
                textBoxEnumClassName.Text = _columnModel.EnumClass;
                textBoxTableClass.Text=_columnModel.TableClass;
                checkBoxIndex.Checked = _columnModel.Index;
                checkBoxUniqueIndex.Checked = _columnModel.UniqueIndex;
                checkBoxColumnAddToList.Checked=_columnModel.AddToListService;
                checkBoxColumnAddToDetail.Checked=_columnModel.AddToDetailService;
                checkBoxColumnCanAdd.Checked = _columnModel.Addable;
                checkBoxColumnCanEdit.Checked = _columnModel.Editable;
                checkBoxColumnAddToCriteria.Checked = _columnModel.AddToCriteria;
                checkBoxNullable.Checked= _columnModel.Nullable;
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditColumn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBoxName.Text))
                {
                    MessageBox.Show("Parametreleri kontrol ediniz! Kolon ismi boş!");
                    return;
                }
                if (string.IsNullOrEmpty(textBoxDbColumnName.Text))
                {
                    MessageBox.Show("Parametreleri kontrol ediniz! Tablo Kolon ismi boş!");
                    return;
                }
                string selectedItem = (string)comboBox1.SelectedItem;
                if (string.IsNullOrEmpty(selectedItem))
                {
                    MessageBox.Show("Parametreleri kontrol ediniz! Veri tipi alanı boş!");
                    return;
                }
                var data = new ColumnModel
                {
                    Name = textBoxName.Text,
                    DbName = textBoxDbColumnName.Text,
                    Size = textBoxSize.Text == "" ? 0 : Convert.ToInt32(textBoxSize.Text),
                    EnumClass = textBoxEnumClassName.Text,
                    Index = checkBoxIndex.Checked,
                    UniqueIndex = checkBoxUniqueIndex.Checked,
                    AddToListService = checkBoxColumnAddToList.Checked,
                    AddToDetailService = checkBoxColumnAddToDetail.Checked,
                    Addable = checkBoxColumnCanAdd.Checked,
                    Editable = checkBoxColumnCanEdit.Checked,
                    AddToCriteria = checkBoxColumnAddToCriteria.Checked,
                    Nullable = checkBoxNullable.Checked
                };
                switch (selectedItem)
                {
                    case "LONG":
                        data.DataType = EDataType.LONG;
                        break;

                    case "STRING":
                        data.DataType = EDataType.STRING;
                        break;

                    case "INT":
                        data.DataType = EDataType.INT;
                        break;

                    case "FLOAT":
                        data.DataType = EDataType.FLOAT;
                        break;

                    case "DOUBLE":
                        data.DataType = EDataType.DOUBLE;
                        break;

                    case "ENUM":
                        data.DataType = EDataType.ENUM;
                        break;

                    case "CLASS":
                        data.DataType = EDataType.CLASS;
                        break;

                    case "DATETIME":
                        data.DataType = EDataType.DATETIME;
                        break;

                    case "BOOL":
                        data.DataType = EDataType.BOOL;
                        break;

                    default:
                        break;
                }

                TableManager.Instance.SaveColumn(data);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Parametreleri kontrol ediniz!");
            }
            
        }

        private void AddEditColumn_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = (string)((ComboBox)sender).SelectedItem;
            switch (selectedItem)
            {
                case "LONG":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "STRING":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = true;
                    textBoxSize.Visible = true;
                    textBoxSize.Text = "100";

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;

                    checkBoxNullable.Visible = true;
                    break;

                case "INT":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = true;
                    textBoxSize.Visible = true;
                    textBoxSize.Text = "100";

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "FLOAT":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "DOUBLE":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "DATETIME":
                    _columnModel.DataType = EDataType.DATETIME;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "BOOL":
                    _columnModel.DataType = EDataType.BOOL;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "ENUM":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = true;
                    textBoxEnumClassName.Visible = true;

                    labelTableClass.Visible = false;
                    textBoxTableClass.Visible = false;


                    checkBoxNullable.Visible = true;
                    break;

                case "CLASS":
                    _columnModel.DataType = EDataType.LONG;
                    labelSize.Visible = false;
                    textBoxSize.Visible = false;

                    labelEnumClass.Visible = false;
                    textBoxEnumClassName.Visible = false;

                    labelTableClass.Visible = true;
                    textBoxTableClass.Visible = true;

                    checkBoxNullable.Visible = false;
                    break;

                default:
                    break;
            }
        }
    }
}
