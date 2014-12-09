namespace Kesoft.Common.Tests.Windows.Forms
{
    partial class FormCustomToolStripStatusLabel
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.customToolStripStatusLabel1 = new Kesoft.Common.Windows.Forms.CustomToolStripStatusLabel(this.components);
            this.btnError = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnLoading = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 276);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(533, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // customToolStripStatusLabel1
            // 
            this.customToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customToolStripStatusLabel1.Name = "customToolStripStatusLabel1";
            this.customToolStripStatusLabel1.Size = new System.Drawing.Size(518, 17);
            this.customToolStripStatusLabel1.Spring = true;
            this.customToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(12, 12);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(75, 23);
            this.btnError.TabIndex = 1;
            this.btnError.Text = "Error";
            this.btnError.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 41);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnLoading
            // 
            this.btnLoading.Location = new System.Drawing.Point(12, 70);
            this.btnLoading.Name = "btnLoading";
            this.btnLoading.Size = new System.Drawing.Size(75, 23);
            this.btnLoading.TabIndex = 3;
            this.btnLoading.Text = "Loading";
            this.btnLoading.UseVisualStyleBackColor = true;
            // 
            // FormCustomToolStripStatusLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 298);
            this.Controls.Add(this.btnLoading);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormCustomToolStripStatusLabel";
            this.Text = "FormCustomToolStripStatusLabel";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private Common.Windows.Forms.CustomToolStripStatusLabel customToolStripStatusLabel1;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnLoading;
    }
}