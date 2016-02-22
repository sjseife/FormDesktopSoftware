namespace FormsProject
{
    partial class FormViewer
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
            this.HTMLViewer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // HTMLViewer
            // 
            this.HTMLViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HTMLViewer.Location = new System.Drawing.Point(0, 0);
            this.HTMLViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.HTMLViewer.Name = "HTMLViewer";
            this.HTMLViewer.Size = new System.Drawing.Size(342, 351);
            this.HTMLViewer.TabIndex = 0;
            this.HTMLViewer.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.HTMLViewer_DocumentCompleted);
            this.HTMLViewer.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.HTMLViewer_Navigating);
            // 
            // FormViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 351);
            this.Controls.Add(this.HTMLViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser HTMLViewer;
    }
}