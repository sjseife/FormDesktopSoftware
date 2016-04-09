namespace FormsProject
{
    partial class AdminForm
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
            this.LoginInfoSplitter = new System.Windows.Forms.SplitContainer();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ETSULogoPictureBox = new System.Windows.Forms.PictureBox();
            this.UserManageButton = new System.Windows.Forms.Button();
            this.FormManagementButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LoginInfoSplitter)).BeginInit();
            this.LoginInfoSplitter.Panel1.SuspendLayout();
            this.LoginInfoSplitter.Panel2.SuspendLayout();
            this.LoginInfoSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ETSULogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginInfoSplitter
            // 
            this.LoginInfoSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginInfoSplitter.IsSplitterFixed = true;
            this.LoginInfoSplitter.Location = new System.Drawing.Point(0, 0);
            this.LoginInfoSplitter.Name = "LoginInfoSplitter";
            this.LoginInfoSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LoginInfoSplitter.Panel1
            // 
            this.LoginInfoSplitter.Panel1.BackColor = System.Drawing.Color.White;
            this.LoginInfoSplitter.Panel1.Controls.Add(this.LogOutButton);
            this.LoginInfoSplitter.Panel1.Controls.Add(this.UsernameLabel);
            // 
            // LoginInfoSplitter.Panel2
            // 
            this.LoginInfoSplitter.Panel2.AutoScroll = true;
            this.LoginInfoSplitter.Panel2.Controls.Add(this.ETSULogoPictureBox);
            this.LoginInfoSplitter.Panel2.Controls.Add(this.FormManagementButton);
            this.LoginInfoSplitter.Panel2.Controls.Add(this.UserManageButton);
            this.LoginInfoSplitter.Size = new System.Drawing.Size(784, 619);
            this.LoginInfoSplitter.SplitterDistance = 39;
            this.LoginInfoSplitter.TabIndex = 0;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.Location = new System.Drawing.Point(706, 7);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(75, 23);
            this.LogOutButton.TabIndex = 1;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(0, 7);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(196, 20);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Logged in as USERNAME";
            // 
            // ETSULogoPictureBox
            // 
            this.ETSULogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ETSULogoPictureBox.Image = global::FormsProject.Properties.Resources.ETSUlogo;
            this.ETSULogoPictureBox.Location = new System.Drawing.Point(224, 424);
            this.ETSULogoPictureBox.Name = "ETSULogoPictureBox";
            this.ETSULogoPictureBox.Padding = new System.Windows.Forms.Padding(1);
            this.ETSULogoPictureBox.Size = new System.Drawing.Size(351, 151);
            this.ETSULogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ETSULogoPictureBox.TabIndex = 4;
            this.ETSULogoPictureBox.TabStop = false;
            // 
            // UserManageButton
            // 
            this.UserManageButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserManageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserManageButton.Location = new System.Drawing.Point(0, 0);
            this.UserManageButton.Name = "UserManageButton";
            this.UserManageButton.Size = new System.Drawing.Size(784, 47);
            this.UserManageButton.TabIndex = 5;
            this.UserManageButton.Text = "User Management";
            this.UserManageButton.UseVisualStyleBackColor = true;
            this.UserManageButton.Click += new System.EventHandler(this.UserManageButton_Click);
            // 
            // FormManagementButton
            // 
            this.FormManagementButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormManagementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormManagementButton.Location = new System.Drawing.Point(0, 47);
            this.FormManagementButton.Name = "FormManagementButton";
            this.FormManagementButton.Size = new System.Drawing.Size(784, 47);
            this.FormManagementButton.TabIndex = 6;
            this.FormManagementButton.Text = "Form Management";
            this.FormManagementButton.UseVisualStyleBackColor = true;
            this.FormManagementButton.Click += new System.EventHandler(this.FormManagementButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 619);
            this.Controls.Add(this.LoginInfoSplitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.LoginInfoSplitter.Panel1.ResumeLayout(false);
            this.LoginInfoSplitter.Panel1.PerformLayout();
            this.LoginInfoSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoginInfoSplitter)).EndInit();
            this.LoginInfoSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ETSULogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer LoginInfoSplitter;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.PictureBox ETSULogoPictureBox;
        private System.Windows.Forms.Button UserManageButton;
        private System.Windows.Forms.Button FormManagementButton;
    }
}