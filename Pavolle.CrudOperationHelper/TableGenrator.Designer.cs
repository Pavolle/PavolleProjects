namespace Pavolle.CrudOperationHelper
{
    partial class TableGenrator
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
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxProjectNameRoot = new System.Windows.Forms.TextBox();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            this.checkBoxServiceDelete = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceDetail = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceLookup = new System.Windows.Forms.CheckBox();
            this.checkBoxServiceList = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddColumn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteColumn = new System.Windows.Forms.Button();
            this.buttonEditColumn = new System.Windows.Forms.Button();
            this.checkBoxColumnAddToCriteria = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnCanEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnCanAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnAddToDetail = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnAddToList = new System.Windows.Forms.CheckBox();
            this.textBoxIsUniqueIndex = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxIsIndex = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTableClass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNullable = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxEnumClassName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDataType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDbColumnName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxColumnName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxColumns = new System.Windows.Forms.ListBox();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            this.labelDbName = new System.Windows.Forms.Label();
            this.labelTableClassName = new System.Windows.Forms.Label();
            this.buttonCreateTable = new System.Windows.Forms.Button();
            this.textBoxProjectMame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTables.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(30, 35);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(161, 25);
            this.labelProjectName.TabIndex = 0;
            this.labelProjectName.Text = "Project Name Root";
            // 
            // textBoxProjectNameRoot
            // 
            this.textBoxProjectNameRoot.Location = new System.Drawing.Point(251, 35);
            this.textBoxProjectNameRoot.Name = "textBoxProjectNameRoot";
            this.textBoxProjectNameRoot.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectNameRoot.TabIndex = 1;
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Controls.Add(this.checkBoxServiceDelete);
            this.groupBoxTables.Controls.Add(this.checkBoxServiceEdit);
            this.groupBoxTables.Controls.Add(this.checkBoxServiceAdd);
            this.groupBoxTables.Controls.Add(this.checkBoxServiceDetail);
            this.groupBoxTables.Controls.Add(this.checkBoxServiceLookup);
            this.groupBoxTables.Controls.Add(this.checkBoxServiceList);
            this.groupBoxTables.Controls.Add(this.groupBox1);
            this.groupBoxTables.Controls.Add(this.textBoxDbName);
            this.groupBoxTables.Controls.Add(this.textBoxClassName);
            this.groupBoxTables.Controls.Add(this.labelDbName);
            this.groupBoxTables.Controls.Add(this.labelTableClassName);
            this.groupBoxTables.Location = new System.Drawing.Point(29, 93);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Size = new System.Drawing.Size(1254, 682);
            this.groupBoxTables.TabIndex = 2;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "Table Properties";
            // 
            // checkBoxServiceDelete
            // 
            this.checkBoxServiceDelete.AutoSize = true;
            this.checkBoxServiceDelete.Location = new System.Drawing.Point(457, 109);
            this.checkBoxServiceDelete.Name = "checkBoxServiceDelete";
            this.checkBoxServiceDelete.Size = new System.Drawing.Size(88, 29);
            this.checkBoxServiceDelete.TabIndex = 10;
            this.checkBoxServiceDelete.Text = "Delete";
            this.checkBoxServiceDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceEdit
            // 
            this.checkBoxServiceEdit.AutoSize = true;
            this.checkBoxServiceEdit.Location = new System.Drawing.Point(383, 109);
            this.checkBoxServiceEdit.Name = "checkBoxServiceEdit";
            this.checkBoxServiceEdit.Size = new System.Drawing.Size(68, 29);
            this.checkBoxServiceEdit.TabIndex = 9;
            this.checkBoxServiceEdit.Text = "Edit";
            this.checkBoxServiceEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceAdd
            // 
            this.checkBoxServiceAdd.AutoSize = true;
            this.checkBoxServiceAdd.Location = new System.Drawing.Point(305, 109);
            this.checkBoxServiceAdd.Name = "checkBoxServiceAdd";
            this.checkBoxServiceAdd.Size = new System.Drawing.Size(72, 29);
            this.checkBoxServiceAdd.TabIndex = 8;
            this.checkBoxServiceAdd.Text = "Add";
            this.checkBoxServiceAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceDetail
            // 
            this.checkBoxServiceDetail.AutoSize = true;
            this.checkBoxServiceDetail.Location = new System.Drawing.Point(207, 109);
            this.checkBoxServiceDetail.Name = "checkBoxServiceDetail";
            this.checkBoxServiceDetail.Size = new System.Drawing.Size(83, 29);
            this.checkBoxServiceDetail.TabIndex = 7;
            this.checkBoxServiceDetail.Text = "Detail";
            this.checkBoxServiceDetail.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceLookup
            // 
            this.checkBoxServiceLookup.AutoSize = true;
            this.checkBoxServiceLookup.Location = new System.Drawing.Point(103, 109);
            this.checkBoxServiceLookup.Name = "checkBoxServiceLookup";
            this.checkBoxServiceLookup.Size = new System.Drawing.Size(98, 29);
            this.checkBoxServiceLookup.TabIndex = 6;
            this.checkBoxServiceLookup.Text = "Lookup";
            this.checkBoxServiceLookup.UseVisualStyleBackColor = true;
            // 
            // checkBoxServiceList
            // 
            this.checkBoxServiceList.AutoSize = true;
            this.checkBoxServiceList.Location = new System.Drawing.Point(18, 109);
            this.checkBoxServiceList.Name = "checkBoxServiceList";
            this.checkBoxServiceList.Size = new System.Drawing.Size(64, 29);
            this.checkBoxServiceList.TabIndex = 5;
            this.checkBoxServiceList.Text = "List";
            this.checkBoxServiceList.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddColumn);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.listBoxColumns);
            this.groupBox1.Location = new System.Drawing.Point(29, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1192, 519);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Columns";
            // 
            // buttonAddColumn
            // 
            this.buttonAddColumn.Location = new System.Drawing.Point(113, 32);
            this.buttonAddColumn.Name = "buttonAddColumn";
            this.buttonAddColumn.Size = new System.Drawing.Size(148, 34);
            this.buttonAddColumn.TabIndex = 2;
            this.buttonAddColumn.Text = "Add Column";
            this.buttonAddColumn.UseVisualStyleBackColor = true;
            this.buttonAddColumn.Click += new System.EventHandler(this.buttonAddColumn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDeleteColumn);
            this.groupBox2.Controls.Add(this.buttonEditColumn);
            this.groupBox2.Controls.Add(this.checkBoxColumnAddToCriteria);
            this.groupBox2.Controls.Add(this.checkBoxColumnCanEdit);
            this.groupBox2.Controls.Add(this.checkBoxColumnCanAdd);
            this.groupBox2.Controls.Add(this.checkBoxColumnAddToDetail);
            this.groupBox2.Controls.Add(this.checkBoxColumnAddToList);
            this.groupBox2.Controls.Add(this.textBoxIsUniqueIndex);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxIsIndex);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBoxTableClass);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBoxNullable);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxEnumClassName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxDataType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxDbColumnName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxColumnName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(286, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 428);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Column Properties";
            // 
            // buttonDeleteColumn
            // 
            this.buttonDeleteColumn.Location = new System.Drawing.Point(694, 368);
            this.buttonDeleteColumn.Name = "buttonDeleteColumn";
            this.buttonDeleteColumn.Size = new System.Drawing.Size(172, 34);
            this.buttonDeleteColumn.TabIndex = 31;
            this.buttonDeleteColumn.Text = "Delete Column";
            this.buttonDeleteColumn.UseVisualStyleBackColor = true;
            this.buttonDeleteColumn.Click += new System.EventHandler(this.buttonDeleteColumn_Click);
            // 
            // buttonEditColumn
            // 
            this.buttonEditColumn.Location = new System.Drawing.Point(516, 368);
            this.buttonEditColumn.Name = "buttonEditColumn";
            this.buttonEditColumn.Size = new System.Drawing.Size(172, 34);
            this.buttonEditColumn.TabIndex = 3;
            this.buttonEditColumn.Text = "Edit Column";
            this.buttonEditColumn.UseVisualStyleBackColor = true;
            this.buttonEditColumn.Click += new System.EventHandler(this.buttonEditColumn_Click);
            // 
            // checkBoxColumnAddToCriteria
            // 
            this.checkBoxColumnAddToCriteria.AutoSize = true;
            this.checkBoxColumnAddToCriteria.Location = new System.Drawing.Point(533, 329);
            this.checkBoxColumnAddToCriteria.Name = "checkBoxColumnAddToCriteria";
            this.checkBoxColumnAddToCriteria.Size = new System.Drawing.Size(155, 29);
            this.checkBoxColumnAddToCriteria.TabIndex = 30;
            this.checkBoxColumnAddToCriteria.Text = "Add To Criteria";
            this.checkBoxColumnAddToCriteria.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnCanEdit
            // 
            this.checkBoxColumnCanEdit.AutoSize = true;
            this.checkBoxColumnCanEdit.Location = new System.Drawing.Point(371, 329);
            this.checkBoxColumnCanEdit.Name = "checkBoxColumnCanEdit";
            this.checkBoxColumnCanEdit.Size = new System.Drawing.Size(101, 29);
            this.checkBoxColumnCanEdit.TabIndex = 27;
            this.checkBoxColumnCanEdit.Text = "Editable";
            this.checkBoxColumnCanEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnCanAdd
            // 
            this.checkBoxColumnCanAdd.AutoSize = true;
            this.checkBoxColumnCanAdd.Location = new System.Drawing.Point(260, 329);
            this.checkBoxColumnCanAdd.Name = "checkBoxColumnCanAdd";
            this.checkBoxColumnCanAdd.Size = new System.Drawing.Size(105, 29);
            this.checkBoxColumnCanAdd.TabIndex = 26;
            this.checkBoxColumnCanAdd.Text = "Addable";
            this.checkBoxColumnCanAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnAddToDetail
            // 
            this.checkBoxColumnAddToDetail.AutoSize = true;
            this.checkBoxColumnAddToDetail.Location = new System.Drawing.Point(150, 329);
            this.checkBoxColumnAddToDetail.Name = "checkBoxColumnAddToDetail";
            this.checkBoxColumnAddToDetail.Size = new System.Drawing.Size(83, 29);
            this.checkBoxColumnAddToDetail.TabIndex = 25;
            this.checkBoxColumnAddToDetail.Text = "Detail";
            this.checkBoxColumnAddToDetail.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnAddToList
            // 
            this.checkBoxColumnAddToList.AutoSize = true;
            this.checkBoxColumnAddToList.Location = new System.Drawing.Point(47, 329);
            this.checkBoxColumnAddToList.Name = "checkBoxColumnAddToList";
            this.checkBoxColumnAddToList.Size = new System.Drawing.Size(97, 29);
            this.checkBoxColumnAddToList.TabIndex = 23;
            this.checkBoxColumnAddToList.Text = "Listable";
            this.checkBoxColumnAddToList.UseVisualStyleBackColor = true;
            // 
            // textBoxIsUniqueIndex
            // 
            this.textBoxIsUniqueIndex.Location = new System.Drawing.Point(598, 263);
            this.textBoxIsUniqueIndex.Name = "textBoxIsUniqueIndex";
            this.textBoxIsUniqueIndex.Size = new System.Drawing.Size(226, 31);
            this.textBoxIsUniqueIndex.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(429, 266);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 25);
            this.label12.TabIndex = 21;
            this.label12.Text = "Unique Index";
            // 
            // textBoxIsIndex
            // 
            this.textBoxIsIndex.Location = new System.Drawing.Point(163, 263);
            this.textBoxIsIndex.Name = "textBoxIsIndex";
            this.textBoxIsIndex.Size = new System.Drawing.Size(230, 31);
            this.textBoxIsIndex.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "Index";
            // 
            // textBoxTableClass
            // 
            this.textBoxTableClass.Location = new System.Drawing.Point(163, 190);
            this.textBoxTableClass.Name = "textBoxTableClass";
            this.textBoxTableClass.Size = new System.Drawing.Size(230, 31);
            this.textBoxTableClass.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Table Class";
            // 
            // textBoxNullable
            // 
            this.textBoxNullable.Location = new System.Drawing.Point(598, 140);
            this.textBoxNullable.Name = "textBoxNullable";
            this.textBoxNullable.Size = new System.Drawing.Size(226, 31);
            this.textBoxNullable.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(429, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Nullable";
            // 
            // textBoxEnumClassName
            // 
            this.textBoxEnumClassName.Location = new System.Drawing.Point(163, 140);
            this.textBoxEnumClassName.Name = "textBoxEnumClassName";
            this.textBoxEnumClassName.Size = new System.Drawing.Size(230, 31);
            this.textBoxEnumClassName.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Enum Class";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(598, 96);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(226, 31);
            this.textBoxSize.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Size";
            // 
            // textBoxDataType
            // 
            this.textBoxDataType.Location = new System.Drawing.Point(163, 93);
            this.textBoxDataType.Name = "textBoxDataType";
            this.textBoxDataType.Size = new System.Drawing.Size(230, 31);
            this.textBoxDataType.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data Type";
            // 
            // textBoxDbColumnName
            // 
            this.textBoxDbColumnName.Location = new System.Drawing.Point(598, 42);
            this.textBoxDbColumnName.Name = "textBoxDbColumnName";
            this.textBoxDbColumnName.Size = new System.Drawing.Size(226, 31);
            this.textBoxDbColumnName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Db Col Name";
            // 
            // textBoxColumnName
            // 
            this.textBoxColumnName.Location = new System.Drawing.Point(163, 42);
            this.textBoxColumnName.Name = "textBoxColumnName";
            this.textBoxColumnName.Size = new System.Drawing.Size(230, 31);
            this.textBoxColumnName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name";
            // 
            // listBoxColumns
            // 
            this.listBoxColumns.FormattingEnabled = true;
            this.listBoxColumns.ItemHeight = 25;
            this.listBoxColumns.Location = new System.Drawing.Point(30, 72);
            this.listBoxColumns.Name = "listBoxColumns";
            this.listBoxColumns.Size = new System.Drawing.Size(231, 429);
            this.listBoxColumns.TabIndex = 0;
            this.listBoxColumns.SelectedIndexChanged += new System.EventHandler(this.listBoxColumns_SelectedIndexChanged);
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(807, 56);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(307, 31);
            this.textBoxDbName.TabIndex = 3;
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Location = new System.Drawing.Point(222, 56);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(307, 31);
            this.textBoxClassName.TabIndex = 2;
            // 
            // labelDbName
            // 
            this.labelDbName.AutoSize = true;
            this.labelDbName.Location = new System.Drawing.Point(603, 62);
            this.labelDbName.Name = "labelDbName";
            this.labelDbName.Size = new System.Drawing.Size(132, 25);
            this.labelDbName.TabIndex = 1;
            this.labelDbName.Text = "Table DB Name";
            // 
            // labelTableClassName
            // 
            this.labelTableClassName.AutoSize = true;
            this.labelTableClassName.Location = new System.Drawing.Point(18, 62);
            this.labelTableClassName.Name = "labelTableClassName";
            this.labelTableClassName.Size = new System.Drawing.Size(149, 25);
            this.labelTableClassName.TabIndex = 0;
            this.labelTableClassName.Text = "Table Class Name";
            // 
            // buttonCreateTable
            // 
            this.buttonCreateTable.Location = new System.Drawing.Point(550, 791);
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.Size = new System.Drawing.Size(266, 45);
            this.buttonCreateTable.TabIndex = 3;
            this.buttonCreateTable.Text = "Create Table";
            this.buttonCreateTable.UseVisualStyleBackColor = true;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // textBoxProjectMame
            // 
            this.textBoxProjectMame.Location = new System.Drawing.Point(836, 32);
            this.textBoxProjectMame.Name = "textBoxProjectMame";
            this.textBoxProjectMame.Size = new System.Drawing.Size(307, 31);
            this.textBoxProjectMame.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Project Name";
            // 
            // TableGenrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 848);
            this.Controls.Add(this.textBoxProjectMame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateTable);
            this.Controls.Add(this.groupBoxTables);
            this.Controls.Add(this.textBoxProjectNameRoot);
            this.Controls.Add(this.labelProjectName);
            this.Name = "TableGenrator";
            this.Text = "Table Generator";
            this.Load += new System.EventHandler(this.TableGenrator_Load);
            this.groupBoxTables.ResumeLayout(false);
            this.groupBoxTables.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelProjectName;
        private TextBox textBoxProjectNameRoot;
        private GroupBox groupBoxTables;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
        private TextBox textBoxDbColumnName;
        private Label label5;
        private TextBox textBoxColumnName;
        private Label label4;
        private ListBox listBoxColumns;
        private TextBox textBoxDbName;
        private TextBox textBoxClassName;
        private Label labelDbName;
        private Label labelTableClassName;
        private TextBox textBoxNullable;
        private Label label9;
        private TextBox textBoxEnumClassName;
        private Label label8;
        private TextBox textBoxSize;
        private Label label7;
        private TextBox textBoxDataType;
        private TextBox textBoxTableClass;
        private Label label10;
        private CheckBox checkBoxServiceDelete;
        private CheckBox checkBoxServiceEdit;
        private CheckBox checkBoxServiceAdd;
        private CheckBox checkBoxServiceDetail;
        private CheckBox checkBoxServiceLookup;
        private CheckBox checkBoxServiceList;
        private Button buttonAddColumn;
        private CheckBox checkBoxColumnCanEdit;
        private CheckBox checkBoxColumnCanAdd;
        private CheckBox checkBoxColumnAddToDetail;
        private CheckBox checkBoxColumnAddToList;
        private TextBox textBoxIsUniqueIndex;
        private Label label12;
        private TextBox textBoxIsIndex;
        private Label label11;
        private CheckBox checkBoxColumnAddToCriteria;
        private Button buttonEditColumn;
        private Button buttonCreateTable;
        private Button buttonDeleteColumn;
        private TextBox textBoxProjectMame;
        private Label label1;
    }
}