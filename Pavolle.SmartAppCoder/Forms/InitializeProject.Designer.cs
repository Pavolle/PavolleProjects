namespace Pavolle.SmartAppCoder.Forms
{
    partial class InitializeProject
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
            buttonStart = new Button();
            textBoxOutput = new TextBox();
            labelProjectInfo = new Label();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(594, 12);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(180, 62);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(12, 80);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(776, 740);
            textBoxOutput.TabIndex = 1;
            // 
            // labelProjectInfo
            // 
            labelProjectInfo.AutoSize = true;
            labelProjectInfo.Location = new Point(40, 28);
            labelProjectInfo.Name = "labelProjectInfo";
            labelProjectInfo.Size = new Size(59, 25);
            labelProjectInfo.TabIndex = 2;
            labelProjectInfo.Text = "label1";
            // 
            // InitializeProject
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 845);
            Controls.Add(labelProjectInfo);
            Controls.Add(textBoxOutput);
            Controls.Add(buttonStart);
            Name = "InitializeProject";
            Text = "Initialize Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private TextBox textBoxOutput;
        private Label labelProjectInfo;
    }
}