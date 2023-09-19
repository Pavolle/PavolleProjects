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
                if (project==null)
                {
                    return;
                }


                project.OrganizationName = textBoxOrganization.Text;
                project.ProjectName = textBoxProjectName.Text;
                project.ProjectPath = textBoxPath.Text;
                project.ConnectionString = textBoxConnectionString.Text;

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
            if (textBoxIssuer.Text == null)
            {

            }

            if(textBoxAudience.Text == null)
            {

            }
        }
    }
}
