namespace Pavolle.SmartAppCoder.Forms
{
    partial class AddEditProject
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
            groupBox3 = new GroupBox();
            textBoxTokenExpire = new TextBox();
            label8 = new Label();
            textBoxIssuer = new TextBox();
            label9 = new Label();
            label10 = new Label();
            textBoxAudience = new TextBox();
            comboBoxSecurity = new ComboBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            textBoxConnectionString = new TextBox();
            label11 = new Label();
            comboBoxMobile = new ComboBox();
            label6 = new Label();
            comboBoxDatabase = new ComboBox();
            label5 = new Label();
            comboBoxWeb = new ComboBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            textBoxPath = new TextBox();
            label3 = new Label();
            textBoxOrganization = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxProjectName = new TextBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxTokenExpire);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(textBoxIssuer);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(textBoxAudience);
            groupBox3.Controls.Add(comboBoxSecurity);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(23, 602);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(741, 225);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Security";
            // 
            // textBoxTokenExpire
            // 
            textBoxTokenExpire.Location = new Point(216, 169);
            textBoxTokenExpire.Name = "textBoxTokenExpire";
            textBoxTokenExpire.Size = new Size(502, 31);
            textBoxTokenExpire.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 172);
            label8.Name = "label8";
            label8.Size = new Size(165, 25);
            label8.TabIndex = 17;
            label8.Text = "Token Expire (Hour)";
            // 
            // textBoxIssuer
            // 
            textBoxIssuer.Location = new Point(216, 74);
            textBoxIssuer.Name = "textBoxIssuer";
            textBoxIssuer.Size = new Size(502, 31);
            textBoxIssuer.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 77);
            label9.Name = "label9";
            label9.Size = new Size(58, 25);
            label9.TabIndex = 13;
            label9.Text = "Issuer";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 124);
            label10.Name = "label10";
            label10.Size = new Size(85, 25);
            label10.TabIndex = 15;
            label10.Text = "Audience";
            // 
            // textBoxAudience
            // 
            textBoxAudience.Location = new Point(216, 121);
            textBoxAudience.Name = "textBoxAudience";
            textBoxAudience.Size = new Size(502, 31);
            textBoxAudience.TabIndex = 14;
            // 
            // comboBoxSecurity
            // 
            comboBoxSecurity.FormattingEnabled = true;
            comboBoxSecurity.Location = new Point(216, 30);
            comboBoxSecurity.Name = "comboBoxSecurity";
            comboBoxSecurity.Size = new Size(502, 33);
            comboBoxSecurity.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 33);
            label7.Name = "label7";
            label7.Size = new Size(118, 25);
            label7.TabIndex = 10;
            label7.Text = "Security Level";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxConnectionString);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(comboBoxMobile);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(comboBoxDatabase);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(comboBoxWeb);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(23, 236);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(741, 360);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Technology Options";
            // 
            // textBoxConnectionString
            // 
            textBoxConnectionString.Location = new Point(216, 145);
            textBoxConnectionString.Multiline = true;
            textBoxConnectionString.Name = "textBoxConnectionString";
            textBoxConnectionString.Size = new Size(502, 121);
            textBoxConnectionString.TabIndex = 14;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 148);
            label11.Name = "label11";
            label11.Size = new Size(153, 25);
            label11.TabIndex = 15;
            label11.Text = "Connection String";
            // 
            // comboBoxMobile
            // 
            comboBoxMobile.FormattingEnabled = true;
            comboBoxMobile.Location = new Point(216, 297);
            comboBoxMobile.Name = "comboBoxMobile";
            comboBoxMobile.Size = new Size(502, 33);
            comboBoxMobile.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 300);
            label6.Name = "label6";
            label6.Size = new Size(67, 25);
            label6.TabIndex = 8;
            label6.Text = "Mobile";
            // 
            // comboBoxDatabase
            // 
            comboBoxDatabase.FormattingEnabled = true;
            comboBoxDatabase.Location = new Point(216, 95);
            comboBoxDatabase.Name = "comboBoxDatabase";
            comboBoxDatabase.Size = new Size(502, 33);
            comboBoxDatabase.TabIndex = 7;
            comboBoxDatabase.SelectedIndexChanged += comboBoxDatabase_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 98);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 6;
            label5.Text = "Database";
            // 
            // comboBoxWeb
            // 
            comboBoxWeb.FormattingEnabled = true;
            comboBoxWeb.Location = new Point(216, 44);
            comboBoxWeb.Name = "comboBoxWeb";
            comboBoxWeb.Size = new Size(502, 33);
            comboBoxWeb.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 47);
            label4.Name = "label4";
            label4.Size = new Size(143, 25);
            label4.TabIndex = 4;
            label4.Text = "Web Technology";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxPath);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxOrganization);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxProjectName);
            groupBox1.Location = new Point(23, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(741, 204);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Project";
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(216, 133);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(502, 31);
            textBoxPath.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 136);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 7;
            label3.Text = "Project Path";
            // 
            // textBoxOrganization
            // 
            textBoxOrganization.Location = new Point(216, 38);
            textBoxOrganization.Name = "textBoxOrganization";
            textBoxOrganization.Size = new Size(502, 31);
            textBoxOrganization.TabIndex = 2;
            textBoxOrganization.TextChanged += textBoxOrganization_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 41);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 3;
            label1.Text = "Organization Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 88);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 5;
            label2.Text = "Project Name";
            // 
            // textBoxProjectName
            // 
            textBoxProjectName.Location = new Point(216, 85);
            textBoxProjectName.Name = "textBoxProjectName";
            textBoxProjectName.Size = new Size(502, 31);
            textBoxProjectName.TabIndex = 4;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(272, 842);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(137, 46);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(439, 842);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(137, 46);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // AddEditProject
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 911);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Name = "AddEditProject";
            Text = "Add/Edit Project";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private TextBox textBoxTokenExpire;
        private Label label8;
        private TextBox textBoxIssuer;
        private Label label9;
        private Label label10;
        private TextBox textBoxAudience;
        private ComboBox comboBoxSecurity;
        private Label label7;
        private GroupBox groupBox2;
        private ComboBox comboBoxMobile;
        private Label label6;
        private ComboBox comboBoxDatabase;
        private Label label5;
        private ComboBox comboBoxWeb;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox textBoxPath;
        private Label label3;
        private TextBox textBoxOrganization;
        private Label label1;
        private Label label2;
        private TextBox textBoxProjectName;
        private Button buttonCancel;
        private Button buttonSave;
        private TextBox textBoxConnectionString;
        private Label label11;
    }
}