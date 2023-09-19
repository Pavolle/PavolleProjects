namespace Pavolle.DbPassGenerator
{
    partial class DbKeyGeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(351, 72);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(156, 34);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(183, 35);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(324, 31);
            this.textBoxKey.TabIndex = 1;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(46, 38);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(74, 25);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "Anahtar";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(46, 131);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(47, 25);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Şifre";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(183, 128);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(324, 81);
            this.textBoxPassword.TabIndex = 3;
            // 
            // DbKeyGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 302);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "DbKeyGeneratorForm";
            this.Text = "DbKeyGeneratorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonGenerate;
        private TextBox textBoxKey;
        private Label labelKey;
        private Label labelPassword;
        private TextBox textBoxPassword;
    }
}