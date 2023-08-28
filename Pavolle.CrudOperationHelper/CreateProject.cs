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
    public partial class CreateProject : Form
    {
        public CreateProject()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butttonCreate_Click(object sender, EventArgs e)
        {
            bool response=DbManager.Instance.SaveProject(textBoxProjectMame.Text, textBoxProjectNameRoot.Text, textBoxProjectsPath.Text, textBoxUserTypes.Text, textBoxIssuer.Text, textBoxAudience.Text, Convert.ToInt32(textBoxTokenExpire.Text), textBoxLanguage.Text);
            if (response)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Proje oluşturulamadı!");
            }
        }
    }
}
