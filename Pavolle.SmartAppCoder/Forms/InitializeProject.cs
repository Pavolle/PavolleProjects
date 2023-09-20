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
    public partial class InitializeProject : Form
    {
        long _projectOid;
        Project? _project;
        Thread thread;
        Thread writeThread;
        public InitializeProject(long projectOid)
        {
            _projectOid = projectOid;
            InitializeComponent();

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _project = session.Query<Project>().FirstOrDefault(t => t.Oid == projectOid);
            }

            labelProjectInfo.Text = _project.OrganizationName + "." + _project.ProjectName;

            thread = new Thread(new ThreadStart(StartGenerating));
            thread.Start();
        }

        private void StartGenerating()
        {
            Output("Proje oluşturma başlatılıyor...");
            Output("Core projesi kontrol ediliyor...");

            bool coreProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + _project.OrganizationName + ".Core");
            if (!coreProjesiOlusturulmus)
            {
                Output("Core projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + _project.OrganizationName + ".Core").Result;

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core.csproj --in-root").Result;

            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        void Output(string message)
        {
            writeThread = new Thread(new ParameterizedThreadStart(WriteMessage));
            writeThread.Start(message);
        }

        private void WriteMessage(object state)
        {
            try
            {

                string message = (string)state;
                textBoxOutput.BeginInvoke((MethodInvoker)(() =>
                {
                    textBoxOutput.AppendText(message + Environment.NewLine);

                }));
            }
            catch (Exception)
            {

            }
        }
    }
}
