namespace Pavolle.CrudOperationHelper
{
    partial class CreateProject
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
            this.textBoxProjectMame = new System.Windows.Forms.TextBox();
            this.textBoxProjectNameRoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserTypes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxUserTypes);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butttonCreate);
            this.groupBox1.Controls.Add(this.textBoxProjectsPath);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelProjectName);
            this.groupBox1.Controls.Add(this.textBoxProjectMame);
            this.groupBox1.Controls.Add(this.textBoxProjectNameRoot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 388);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // butttonCreate
            // 
            this.butttonCreate.Location = new System.Drawing.Point(422, 308);
            this.butttonCreate.Name = "butttonCreate";
            this.butttonCreate.Size = new System.Drawing.Size(144, 51);
            this.butttonCreate.TabIndex = 12;
            this.butttonCreate.Text = "Create";
            this.butttonCreate.UseVisualStyleBackColor = true;
            this.butttonCreate.Click += new System.EventHandler(this.butttonCreate_Click);
            // 
            // textBoxProjectsPath
            // 
            this.textBoxProjectsPath.Location = new System.Drawing.Point(259, 126);
            this.textBoxProjectsPath.Name = "textBoxProjectsPath";
            this.textBoxProjectsPath.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectsPath.TabIndex = 11;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(259, 308);
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
            this.label2.Location = new System.Drawing.Point(38, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Projects File Path";
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(38, 89);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(161, 25);
            this.labelProjectName.TabIndex = 6;
            this.labelProjectName.Text = "Project Name Root";
            // 
            // textBoxProjectMame
            // 
            this.textBoxProjectMame.Location = new System.Drawing.Point(259, 52);
            this.textBoxProjectMame.Name = "textBoxProjectMame";
            this.textBoxProjectMame.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectMame.TabIndex = 9;
            // 
            // textBoxProjectNameRoot
            // 
            this.textBoxProjectNameRoot.Location = new System.Drawing.Point(259, 89);
            this.textBoxProjectNameRoot.Name = "textBoxProjectNameRoot";
            this.textBoxProjectNameRoot.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectNameRoot.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Project Name";
            // 
            // textBoxUserTypes
            // 
            this.textBoxUserTypes.Location = new System.Drawing.Point(259, 163);
            this.textBoxUserTypes.Multiline = true;
            this.textBoxUserTypes.Name = "textBoxUserTypes";
            this.textBoxUserTypes.Size = new System.Drawing.Size(307, 127);
            this.textBoxUserTypes.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "User Types";
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 416);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateProject";
            this.Text = "CreateProject";
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
        private TextBox textBoxProjectMame;
        private TextBox textBoxProjectNameRoot;
        private Label label1;
        private TextBox textBoxUserTypes;
        private Label label6;
    }
}