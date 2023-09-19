namespace Pavolle.SmartAppCoder
{
    partial class MainForm
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
            listBoxProjectList = new ListBox();
            buttonNewProject = new Button();
            SuspendLayout();
            // 
            // listBoxProjectList
            // 
            listBoxProjectList.FormattingEnabled = true;
            listBoxProjectList.ItemHeight = 25;
            listBoxProjectList.Location = new Point(28, 99);
            listBoxProjectList.Name = "listBoxProjectList";
            listBoxProjectList.Size = new Size(463, 779);
            listBoxProjectList.TabIndex = 0;
            // 
            // buttonNewProject
            // 
            buttonNewProject.Location = new Point(301, 32);
            buttonNewProject.Name = "buttonNewProject";
            buttonNewProject.Size = new Size(190, 48);
            buttonNewProject.TabIndex = 1;
            buttonNewProject.Text = "New Project";
            buttonNewProject.UseVisualStyleBackColor = true;
            buttonNewProject.Click += buttonNewProject_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 899);
            Controls.Add(buttonNewProject);
            Controls.Add(listBoxProjectList);
            Name = "MainForm";
            Text = "Smart App Coder";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxProjectList;
        private Button buttonNewProject;
    }
}