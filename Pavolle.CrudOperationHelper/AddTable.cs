using Pavolle.CrudOperationHelper.Db;
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
    public partial class AddTable : Form
    {
        string _projectName;
        public AddTable(string projectName)
        {
            _projectName = projectName;
            InitializeComponent();

            this.Text = "New Table (" + _projectName + ")";
        }

        private void buttonIntializeTable_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditTable_Click(object sender, EventArgs e)
        {
            bool result = DbManager.Instance.CreateTable(_projectName, textBoxTableName.Text, textBoxTableDbName.Text, checkBoxServiceList.Checked, checkBoxServiceLookup.Checked, checkBoxServiceAdd.Checked, checkBoxServiceEdit.Checked, checkBoxServiceDetail.Checked, checkBoxServiceDelete.Checked);

            if (result)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Tablo oluşturulamadı!");
            }
        }
    }
}
