namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxIletisimTipi = new ComboBox();
            SuspendLayout();
            // 
            // comboBoxIletisimTipi
            // 
            comboBoxIletisimTipi.FormattingEnabled = true;
            comboBoxIletisimTipi.Items.AddRange(new object[] { "TCP", "SSL" });
            comboBoxIletisimTipi.Location = new Point(269, 209);
            comboBoxIletisimTipi.Name = "comboBoxIletisimTipi";
            comboBoxIletisimTipi.Size = new Size(262, 33);
            comboBoxIletisimTipi.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxIletisimTipi);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxIletisimTipi;
    }
}