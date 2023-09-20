using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Enums;
using Pavolle.SmartAppCoder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pavolle.SmartAppCoder.Forms
{
    public partial class AddEditProject : Form
    {
        long? _projectOid;
        bool _showDetail;
        public AddEditProject(long? projectOid, bool showDetail)
        {
            InitializeComponent();
            _projectOid = projectOid;
            _showDetail = showDetail;

            if (_projectOid != null)
            {
                var project = DbManager.Instance.GetProject(_projectOid.Value);
                if (project != null)
                {
                    textBoxOrganization.Text = project.OrganizationName;
                    textBoxProjectName.Text = project.ProjectName;
                    textBoxPath.Text = project.ProjectPath;
                }
            }
            else
            {

                textBoxTokenExpire.Text = (72).ToString();
                foreach (var item in EnumHelperManager.Instance.GetWebAppTechnologyList())
                {
                    comboBoxWeb.Items.Add(item);
                    comboBoxWeb.DisplayMember = "Value";
                    comboBoxWeb.ValueMember = "Key";
                }

                if (comboBoxWeb.Items.Count == 1) comboBoxWeb.SelectedItem = comboBoxWeb.Items[0];

                foreach (var item in EnumHelperManager.Instance.GetSecurityLevel())
                {
                    comboBoxSecurity.Items.Add(item);
                    comboBoxSecurity.DisplayMember = "Value";
                    comboBoxSecurity.ValueMember = "Key";
                }

                if (comboBoxSecurity.Items.Count == 1) comboBoxSecurity.SelectedItem = comboBoxSecurity.Items[0];

                foreach (var item in EnumHelperManager.Instance.GetMobileTechnologyList())
                {
                    comboBoxMobile.Items.Add(item);
                    comboBoxMobile.DisplayMember = "Value";
                    comboBoxMobile.ValueMember = "Key";
                }

                if (comboBoxMobile.Items.Count == 1) comboBoxMobile.SelectedItem = comboBoxMobile.Items[0];

                foreach (var item in EnumHelperManager.Instance.GetDbTechnologyList())
                {
                    comboBoxDatabase.Items.Add(item);
                    comboBoxDatabase.DisplayMember = "Value";
                    comboBoxDatabase.ValueMember = "Key";
                }

                if (comboBoxDatabase.Items.Count == 1) comboBoxDatabase.SelectedItem = comboBoxDatabase.Items[0];


                buttonSave.Text = "Create Project";
                this.Text = "New Project";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                Project project = null;
                if (_projectOid == null)
                {

                    project = new Project(session);
                }
                else
                {
                    project = session.Query<Project>().FirstOrDefault(t => t.Oid == _projectOid);
                }
                if (project == null)
                {
                    return;
                }


                project.OrganizationName = textBoxOrganization.Text;
                project.ProjectName = textBoxProjectName.Text;
                project.ProjectPath = textBoxPath.Text;
                try
                {
                    project.WebAppTecnology = (EWebAppTecnology)((LookupViewData)comboBoxWeb.SelectedItem).Key;
                }
                catch (Exception)
                {
                    MessageBox.Show("Web technology option error!");
                    return;
                }
                try
                {
                    project.DbTechnology = (EDbTechnology)((LookupViewData)comboBoxDatabase.SelectedItem).Key;
                }
                catch (Exception)
                {
                    MessageBox.Show("Database technology option error!");
                    return;
                }
                try
                {
                    project.SecurityLevel = (ESecurityLevel)((LookupViewData)comboBoxSecurity.SelectedItem).Key;
                }
                catch (Exception)
                {
                    MessageBox.Show("Security Level option error!");
                    return;
                }
                try
                {
                    project.MobileTechnology = (EMobileTechnology)((LookupViewData)comboBoxMobile.SelectedItem).Key;
                }
                catch (Exception)
                {
                    MessageBox.Show("Mobile Technology option error!");
                    return;
                }
                project.ConnectionString = textBoxConnectionString.Text;
                project.Issuer = textBoxIssuer.Text;
                project.Audience = textBoxAudience.Text;
                try
                {
                    project.TokenExpireMinute = Convert.ToInt32(textBoxTokenExpire.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Token Expire value is not correct!");
                    return;
                }

                project.Save();
            }


            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxOrganization_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBoxBase)sender).Text;
            textBoxIssuer.Text = text;
            textBoxAudience.Text = text;
        }

        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EDbTechnology dbTechnology = (EDbTechnology)((LookupViewData)comboBoxDatabase.SelectedItem).Key;

                switch (dbTechnology)
                {
                    case EDbTechnology.Sqlite:
                        textBoxConnectionString.Text = "XpoProvider=SQLite;Data Source=filename";
                        break;
                    case EDbTechnology.PostgreSQL:
                        textBoxConnectionString.Text = "XpoProvider=Postgres;Server=127.0.0.1;User ID=MyUserName;Password=MyPassword;Database=MyDatabase;Encoding=UNICODE";
                        break;
                    case EDbTechnology.SQLServer:
                        textBoxConnectionString.Text = "XpoProvider=MSSqlServer;Data Source=(local);User ID=username;Password=password;Initial Catalog=database;Persist Security Info=true";
                        break;
                    case EDbTechnology.Oracle:
                        textBoxConnectionString.Text = "XpoProvider=Oracle;Data Source=source;User ID=MyUserName;Password=MyPassword";
                        break;
                    case EDbTechnology.MySql:
                        textBoxConnectionString.Text = "XpoProvider=MySql;Server=MyServerAddress;User ID=MyUserName;Password=MyPassword;Database=MyDatabase;Persist Security Info= true;Charset=utf8";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
