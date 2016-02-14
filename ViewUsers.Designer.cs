namespace LoginForms
{
    partial class ViewUsers
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
            this.UserList = new System.Windows.Forms.ListBox();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(0, 0);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(342, 333);
            this.UserList.TabIndex = 0;
            this.UserList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UserList_MouseDoubleClick);
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpLabel.Location = new System.Drawing.Point(0, 0);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(92, 16);
            this.HelpLabel.TabIndex = 1;
            this.HelpLabel.Text = "Select a User:";
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.IsSplitterFixed = true;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.HelpLabel);
            this.SplitContainer.Panel1MinSize = 10;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.UserList);
            this.SplitContainer.Size = new System.Drawing.Size(342, 351);
            this.SplitContainer.SplitterDistance = 14;
            this.SplitContainer.TabIndex = 2;
            // 
            // ViewUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(342, 351);
            this.Controls.Add(this.SplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewUsers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewUsers_Load);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel1.PerformLayout();
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Label HelpLabel;
        private System.Windows.Forms.SplitContainer SplitContainer;
    }
}