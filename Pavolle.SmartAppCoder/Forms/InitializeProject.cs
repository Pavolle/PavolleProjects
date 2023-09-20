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
        public InitializeProject(long projectOid)
        {
            _projectOid = projectOid;
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }
    }
}
