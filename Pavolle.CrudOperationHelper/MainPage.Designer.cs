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
            this.listBoxProjects = new System.Windows.Forms.ListBox();
            this.labelProjects = new System.Windows.Forms.Label();
            this.textBoxProjectMame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectOrganization = new System.Windows.Forms.TextBox();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxProjectsPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLanguage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxTokenExpire = new System.Windows.Forms.TextBox();
            this.labelTokenExpire = new System.Windows.Forms.Label();
            this.textBoxAudience = new System.Windows.Forms.TextBox();
            this.labelAudience = new System.Windows.Forms.Label();
            this.textBoxIssuer = new System.Windows.Forms.TextBox();
            this.labelIssuer = new System.Windows.Forms.Label();
            this.buttonIntializeProject = new System.Windows.Forms.Button();
            this.butttonEditProjects = new System.Windows.Forms.Button();
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonIntializeTable = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxColumns = new System.Windows.Forms.ListBox();
            this.buttonEditTable = new System.Windows.Forms.Button();
            this.checkBoxServiceDelete = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceDetail = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceLookup = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceList = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.Location = new System.Drawing.Point(453, 44);
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Size = new System.Drawing.Size(170, 35);
            this.buttonAddProject.TabIndex = 0;
            this.buttonAddProject.Text = "New Project";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.buttonAddProject_Click);
            // 
            // buttonAddTable
            // 
            this.buttonAddTable.Location = new System.Drawing.Point(152, 20);
            this.buttonAddTable.Name = "buttonAddTable";
            this.buttonAddTable.Size = new System.Drawing.Size(180, 36);
            this.buttonAddTable.TabIndex = 1;
            this.buttonAddTable.Text = "Add Table";
            this.buttonAddTable.UseVisualStyleBackColor = true;
            this.buttonAddTable.Click += new System.EventHandler(this.buttonAddTable_Click);
            // 
            // listBoxProjects
            // 
            this.listBoxProjects.FormattingEnabled = true;
            this.listBoxProjects.ItemHeight = 25;
            this.listBoxProjects.Location = new System.Drawing.Point(24, 85);
            this.listBoxProjects.Name = "listBoxProjects";
            this.listBoxProjects.Size = new System.Drawing.Size(599, 279);
            this.listBoxProjects.TabIndex = 2;
            this.listBoxProjects.SelectedIndexChanged += new System.EventHandler(this.listBoxProjects_SelectedIndexChanged);
            // 
            // labelProjects
            // 
            this.labelProjects.AutoSize = true;
            this.labelProjects.Location = new System.Drawing.Point(24, 49);
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
            // textBoxProjectOrganization
            // 
            this.textBoxProjectOrganization.Location = new System.Drawing.Point(259, 89);
            this.textBoxProjectOrganization.Name = "textBoxProjectOrganization";
            this.textBoxProjectOrganization.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectOrganization.TabIndex = 7;
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(38, 89);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(114, 25);
            this.labelProjectName.TabIndex = 6;
            this.labelProjectName.Text = "Organization";
            // 
            // textBoxProjectsPath
            // 
            this.textBoxProjectsPath.Location = new System.Drawing.Point(259, 126);
            this.textBoxProjectsPath.Name = "textBoxProjectsPath";
            this.textBoxProjectsPath.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectsPath.TabIndex = 11;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLanguage);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.buttonIntializeProject);
            this.groupBox1.Controls.Add(this.butttonEditProjects);
            this.groupBox1.Controls.Add(this.textBoxProjectsPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelProjectName);
            this.groupBox1.Controls.Add(this.textBoxProjectMame);
            this.groupBox1.Controls.Add(this.textBoxProjectOrganization);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 587);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // textBoxLanguage
            // 
            this.textBoxLanguage.Location = new System.Drawing.Point(259, 258);
            this.textBoxLanguage.Name = "textBoxLanguage";
            this.textBoxLanguage.Size = new System.Drawing.Size(307, 31);
            this.textBoxLanguage.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Language(s)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxTokenExpire);
            this.groupBox3.Controls.Add(this.labelTokenExpire);
            this.groupBox3.Controls.Add(this.textBoxAudience);
            this.groupBox3.Controls.Add(this.labelAudience);
            this.groupBox3.Controls.Add(this.textBoxIssuer);
            this.groupBox3.Controls.Add(this.labelIssuer);
            this.groupBox3.Location = new System.Drawing.Point(6, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 150);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Security";
            // 
            // textBoxTokenExpire
            // 
            this.textBoxTokenExpire.Location = new System.Drawing.Point(253, 104);
            this.textBoxTokenExpire.Name = "textBoxTokenExpire";
            this.textBoxTokenExpire.Size = new System.Drawing.Size(307, 31);
            this.textBoxTokenExpire.TabIndex = 15;
            // 
            // labelTokenExpire
            // 
            this.labelTokenExpire.AutoSize = true;
            this.labelTokenExpire.Location = new System.Drawing.Point(32, 104);
            this.labelTokenExpire.Name = "labelTokenExpire";
            this.labelTokenExpire.Size = new System.Drawing.Size(165, 25);
            this.labelTokenExpire.TabIndex = 14;
            this.labelTokenExpire.Text = "Token Expire (Hour)";
            // 
            // textBoxAudience
            // 
            this.textBoxAudience.Location = new System.Drawing.Point(253, 67);
            this.textBoxAudience.Name = "textBoxAudience";
            this.textBoxAudience.Size = new System.Drawing.Size(307, 31);
            this.textBoxAudience.TabIndex = 13;
            // 
            // labelAudience
            // 
            this.labelAudience.AutoSize = true;
            this.labelAudience.Location = new System.Drawing.Point(32, 67);
            this.labelAudience.Name = "labelAudience";
            this.labelAudience.Size = new System.Drawing.Size(85, 25);
            this.labelAudience.TabIndex = 12;
            this.labelAudience.Text = "Audience";
            // 
            // textBoxIssuer
            // 
            this.textBoxIssuer.Location = new System.Drawing.Point(253, 30);
            this.textBoxIssuer.Name = "textBoxIssuer";
            this.textBoxIssuer.Size = new System.Drawing.Size(307, 31);
            this.textBoxIssuer.TabIndex = 11;
            // 
            // labelIssuer
            // 
            this.labelIssuer.AutoSize = true;
            this.labelIssuer.Location = new System.Drawing.Point(32, 30);
            this.labelIssuer.Name = "labelIssuer";
            this.labelIssuer.Size = new System.Drawing.Size(58, 25);
            this.labelIssuer.TabIndex = 10;
            this.labelIssuer.Text = "Issuer";
            // 
            // buttonIntializeProject
            // 
            this.buttonIntializeProject.Location = new System.Drawing.Point(23, 499);
            this.buttonIntializeProject.Name = "buttonIntializeProject";
            this.buttonIntializeProject.Size = new System.Drawing.Size(262, 60);
            this.buttonIntializeProject.TabIndex = 13;
            this.buttonIntializeProject.Text = "Initialize Project";
            this.buttonIntializeProject.UseVisualStyleBackColor = true;
            this.buttonIntializeProject.Click += new System.EventHandler(this.buttonIntializeProject_Click);
            // 
            // butttonEditProjects
            // 
            this.butttonEditProjects.Location = new System.Drawing.Point(306, 499);
            this.butttonEditProjects.Name = "butttonEditProjects";
            this.butttonEditProjects.Size = new System.Drawing.Size(260, 60);
            this.butttonEditProjects.TabIndex = 12;
            this.butttonEditProjects.Text = "Edit Project";
            this.butttonEditProjects.UseVisualStyleBackColor = true;
            this.butttonEditProjects.Click += new System.EventHandler(this.butttonEditProjects_Click);
            // 
            // listBoxTables
            // 
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.ItemHeight = 25;
            this.listBoxTables.Location = new System.Drawing.Point(20, 73);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(312, 779);
            this.listBoxTables.TabIndex = 13;
            this.listBoxTables.SelectedIndexChanged += new System.EventHandler(this.listBoxTables_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonIntializeTable);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.listBoxColumns);
            this.groupBox2.Controls.Add(this.buttonEditTable);
            this.groupBox2.Controls.Add(this.checkBoxServiceDelete);
            this.groupBox2.Controls.Add(this.checkBoxServiceEdit);
            this.groupBox2.Controls.Add(this.checkBoxServiceAdd);
            this.groupBox2.Controls.Add(this.checkBoxServiceDetail);
            this.groupBox2.Controls.Add(this.checkBoxServiceLookup);
            this.groupBox2.Controls.Add(this.checkBoxServiceList);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.listBoxTables);
            this.groupBox2.Controls.Add(this.buttonAddTable);
            this.groupBox2.Location = new System.Drawing.Point(656, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1167, 875);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tables";
            // 
            // buttonIntializeTable
            // 
            this.buttonIntializeTable.Location = new System.Drawing.Point(624, 787);
            this.buttonIntializeTable.Name = "buttonIntializeTable";
            this.buttonIntializeTable.Size = new System.Drawing.Size(266, 60);
            this.buttonIntializeTable.TabIndex = 27;
            this.buttonIntializeTable.Text = "Intialize Table";
            this.buttonIntializeTable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Columns";
            // 
            // listBoxColumns
            // 
            this.listBoxColumns.FormattingEnabled = true;
            this.listBoxColumns.ItemHeight = 25;
            this.listBoxColumns.Location = new System.Drawing.Point(370, 268);
            this.listBoxColumns.Name = "listBoxColumns";
            this.listBoxColumns.Size = new System.Drawing.Size(248, 579);
            this.listBoxColumns.TabIndex = 25;
            // 
            // buttonEditTable
            // 
            this.buttonEditTable.Location = new System.Drawing.Point(909, 787);
            this.buttonEditTable.Name = "buttonEditTable";
            this.buttonEditTable.Size = new System.Drawing.Size(252, 60);
            this.buttonEditTable.TabIndex = 24;
            this.buttonEditTable.Text = "Edit Table";
            this.buttonEditTable.UseVisualStyleBackColor = true;
            this.buttonEditTable.Click += new System.EventHandler(this.buttonEditTable_Click);
            // 
            // checkBoxServiceDelete
            // 
            this.checkBoxServiceDelete.AutoSize = true;
            this.checkBoxServiceDelete.Location = new System.Drawing.Point(816, 198);
            this.checkBoxServiceDelete.Name = "checkBoxServiceDelete";
            this.checkBoxServiceDelete.Size = new System.Drawing.Size(88, 29);
            this.checkBoxServiceDelete.TabIndex = 23;
            this.checkBoxServiceDelete.Text = "Delete";
            this.checkBoxServiceDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceEdit
            // 
            this.checkBoxServiceEdit.AutoSize = true;
            this.checkBoxServiceEdit.Location = new System.Drawing.Point(742, 198);
            this.checkBoxServiceEdit.Name = "checkBoxServiceEdit";
            this.checkBoxServiceEdit.Size = new System.Drawing.Size(68, 29);
            this.checkBoxServiceEdit.TabIndex = 22;
            this.checkBoxServiceEdit.Text = "Edit";
            this.checkBoxServiceEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceAdd
            // 
            this.checkBoxServiceAdd.AutoSize = true;
            this.checkBoxServiceAdd.Location = new System.Drawing.Point(664, 198);
            this.checkBoxServiceAdd.Name = "checkBoxServiceAdd";
            this.checkBoxServiceAdd.Size = new System.Drawing.Size(72, 29);
            this.checkBoxServiceAdd.TabIndex = 21;
            this.checkBoxServiceAdd.Text = "Add";
            this.checkBoxServiceAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceDetail
            // 
            this.checkBoxServiceDetail.AutoSize = true;
            this.checkBoxServiceDetail.Location = new System.Drawing.Point(566, 198);
            this.checkBoxServiceDetail.Name = "checkBoxServiceDetail";
            this.checkBoxServiceDetail.Size = new System.Drawing.Size(83, 29);
            this.checkBoxServiceDetail.TabIndex = 20;
            this.checkBoxServiceDetail.Text = "Detail";
            this.checkBoxServiceDetail.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceLookup
            // 
            this.checkBoxServiceLookup.AutoSize = true;
            this.checkBoxServiceLookup.Location = new System.Drawing.Point(462, 198);
            this.checkBoxServiceLookup.Name = "checkBoxServiceLookup";
            this.checkBoxServiceLookup.Size = new System.Drawing.Size(98, 29);
            this.checkBoxServiceLookup.TabIndex = 19;
            this.checkBoxServiceLookup.Text = "Lookup";
            this.checkBoxServiceLookup.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceList
            // 
            this.checkBoxServiceList.AutoSize = true;
            this.checkBoxServiceList.Location = new System.Drawing.Point(377, 198);
            this.checkBoxServiceList.Name = "checkBoxServiceList";
            this.checkBoxServiceList.Size = new System.Drawing.Size(64, 29);
            this.checkBoxServiceList.TabIndex = 18;
            this.checkBoxServiceList.Text = "List";
            this.checkBoxServiceList.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Table Db Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(594, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 31);
            this.textBox1.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(594, 134);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(307, 31);
            this.textBox2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Table Name";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1835, 989);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelProjects);
            this.Controls.Add(this.listBoxProjects);
            this.Controls.Add(this.buttonAddProject);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonAddProject;
        private Button buttonAddTable;
        private ListBox listBoxProjects;
        private Label labelProjects;
        private TextBox textBoxProjectMame;
        private Label label1;
        private TextBox textBoxProjectOrganization;
        private Label labelProjectName;
        private TextBox textBoxProjectsPath;
        private Label label2;
        private GroupBox groupBox1;
        private Button butttonEditProjects;
        private ListBox listBoxTables;
        private GroupBox groupBox2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Button buttonEditTable;
        private CheckBox checkBoxServiceDelete;
        private CheckBox checkBoxServiceEdit;
        private CheckBox checkBoxServiceAdd;
        private CheckBox checkBoxServiceDetail;
        private CheckBox checkBoxServiceLookup;
        private CheckBox checkBoxServiceList;
        private Label label5;
        private ListBox listBoxColumns;
        private Button buttonIntializeProject;
        private Button buttonIntializeTable;
        private GroupBox groupBox3;
        private TextBox textBoxTokenExpire;
        private Label labelTokenExpire;
        private TextBox textBoxAudience;
        private Label labelAudience;
        private TextBox textBoxIssuer;
        private Label labelIssuer;
        private TextBox textBoxLanguage;
        private Label label7;
    }
}