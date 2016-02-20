namespace LoginForms
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
            this.CreateFormButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.EditUserInfoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LoginInfoSplitter)).BeginInit();
            this.LoginInfoSplitter.Panel1.SuspendLayout();
            this.LoginInfoSplitter.Panel2.SuspendLayout();
            this.LoginInfoSplitter.SuspendLayout();
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
            this.LoginInfoSplitter.Panel2.Controls.Add(this.CreateFormButton);
            this.LoginInfoSplitter.Panel2.Controls.Add(this.AddUserButton);
            this.LoginInfoSplitter.Panel2.Controls.Add(this.EditUserInfoButton);
            this.LoginInfoSplitter.Size = new System.Drawing.Size(358, 389);
            this.LoginInfoSplitter.SplitterDistance = 25;
            this.LoginInfoSplitter.TabIndex = 0;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LogOutButton.Location = new System.Drawing.Point(280, 0);
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
            this.UsernameLabel.Location = new System.Drawing.Point(0, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(196, 20);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Logged in as USERNAME";
            // 
            // CreateFormButton
            // 
            this.CreateFormButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateFormButton.Location = new System.Drawing.Point(0, 46);
            this.CreateFormButton.Name = "CreateFormButton";
            this.CreateFormButton.Size = new System.Drawing.Size(358, 23);
            this.CreateFormButton.TabIndex = 3;
            this.CreateFormButton.Text = "Create Form";
            this.CreateFormButton.UseVisualStyleBackColor = true;
            this.CreateFormButton.Click += new System.EventHandler(this.CreateFormButton_Click);
            // 
            // AddUserButton
            // 
            this.AddUserButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddUserButton.Location = new System.Drawing.Point(0, 23);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(358, 23);
            this.AddUserButton.TabIndex = 2;
            this.AddUserButton.Text = "Add User";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // EditUserInfoButton
            // 
            this.EditUserInfoButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditUserInfoButton.Location = new System.Drawing.Point(0, 0);
            this.EditUserInfoButton.Name = "EditUserInfoButton";
            this.EditUserInfoButton.Size = new System.Drawing.Size(358, 23);
            this.EditUserInfoButton.TabIndex = 1;
            this.EditUserInfoButton.Text = "Edit User Info";
            this.EditUserInfoButton.UseVisualStyleBackColor = true;
            this.EditUserInfoButton.Click += new System.EventHandler(this.EditUserInfoButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 389);
            this.Controls.Add(this.LoginInfoSplitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.LoginInfoSplitter.Panel1.ResumeLayout(false);
            this.LoginInfoSplitter.Panel1.PerformLayout();
            this.LoginInfoSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoginInfoSplitter)).EndInit();
            this.LoginInfoSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer LoginInfoSplitter;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button CreateFormButton;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button EditUserInfoButton;
    }
}