using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Business.Core.Enum;
using Pavolle.SmartAppCoder.Business.Core.Utils;
using Pavolle.SmartAppCoder.Business.Core.ViewModels.Model;
using Pavolle.SmartAppCoder.Business.Core.ViewModels.Request;
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
                if (result)
                {
                    Output("Core projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj  --solution-folder Core").Result;
                if (addResult)
                {
                    Output("Core projesi proje dosyasına eklendi.");
                }

                Output("Core class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + "Class1.cs");
                Output("Core projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }

            if (EnumExtensionsCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create EnumExtensions Class => ok");
            if (SingletonCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create Singleton Class => ok");

            if (CommunicationTypeCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ECommunicationType Class => ok");
            if (JobStatusCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create EJobStatus Class => ok");
            if (LanguageCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ELanguage Class => ok");
            if (SecurityLevelCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ESecurityLevel Class => ok");


            if(!FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + _project.OrganizationName + ".Core" + "/ViewModels"))
            {
                Directory.CreateDirectory(_project.ProjectPath + "/" + _project.OrganizationName + ".Core" + "/ViewModels");
            }

            if (LanguageNameModelCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create LanguageNameModel Class => ok");
            if (IRequestCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create IRequest Class => ok");

            Output("Core projesi kontroller tamamlandı. Eksik dosyalar tekrar eklendi!");

            Output("Proje oluşturma tamamlandı!");
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(StartGenerating));
            thread.Start();
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
