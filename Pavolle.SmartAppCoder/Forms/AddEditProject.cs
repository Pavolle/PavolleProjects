using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Business;
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
                buttonSave.Text = "Create Project";
                this.Text = "New Project";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_projectOid == null)
            {
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var project = new Project(session);
                    project.OrganizationName = textBoxOrganization.Text;
                    project.ProjectName = textBoxProjectName.Text;
                    project.ProjectPath = textBoxPath.Text;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
