namespace Pavolle.CrudOperationHelper
{
    partial class EditProject
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butttonCreate = new System.Windows.Forms.Button();
            this.textBoxProjectsPath = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxProjectNameRoot = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butttonCreate);
            this.groupBox1.Controls.Add(this.textBoxProjectsPath);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelProjectName);
            this.groupBox1.Controls.Add(this.textBoxProjectNameRoot);
            this.groupBox1.Location = new System.Drawing.Point(27, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 275);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // butttonCreate
            // 
            this.butttonCreate.Location = new System.Drawing.Point(413, 187);
            this.butttonCreate.Name = "butttonCreate";
            this.butttonCreate.Size = new System.Drawing.Size(144, 51);
            this.butttonCreate.TabIndex = 12;
            this.butttonCreate.Text = "Save";
            this.butttonCreate.UseVisualStyleBackColor = true;
            this.butttonCreate.Click += new System.EventHandler(this.butttonCreate_Click);
            // 
            // textBoxProjectsPath
            // 
            this.textBoxProjectsPath.Location = new System.Drawing.Point(250, 121);
            this.textBoxProjectsPath.Name = "textBoxProjectsPath";
            this.textBoxProjectsPath.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectsPath.TabIndex = 11;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(250, 187);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(144, 51);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Projects File Path";
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(29, 61);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(161, 25);
            this.labelProjectName.TabIndex = 6;
            this.labelProjectName.Text = "Project Name Root";
            // 
            // textBoxProjectNameRoot
            // 
            this.textBoxProjectNameRoot.Location = new System.Drawing.Point(250, 61);
            this.textBoxProjectNameRoot.Name = "textBoxProjectNameRoot";
            this.textBoxProjectNameRoot.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectNameRoot.TabIndex = 7;
            // 
            // EditProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 320);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditProject";
            this.Text = "EditProject";
            this.Load += new System.EventHandler(this.SaveProject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button butttonCreate;
        private TextBox textBoxProjectsPath;
        private Button buttonCancel;
        private Label label2;
        private Label labelProjectName;
        private TextBox textBoxProjectNameRoot;
    }
}