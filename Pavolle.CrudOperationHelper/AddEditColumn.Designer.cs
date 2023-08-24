namespace Pavolle.CrudOperationHelper
{
    partial class AddEditColumn
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBoxUniqueIndex = new System.Windows.Forms.CheckBox();
            this.checkBoxIndex = new System.Windows.Forms.CheckBox();
            this.checkBoxNullable = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEditColumn = new System.Windows.Forms.Button();
            this.checkBoxColumnAddToCriteria = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnCanEdit = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnCanAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnAddToDetail = new System.Windows.Forms.CheckBox();
            this.checkBoxColumnAddToList = new System.Windows.Forms.CheckBox();
            this.textBoxTableClass = new System.Windows.Forms.TextBox();
            this.labelTableClass = new System.Windows.Forms.Label();
            this.textBoxEnumClassName = new System.Windows.Forms.TextBox();
            this.labelEnumClass = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDbColumnName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.checkBoxUniqueIndex);
            this.groupBox2.Controls.Add(this.checkBoxIndex);
            this.groupBox2.Controls.Add(this.checkBoxNullable);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Controls.Add(this.buttonEditColumn);
            this.groupBox2.Controls.Add(this.checkBoxColumnAddToCriteria);
            this.groupBox2.Controls.Add(this.checkBoxColumnCanEdit);
            this.groupBox2.Controls.Add(this.checkBoxColumnCanAdd);
            this.groupBox2.Controls.Add(this.checkBoxColumnAddToDetail);
            this.groupBox2.Controls.Add(this.checkBoxColumnAddToList);
            this.groupBox2.Controls.Add(this.textBoxTableClass);
            this.groupBox2.Controls.Add(this.labelTableClass);
            this.groupBox2.Controls.Add(this.textBoxEnumClassName);
            this.groupBox2.Controls.Add(this.labelEnumClass);
            this.groupBox2.Controls.Add(this.textBoxSize);
            this.groupBox2.Controls.Add(this.labelSize);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxDbColumnName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(24, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 346);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Column Properties";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "LONG",
            "STRING",
            "INT",
            "FLOAT",
            "DOUBLE",
            "ENUM",
            "CLASS"});
            this.comboBox1.Location = new System.Drawing.Point(163, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(230, 33);
            this.comboBox1.TabIndex = 35;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBoxUniqueIndex
            // 
            this.checkBoxUniqueIndex.AutoSize = true;
            this.checkBoxUniqueIndex.Location = new System.Drawing.Point(153, 191);
            this.checkBoxUniqueIndex.Name = "checkBoxUniqueIndex";
            this.checkBoxUniqueIndex.Size = new System.Drawing.Size(142, 29);
            this.checkBoxUniqueIndex.TabIndex = 34;
            this.checkBoxUniqueIndex.Text = "Unique Index";
            this.checkBoxUniqueIndex.UseVisualStyleBackColor = true;
            // 
            // checkBoxIndex
            // 
            this.checkBoxIndex.AutoSize = true;
            this.checkBoxIndex.Location = new System.Drawing.Point(38, 191);
            this.checkBoxIndex.Name = "checkBoxIndex";
            this.checkBoxIndex.Size = new System.Drawing.Size(81, 29);
            this.checkBoxIndex.TabIndex = 33;
            this.checkBoxIndex.Text = "Index";
            this.checkBoxIndex.UseVisualStyleBackColor = true;
            // 
            // checkBoxNullable
            // 
            this.checkBoxNullable.AutoSize = true;
            this.checkBoxNullable.Location = new System.Drawing.Point(722, 243);
            this.checkBoxNullable.Name = "checkBoxNullable";
            this.checkBoxNullable.Size = new System.Drawing.Size(102, 29);
            this.checkBoxNullable.TabIndex = 32;
            this.checkBoxNullable.Text = "Nullable";
            this.checkBoxNullable.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(697, 298);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(172, 34);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonEditColumn
            // 
            this.buttonEditColumn.Location = new System.Drawing.Point(519, 298);
            this.buttonEditColumn.Name = "buttonEditColumn";
            this.buttonEditColumn.Size = new System.Drawing.Size(172, 34);
            this.buttonEditColumn.TabIndex = 3;
            this.buttonEditColumn.Text = "Cancel";
            this.buttonEditColumn.UseVisualStyleBackColor = true;
            this.buttonEditColumn.Click += new System.EventHandler(this.buttonEditColumn_Click);
            // 
            // checkBoxColumnAddToCriteria
            // 
            this.checkBoxColumnAddToCriteria.AutoSize = true;
            this.checkBoxColumnAddToCriteria.Location = new System.Drawing.Point(536, 243);
            this.checkBoxColumnAddToCriteria.Name = "checkBoxColumnAddToCriteria";
            this.checkBoxColumnAddToCriteria.Size = new System.Drawing.Size(155, 29);
            this.checkBoxColumnAddToCriteria.TabIndex = 30;
            this.checkBoxColumnAddToCriteria.Text = "Add To Criteria";
            this.checkBoxColumnAddToCriteria.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnCanEdit
            // 
            this.checkBoxColumnCanEdit.AutoSize = true;
            this.checkBoxColumnCanEdit.Location = new System.Drawing.Point(393, 243);
            this.checkBoxColumnCanEdit.Name = "checkBoxColumnCanEdit";
            this.checkBoxColumnCanEdit.Size = new System.Drawing.Size(101, 29);
            this.checkBoxColumnCanEdit.TabIndex = 27;
            this.checkBoxColumnCanEdit.Text = "Editable";
            this.checkBoxColumnCanEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnCanAdd
            // 
            this.checkBoxColumnCanAdd.AutoSize = true;
            this.checkBoxColumnCanAdd.Location = new System.Drawing.Point(263, 243);
            this.checkBoxColumnCanAdd.Name = "checkBoxColumnCanAdd";
            this.checkBoxColumnCanAdd.Size = new System.Drawing.Size(105, 29);
            this.checkBoxColumnCanAdd.TabIndex = 26;
            this.checkBoxColumnCanAdd.Text = "Addable";
            this.checkBoxColumnCanAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnAddToDetail
            // 
            this.checkBoxColumnAddToDetail.AutoSize = true;
            this.checkBoxColumnAddToDetail.Location = new System.Drawing.Point(153, 243);
            this.checkBoxColumnAddToDetail.Name = "checkBoxColumnAddToDetail";
            this.checkBoxColumnAddToDetail.Size = new System.Drawing.Size(83, 29);
            this.checkBoxColumnAddToDetail.TabIndex = 25;
            this.checkBoxColumnAddToDetail.Text = "Detail";
            this.checkBoxColumnAddToDetail.UseVisualStyleBackColor = true;
            // 
            // checkBoxColumnAddToList
            // 
            this.checkBoxColumnAddToList.AutoSize = true;
            this.checkBoxColumnAddToList.Location = new System.Drawing.Point(38, 243);
            this.checkBoxColumnAddToList.Name = "checkBoxColumnAddToList";
            this.checkBoxColumnAddToList.Size = new System.Drawing.Size(97, 29);
            this.checkBoxColumnAddToList.TabIndex = 23;
            this.checkBoxColumnAddToList.Text = "Listable";
            this.checkBoxColumnAddToList.UseVisualStyleBackColor = true;
            // 
            // textBoxTableClass
            // 
            this.textBoxTableClass.Location = new System.Drawing.Point(598, 143);
            this.textBoxTableClass.Name = "textBoxTableClass";
            this.textBoxTableClass.Size = new System.Drawing.Size(230, 31);
            this.textBoxTableClass.TabIndex = 18;
            // 
            // labelTableClass
            // 
            this.labelTableClass.AutoSize = true;
            this.labelTableClass.Location = new System.Drawing.Point(429, 146);
            this.labelTableClass.Name = "labelTableClass";
            this.labelTableClass.Size = new System.Drawing.Size(97, 25);
            this.labelTableClass.TabIndex = 17;
            this.labelTableClass.Text = "Table Class";
            this.labelTableClass.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBoxEnumClassName
            // 
            this.textBoxEnumClassName.Location = new System.Drawing.Point(163, 140);
            this.textBoxEnumClassName.Name = "textBoxEnumClassName";
            this.textBoxEnumClassName.Size = new System.Drawing.Size(230, 31);
            this.textBoxEnumClassName.TabIndex = 14;
            // 
            // labelEnumClass
            // 
            this.labelEnumClass.AutoSize = true;
            this.labelEnumClass.Location = new System.Drawing.Point(38, 143);
            this.labelEnumClass.Name = "labelEnumClass";
            this.labelEnumClass.Size = new System.Drawing.Size(102, 25);
            this.labelEnumClass.TabIndex = 13;
            this.labelEnumClass.Text = "Enum Class";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(598, 96);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(226, 31);
            this.textBoxSize.TabIndex = 12;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(429, 99);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(43, 25);
            this.labelSize.TabIndex = 11;
            this.labelSize.Text = "Size";
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
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(163, 42);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(230, 31);
            this.textBoxName.TabIndex = 6;
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
            // AddEditColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 383);
            this.Controls.Add(this.groupBox2);
            this.Name = "AddEditColumn";
            this.Text = "Add/Edit Column";
            this.Load += new System.EventHandler(this.AddEditColumn_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private CheckBox checkBoxUniqueIndex;
        private CheckBox checkBoxIndex;
        private CheckBox checkBoxNullable;
        private Button buttonSave;
        private Button buttonEditColumn;
        private CheckBox checkBoxColumnAddToCriteria;
        private CheckBox checkBoxColumnCanEdit;
        private CheckBox checkBoxColumnCanAdd;
        private CheckBox checkBoxColumnAddToDetail;
        private CheckBox checkBoxColumnAddToList;
        private TextBox textBoxTableClass;
        private Label labelTableClass;
        private TextBox textBoxEnumClassName;
        private Label labelEnumClass;
        private TextBox textBoxSize;
        private Label labelSize;
        private Label label6;
        private TextBox textBoxDbColumnName;
        private Label label5;
        private TextBox textBoxName;
        private Label label4;
        private ComboBox comboBox1;
    }
}