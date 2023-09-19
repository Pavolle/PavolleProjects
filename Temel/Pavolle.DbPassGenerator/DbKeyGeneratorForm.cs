using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pavolle.DbPassGenerator
{
    public partial class DbKeyGeneratorForm : Form
    {
        public DbKeyGeneratorForm()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxKey.Text))
            {
                MessageBox.Show("Anahtar alanı boş olamaz!");
                textBoxPassword.Text = "Anahtar alanı boş olamaz!";
                return;
            }

            if(textBoxKey.Text.Length<8)
            {
                MessageBox.Show("Anahtar en az 8 karakter olmalıdır!");
                textBoxPassword.Text = "Anahtar en az 8 karakter olmalıdır!";
                return;
            }

            textBoxPassword.Text= PasswordGeneratorManager.Instance.GeneratePassword(textBoxKey.Text);
        }
    }
}
