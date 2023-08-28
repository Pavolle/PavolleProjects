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
    public partial class EditProject : Form
    {
        string _name;
        string _path;
        string _root;
        string _userType;
        public EditProject(string name, string root, string path, string userType)
        {
            InitializeComponent();
            _name = name;
            _path = path;
            _root = root;
            _userType = userType;

            this.Text = "Edit Project (" + name + ")";
            textBoxProjectNameRoot.Text = _root;
            textBoxProjectsPath.Text = _path;
            textBoxUserTypes.Text = _userType;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butttonCreate_Click(object sender, EventArgs e)
        {
            bool response = DbManager.Instance.EditProject(_name, textBoxProjectNameRoot.Text, textBoxProjectsPath.Text, textBoxUserTypes.Text, textBoxIssuer.Text, textBoxAudience.Text, Convert.ToInt32(textBoxTokenExpire.Text));

            if (response)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Proje değiştirilemedi!");
            }
        }

        private void SaveProject_Load(object sender, EventArgs e)
        {

        }
    }
}
