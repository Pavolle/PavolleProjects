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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            try
            {
                string[] text = File.ReadAllLines("appsettings.ini");
                DbManager.Instance.Initialize(text[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Veritabanı bağlantısı sağlanamadı!!!");
            }
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
