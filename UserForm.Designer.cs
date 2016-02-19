namespace LoginForms
{
    partial class UserForm
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
            this.FormTypeSeperator = new System.Windows.Forms.TableLayoutPanel();
            this.NewFormInfoContainer = new System.Windows.Forms.Panel();
            this.NewFormsLabel = new System.Windows.Forms.Label();
            this.CollapseNewFormsButton = new System.Windows.Forms.Button();
            this.NewFormContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SavedFormInfoContainer = new System.Windows.Forms.Panel();
            this.SavedFormsLabel = new System.Windows.Forms.Label();
            this.CollapseSavedFormsButton = new System.Windows.Forms.Button();
            this.SavedFormContainer = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.LoginInfoSplitter)).BeginInit();
            this.LoginInfoSplitter.Panel1.SuspendLayout();
            this.LoginInfoSplitter.Panel2.SuspendLayout();
            this.LoginInfoSplitter.SuspendLayout();
            this.FormTypeSeperator.SuspendLayout();
            this.NewFormInfoContainer.SuspendLayout();
            this.SavedFormInfoContainer.SuspendLayout();
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
            this.LoginInfoSplitter.Panel2.Controls.Add(this.FormTypeSeperator);
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
            // FormTypeSeperator
            // 
            this.FormTypeSeperator.AutoSize = true;
            this.FormTypeSeperator.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormTypeSeperator.ColumnCount = 1;
            this.FormTypeSeperator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FormTypeSeperator.Controls.Add(this.NewFormInfoContainer, 0, 0);
            this.FormTypeSeperator.Controls.Add(this.NewFormContainer, 0, 1);
            this.FormTypeSeperator.Controls.Add(this.SavedFormInfoContainer, 0, 2);
            this.FormTypeSeperator.Controls.Add(this.SavedFormContainer, 0, 3);
            this.FormTypeSeperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTypeSeperator.Location = new System.Drawing.Point(0, 0);
            this.FormTypeSeperator.Name = "FormTypeSeperator";
            this.FormTypeSeperator.RowCount = 4;
            this.FormTypeSeperator.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormTypeSeperator.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormTypeSeperator.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormTypeSeperator.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormTypeSeperator.Size = new System.Drawing.Size(358, 360);
            this.FormTypeSeperator.TabIndex = 5;
            // 
            // NewFormInfoContainer
            // 
            this.NewFormInfoContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.NewFormInfoContainer.Controls.Add(this.NewFormsLabel);
            this.NewFormInfoContainer.Controls.Add(this.CollapseNewFormsButton);
            this.NewFormInfoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewFormInfoContainer.Location = new System.Drawing.Point(3, 3);
            this.NewFormInfoContainer.Name = "NewFormInfoContainer";
            this.NewFormInfoContainer.Size = new System.Drawing.Size(352, 25);
            this.NewFormInfoContainer.TabIndex = 2;
            // 
            // NewFormsLabel
            // 
            this.NewFormsLabel.AutoSize = true;
            this.NewFormsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormsLabel.Location = new System.Drawing.Point(0, 0);
            this.NewFormsLabel.Name = "NewFormsLabel";
            this.NewFormsLabel.Size = new System.Drawing.Size(94, 17);
            this.NewFormsLabel.TabIndex = 0;
            this.NewFormsLabel.Text = "New Forms: 0";
            // 
            // CollapseNewFormsButton
            // 
            this.CollapseNewFormsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollapseNewFormsButton.Location = new System.Drawing.Point(328, 0);
            this.CollapseNewFormsButton.Name = "CollapseNewFormsButton";
            this.CollapseNewFormsButton.Size = new System.Drawing.Size(19, 24);
            this.CollapseNewFormsButton.TabIndex = 1;
            this.CollapseNewFormsButton.Text = "Λ";
            this.CollapseNewFormsButton.UseVisualStyleBackColor = true;
            this.CollapseNewFormsButton.Click += new System.EventHandler(this.CollapseNewFormsButton_Click);
            // 
            // NewFormContainer
            // 
            this.NewFormContainer.AutoSize = true;
            this.NewFormContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewFormContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.NewFormContainer.Location = new System.Drawing.Point(3, 34);
            this.NewFormContainer.Name = "NewFormContainer";
            this.NewFormContainer.Size = new System.Drawing.Size(352, 1);
            this.NewFormContainer.TabIndex = 3;
            // 
            // SavedFormInfoContainer
            // 
            this.SavedFormInfoContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.SavedFormInfoContainer.Controls.Add(this.SavedFormsLabel);
            this.SavedFormInfoContainer.Controls.Add(this.CollapseSavedFormsButton);
            this.SavedFormInfoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SavedFormInfoContainer.Location = new System.Drawing.Point(3, 40);
            this.SavedFormInfoContainer.Name = "SavedFormInfoContainer";
            this.SavedFormInfoContainer.Size = new System.Drawing.Size(352, 26);
            this.SavedFormInfoContainer.TabIndex = 4;
            // 
            // SavedFormsLabel
            // 
            this.SavedFormsLabel.AutoSize = true;
            this.SavedFormsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavedFormsLabel.Location = new System.Drawing.Point(0, 0);
            this.SavedFormsLabel.Name = "SavedFormsLabel";
            this.SavedFormsLabel.Size = new System.Drawing.Size(107, 17);
            this.SavedFormsLabel.TabIndex = 0;
            this.SavedFormsLabel.Text = "Saved Forms: 0";
            // 
            // CollapseSavedFormsButton
            // 
            this.CollapseSavedFormsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollapseSavedFormsButton.Location = new System.Drawing.Point(328, 0);
            this.CollapseSavedFormsButton.Name = "CollapseSavedFormsButton";
            this.CollapseSavedFormsButton.Size = new System.Drawing.Size(19, 24);
            this.CollapseSavedFormsButton.TabIndex = 1;
            this.CollapseSavedFormsButton.Text = "Λ";
            this.CollapseSavedFormsButton.UseVisualStyleBackColor = true;
            this.CollapseSavedFormsButton.Click += new System.EventHandler(this.CollapseSavedFormsButton_Click);
            // 
            // SavedFormContainer
            // 
            this.SavedFormContainer.AutoSize = true;
            this.SavedFormContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SavedFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SavedFormContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SavedFormContainer.Location = new System.Drawing.Point(3, 72);
            this.SavedFormContainer.Name = "SavedFormContainer";
            this.SavedFormContainer.Size = new System.Drawing.Size(352, 285);
            this.SavedFormContainer.TabIndex = 5;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 389);
            this.Controls.Add(this.LoginInfoSplitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.LoginInfoSplitter.Panel1.ResumeLayout(false);
            this.LoginInfoSplitter.Panel1.PerformLayout();
            this.LoginInfoSplitter.Panel2.ResumeLayout(false);
            this.LoginInfoSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginInfoSplitter)).EndInit();
            this.LoginInfoSplitter.ResumeLayout(false);
            this.FormTypeSeperator.ResumeLayout(false);
            this.FormTypeSeperator.PerformLayout();
            this.NewFormInfoContainer.ResumeLayout(false);
            this.NewFormInfoContainer.PerformLayout();
            this.SavedFormInfoContainer.ResumeLayout(false);
            this.SavedFormInfoContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer LoginInfoSplitter;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button CollapseSavedFormsButton;
        private System.Windows.Forms.Label SavedFormsLabel;
        private System.Windows.Forms.Button CollapseNewFormsButton;
        private System.Windows.Forms.Label NewFormsLabel;
        private System.Windows.Forms.TableLayoutPanel FormTypeSeperator;
        private System.Windows.Forms.Panel NewFormInfoContainer;
        private System.Windows.Forms.FlowLayoutPanel NewFormContainer;
        private System.Windows.Forms.Panel SavedFormInfoContainer;
        private System.Windows.Forms.FlowLayoutPanel SavedFormContainer;
    }
}