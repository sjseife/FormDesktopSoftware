namespace FormsProject
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginContainer = new System.Windows.Forms.GroupBox();
            this.ETSULogoPictureBox = new System.Windows.Forms.PictureBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PictureLoginSeperator = new System.Windows.Forms.SplitContainer();
            this.LoginContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ETSULogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoginSeperator)).BeginInit();
            this.PictureLoginSeperator.Panel1.SuspendLayout();
            this.PictureLoginSeperator.Panel2.SuspendLayout();
            this.PictureLoginSeperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginContainer
            // 
            this.LoginContainer.Controls.Add(this.PictureLoginSeperator);
            this.LoginContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginContainer.Location = new System.Drawing.Point(0, 0);
            this.LoginContainer.Name = "LoginContainer";
            this.LoginContainer.Size = new System.Drawing.Size(784, 619);
            this.LoginContainer.TabIndex = 1;
            this.LoginContainer.TabStop = false;
            this.LoginContainer.Text = "Login";
            // 
            // ETSULogoPictureBox
            // 
            this.ETSULogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ETSULogoPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.ETSULogoPictureBox.Image = global::FormsProject.Properties.Resources.ETSU1;
            this.ETSULogoPictureBox.Location = new System.Drawing.Point(205, 0);
            this.ETSULogoPictureBox.Name = "ETSULogoPictureBox";
            this.ETSULogoPictureBox.Size = new System.Drawing.Size(392, 208);
            this.ETSULogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ETSULogoPictureBox.TabIndex = 6;
            this.ETSULogoPictureBox.TabStop = false;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(120, 11);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(192, 13);
            this.ErrorLabel.TabIndex = 5;
            this.ErrorLabel.Text = "Username and password do not match!";
            this.ErrorLabel.Visible = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(123, 88);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(56, 65);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(65, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(56, 30);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(67, 13);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(123, 62);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(176, 20);
            this.PasswordTextbox.TabIndex = 1;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextbox_KeyPress);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(123, 27);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(176, 20);
            this.UsernameTextbox.TabIndex = 0;
            this.UsernameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTextbox_KeyPress);
            // 
            // PictureLoginSeperator
            // 
            this.PictureLoginSeperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureLoginSeperator.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.PictureLoginSeperator.IsSplitterFixed = true;
            this.PictureLoginSeperator.Location = new System.Drawing.Point(3, 16);
            this.PictureLoginSeperator.Name = "PictureLoginSeperator";
            this.PictureLoginSeperator.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // PictureLoginSeperator.Panel1
            // 
            this.PictureLoginSeperator.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.PictureLoginSeperator.Panel1.Controls.Add(this.ETSULogoPictureBox);
            // 
            // PictureLoginSeperator.Panel2
            // 
            this.PictureLoginSeperator.Panel2.Controls.Add(this.LoginButton);
            this.PictureLoginSeperator.Panel2.Controls.Add(this.ErrorLabel);
            this.PictureLoginSeperator.Panel2.Controls.Add(this.PasswordLabel);
            this.PictureLoginSeperator.Panel2.Controls.Add(this.UsernameLabel);
            this.PictureLoginSeperator.Panel2.Controls.Add(this.PasswordTextbox);
            this.PictureLoginSeperator.Panel2.Controls.Add(this.UsernameTextbox);
            this.PictureLoginSeperator.Size = new System.Drawing.Size(778, 600);
            this.PictureLoginSeperator.SplitterDistance = 209;
            this.PictureLoginSeperator.TabIndex = 7;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 619);
            this.Controls.Add(this.LoginContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LoginContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ETSULogoPictureBox)).EndInit();
            this.PictureLoginSeperator.Panel1.ResumeLayout(false);
            this.PictureLoginSeperator.Panel2.ResumeLayout(false);
            this.PictureLoginSeperator.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoginSeperator)).EndInit();
            this.PictureLoginSeperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LoginContainer;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.PictureBox ETSULogoPictureBox;
        private System.Windows.Forms.SplitContainer PictureLoginSeperator;
    }
}