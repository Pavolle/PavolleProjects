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
using System.Xml.Linq;

namespace Pavolle.CrudOperationHelper
{
    public partial class MainPage : Form
    {
        string _selectedProjectName = "";
        public MainPage()
        {
            InitializeComponent();

            try
            {
                string[] text = File.ReadAllLines("appsettings.ini");
                DbManager.Instance.Initialize(text[0]);
                RefreshProjectList();
            }
            catch (Exception)
            {
                MessageBox.Show("Veritabanı bağlantısı sağlanamadı!!!");
            }


            textBoxProjectMame.Enabled = false;
            textBoxProjectNameRoot.Enabled = false;
            textBoxProjectsPath.Enabled = false;
        }

        void RefreshProjectList()
        {
            listBoxProjects.Items.Clear();
            var projectList = DbManager.Instance.GetProjectList();
            foreach (var item in projectList)
            {
                listBoxProjects.Items.Add(item);
            }
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            CreateProject createProject = new CreateProject();
            createProject.ShowDialog();
            RefreshProjectList();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        void GetProjectDetail(string name)
        {
            var detail = DbManager.Instance.GetProjectDetal(name);

            textBoxProjectMame.Text = detail.Name;
            textBoxProjectNameRoot.Text = detail.Root;
            textBoxProjectsPath.Text = detail.Path;

            if (detail.Intialize)
            {
                butttonEditProjects.Enabled = false;
                buttonIntializeProject.Enabled = false;
            }
            else
            {
                butttonEditProjects.Enabled = true;
                buttonIntializeProject.Enabled = true;
            }



            var tableList = DbManager.Instance.GetTableList(name);
            listBoxTables.Items.Clear();

            if (tableList.Count == 0)
            {
                listBoxTables.Items.Add("Tablo Tanımlanmamış!");
                listBoxTables.Enabled = false;
            }
            else
            {
                foreach (var item in tableList)
                {
                    listBoxTables.Items.Add(item);
                }
                listBoxTables.Enabled = true;
            }

            _selectedProjectName = name;
        }

        private void listBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)(((ListBox)sender).SelectedItem);
            GetProjectDetail(name);


        }

        private void butttonEditProjects_Click(object sender, EventArgs e)
        {
            string name = textBoxProjectMame.Text;
            var detail = DbManager.Instance.GetProjectDetal(name);
            EditProject editProject = new EditProject(detail.Name, detail.Root, detail.Path);
            editProject.ShowDialog();

            var detail1 = DbManager.Instance.GetProjectDetal(name);

            textBoxProjectMame.Text = detail1.Name;
            textBoxProjectNameRoot.Text = detail1.Root;
            textBoxProjectsPath.Text = detail1.Path;
            GetProjectDetail(name);
        }

        private void buttonIntializeProject_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditTable_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            AddTable addTable = new AddTable(_selectedProjectName);
            addTable.ShowDialog();
            GetProjectDetail(_selectedProjectName);
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
