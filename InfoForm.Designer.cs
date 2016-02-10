namespace LoginForms
{
    partial class InfoForm
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
            this.UserInfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserInfoTextBox
            // 
            this.UserInfoTextBox.BackColor = System.Drawing.Color.White;
            this.UserInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserInfoTextBox.Location = new System.Drawing.Point(0, 0);
            this.UserInfoTextBox.Multiline = true;
            this.UserInfoTextBox.Name = "UserInfoTextBox";
            this.UserInfoTextBox.ReadOnly = true;
            this.UserInfoTextBox.Size = new System.Drawing.Size(284, 262);
            this.UserInfoTextBox.TabIndex = 0;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.UserInfoTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserInfoTextBox;

    }
}