using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pavolle.ESecim.KioskApp
{
    public partial class SifreliGirisForm : Form
    {
        string password = "";
        public SifreliGirisForm()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            password+=button_1.Text;
            textBoxPasword.Text=password;
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            password += button_2.Text;
            textBoxPasword.Text = password;
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            password += button_3.Text;
            textBoxPasword.Text = password;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            password += button_4.Text;
            textBoxPasword.Text = password;
        }

        private void button_5_Click(object sender, EventArgs e)
        {

            password += button_5.Text;
            textBoxPasword.Text = password;
        }

        private void button_6_Click(object sender, EventArgs e)
        {

            password += button_6.Text;
            textBoxPasword.Text = password;
        }

        private void button_7_Click(object sender, EventArgs e)
        {

            password += button_7.Text;
            textBoxPasword.Text = password;
        }

        private void button_8_Click(object sender, EventArgs e)
        {

            password += button_8.Text;
            textBoxPasword.Text = password;
        }

        private void button_9_Click(object sender, EventArgs e)
        {

            password += button_9.Text;
            textBoxPasword.Text = password;
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (password.Length == 0)
                return;
            password=password.Substring(0, password.Length-1);
            textBoxPasword.Text = password;
        }

        private void button_0_Click(object sender, EventArgs e)
        {

            password += button_0.Text;
            textBoxPasword.Text = password;
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {

        }

        private void SifreliGirisForm_Load(object sender, EventArgs e)
        {
            textBoxPasword.Text = null;
        }
    }
}
