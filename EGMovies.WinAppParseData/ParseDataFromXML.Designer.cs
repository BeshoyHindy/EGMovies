namespace EGMovies.WinAppParseData
{
    partial class ParseDataFromXML
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
            this.btnGenerateData = new System.Windows.Forms.Button();
            this.lblDataFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Location = new System.Drawing.Point(27, 48);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(251, 23);
            this.btnGenerateData.TabIndex = 0;
            this.btnGenerateData.Text = "Generate Data";
            this.btnGenerateData.UseVisualStyleBackColor = true;
            this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
            // 
            // lblDataFilePath
            // 
            this.lblDataFilePath.AutoSize = true;
            this.lblDataFilePath.Location = new System.Drawing.Point(24, 17);
            this.lblDataFilePath.Name = "lblDataFilePath";
            this.lblDataFilePath.Size = new System.Drawing.Size(35, 13);
            this.lblDataFilePath.TabIndex = 1;
            this.lblDataFilePath.Text = "label1";
            // 
            // ParseDataFromXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 159);
            this.Controls.Add(this.lblDataFilePath);
            this.Controls.Add(this.btnGenerateData);
            this.Name = "ParseDataFromXML";
            this.Text = "ParseDataFromXML";
            this.Load += new System.EventHandler(this.ParseDataFromXML_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateData;
        private System.Windows.Forms.Label lblDataFilePath;
    }
}