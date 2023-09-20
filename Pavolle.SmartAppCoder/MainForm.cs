using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Enums;
using Pavolle.SmartAppCoder.Forms;
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

namespace Pavolle.SmartAppCoder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] text = File.ReadAllLines("appsettings.ini");
                DbManager.Instance.Initialize(text[0]);

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var project = session.Query<Project>().ToList();


                    listBoxProjectList.DisplayMember = "ProjectName";
                    listBoxProjectList.ValueMember = "Oid";
                    foreach (var item in project)
                    {
                        listBoxProjectList.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veritabanı bağlantısı sağlanamadı!!!");
            }
        }

        private void buttonNewProject_Click(object sender, EventArgs e)
        {
            AddEditProject project = new AddEditProject(null, false);
            project.ShowDialog();
        }

        private void listBoxProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project project = listBoxProjectList.SelectedItem as Project;

            if (project != null)
            {
                textBoxOrganization.Text = project.OrganizationName; 
                textBoxOrganization.ReadOnly = true;
                textBoxProjectName.Text=project.ProjectName; 
                textBoxProjectName.ReadOnly = true;
                textBoxPath.Text = project.ProjectPath;
                textBoxPath.ReadOnly = true;

                comboBoxWeb.Text = EnumHelperManager.Instance.GetWebAppTechnologyList().FirstOrDefault(t => t.Key == (int)project.WebAppTecnology).Value; 
                comboBoxWeb.Enabled = false;
                comboBoxDatabase.Text = EnumHelperManager.Instance.GetDbTechnologyList().FirstOrDefault(t => t.Key == (int)project.DbTechnology).Value;
                comboBoxDatabase.Enabled = false;
                comboBoxSecurity.Text = EnumHelperManager.Instance.GetSecurityLevel().FirstOrDefault(t => t.Key == (int)project.SecurityLevel).Value;
                comboBoxSecurity.Enabled = false;
                comboBoxMobile.Text = EnumHelperManager.Instance.GetMobileTechnologyList().FirstOrDefault(t => t.Key == (int)project.MobileTechnology).Value;
                comboBoxMobile.Enabled = false;

                textBoxConnectionString.Text = project.ConnectionString;
                textBoxConnectionString.ReadOnly = true;

                textBoxIssuer.Text=project.Issuer;
                textBoxIssuer.ReadOnly = true;

                textBoxAudience.Text=project.Audience;
                textBoxAudience.ReadOnly = true;

                textBoxTokenExpire.Text=project.TokenExpireMinute.ToString();
                textBoxTokenExpire.ReadOnly = true;

                if (project.Initlaize)
                {
                    buttonDevelopment.Enabled = true;
                    buttonEdit.Enabled = false;
                    buttonIntialize.Enabled = false;
                }
                else
                {
                    buttonDevelopment.Enabled = false;
                    buttonEdit.Enabled = true;
                    buttonIntialize.Enabled = true;
                }
            }
        }
    }
}
