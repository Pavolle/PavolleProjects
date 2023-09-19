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
        string _issuer;
        string _auidence;
        string _tokenExpireMinute;
        string _language;
        public EditProject(string name, string root, string path, string userType, string issuer, string audience, int tokenExpireMinute, string language)
        {
            InitializeComponent();
            _name = name;
            _path = path;
            _root = root;
            _userType = userType;
            _issuer = issuer;
            _auidence = audience;
            _tokenExpireMinute=tokenExpireMinute.ToString();
            _language = language;

            this.Text = "Edit Project (" + name + ")";
            textBoxProjectOrganization.Text = _root;
            textBoxProjectsPath.Text = _path;
            textBoxIssuer.Text = _issuer;
            textBoxAudience.Text = _auidence;
            textBoxTokenExpire.Text = _tokenExpireMinute;
            textBoxLanguage.Text = _language;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butttonCreate_Click(object sender, EventArgs e)
        {
            bool response = DbManager.Instance.EditProject(_name, textBoxProjectOrganization.Text, textBoxProjectsPath.Text, textBoxIssuer.Text, textBoxAudience.Text, Convert.ToInt32(textBoxTokenExpire.Text), textBoxLanguage.Text);

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
