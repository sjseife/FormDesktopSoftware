namespace LoginForms
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
            this.InvisibleStrip = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // InvisibleStrip
            // 
            this.InvisibleStrip.Location = new System.Drawing.Point(0, 0);
            this.InvisibleStrip.Name = "InvisibleStrip";
            this.InvisibleStrip.Size = new System.Drawing.Size(374, 24);
            this.InvisibleStrip.TabIndex = 1;
            this.InvisibleStrip.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 427);
            this.Controls.Add(this.InvisibleStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.InvisibleStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Forms Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip InvisibleStrip;


    }
}

