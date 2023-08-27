namespace Pavolle.CrudOperationHelper
{
    partial class MainPage
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
            this.buttonAddProject = new System.Windows.Forms.Button();
            this.buttonAddTable = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelProjects = new System.Windows.Forms.Label();
            this.textBoxProjectMame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectNameRoot = new System.Windows.Forms.TextBox();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxProjectsPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butttonEditProjects = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.Location = new System.Drawing.Point(69, 44);
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Size = new System.Drawing.Size(170, 35);
            this.buttonAddProject.TabIndex = 0;
            this.buttonAddProject.Text = "Add Project";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.buttonAddProject_Click);
            // 
            // buttonAddTable
            // 
            this.buttonAddTable.Location = new System.Drawing.Point(38, 244);
            this.buttonAddTable.Name = "buttonAddTable";
            this.buttonAddTable.Size = new System.Drawing.Size(170, 60);
            this.buttonAddTable.TabIndex = 1;
            this.buttonAddTable.Text = "Add Table";
            this.buttonAddTable.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(24, 85);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(215, 279);
            this.listBox1.TabIndex = 2;
            // 
            // labelProjects
            // 
            this.labelProjects.AutoSize = true;
            this.labelProjects.Location = new System.Drawing.Point(22, 15);
            this.labelProjects.Name = "labelProjects";
            this.labelProjects.Size = new System.Drawing.Size(74, 25);
            this.labelProjects.TabIndex = 3;
            this.labelProjects.Text = "Projects";
            // 
            // textBoxProjectMame
            // 
            this.textBoxProjectMame.Location = new System.Drawing.Point(259, 52);
            this.textBoxProjectMame.Name = "textBoxProjectMame";
            this.textBoxProjectMame.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectMame.TabIndex = 9;
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
            // textBoxProjectNameRoot
            // 
            this.textBoxProjectNameRoot.Location = new System.Drawing.Point(259, 117);
            this.textBoxProjectNameRoot.Name = "textBoxProjectNameRoot";
            this.textBoxProjectNameRoot.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectNameRoot.TabIndex = 7;
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(38, 117);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(161, 25);
            this.labelProjectName.TabIndex = 6;
            this.labelProjectName.Text = "Project Name Root";
            // 
            // textBoxProjectsPath
            // 
            this.textBoxProjectsPath.Location = new System.Drawing.Point(259, 177);
            this.textBoxProjectsPath.Name = "textBoxProjectsPath";
            this.textBoxProjectsPath.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectsPath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Projects File Path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butttonEditProjects);
            this.groupBox1.Controls.Add(this.textBoxProjectsPath);
            this.groupBox1.Controls.Add(this.buttonAddTable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelProjectName);
            this.groupBox1.Controls.Add(this.textBoxProjectMame);
            this.groupBox1.Controls.Add(this.textBoxProjectNameRoot);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(277, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 312);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // butttonEditProjects
            // 
            this.butttonEditProjects.Location = new System.Drawing.Point(396, 244);
            this.butttonEditProjects.Name = "butttonEditProjects";
            this.butttonEditProjects.Size = new System.Drawing.Size(170, 60);
            this.butttonEditProjects.TabIndex = 12;
            this.butttonEditProjects.Text = "Edit Project";
            this.butttonEditProjects.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 386);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelProjects);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonAddProject);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonAddProject;
        private Button buttonAddTable;
        private ListBox listBox1;
        private Label labelProjects;
        private TextBox textBoxProjectMame;
        private Label label1;
        private TextBox textBoxProjectNameRoot;
        private Label labelProjectName;
        private TextBox textBoxProjectsPath;
        private Label label2;
        private GroupBox groupBox1;
        private Button butttonEditProjects;
    }
}