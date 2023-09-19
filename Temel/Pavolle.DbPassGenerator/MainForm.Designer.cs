namespace Pavolle.DbPassGenerator
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
            this.buttonDbPassGenerator = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDbPassGenerator
            // 
            this.buttonDbPassGenerator.Location = new System.Drawing.Point(55, 83);
            this.buttonDbPassGenerator.Name = "buttonDbPassGenerator";
            this.buttonDbPassGenerator.Size = new System.Drawing.Size(226, 34);
            this.buttonDbPassGenerator.TabIndex = 0;
            this.buttonDbPassGenerator.Text = "Password Generator";
            this.buttonDbPassGenerator.UseVisualStyleBackColor = true;
            this.buttonDbPassGenerator.Click += new System.EventHandler(this.buttonDbPassGenerator_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDbPassGenerator);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonDbPassGenerator;
    }
}