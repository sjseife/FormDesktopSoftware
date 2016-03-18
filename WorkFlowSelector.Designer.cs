namespace FormsProject
{
    partial class WorkFlowSelector
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
            this.Add1 = new System.Windows.Forms.Button();
            this.workFlowPanel = new System.Windows.Forms.Panel();
            this.workFlowList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.arrowTemplate = new System.Windows.Forms.PictureBox();
            this.workFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arrowTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // Add1
            // 
            this.Add1.BackColor = System.Drawing.SystemColors.Control;
            this.Add1.Location = new System.Drawing.Point(353, 142);
            this.Add1.Name = "Add1";
            this.Add1.Size = new System.Drawing.Size(22, 22);
            this.Add1.TabIndex = 5;
            this.Add1.Text = "+";
            this.Add1.UseVisualStyleBackColor = false;
            this.Add1.Click += new System.EventHandler(this.Add1_Click);
            // 
            // workFlowPanel
            // 
            this.workFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workFlowPanel.Controls.Add(this.workFlowList);
            this.workFlowPanel.Location = new System.Drawing.Point(62, 124);
            this.workFlowPanel.Name = "workFlowPanel";
            this.workFlowPanel.Size = new System.Drawing.Size(326, 66);
            this.workFlowPanel.TabIndex = 4;
            this.workFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NewObjectContainer_Paint);
            // 
            // workFlowList
            // 
            this.workFlowList.FormattingEnabled = true;
            this.workFlowList.Items.AddRange(new object[] {
            "Assign Authorization Privileges"});
            this.workFlowList.Location = new System.Drawing.Point(21, 17);
            this.workFlowList.Name = "workFlowList";
            this.workFlowList.Size = new System.Drawing.Size(263, 21);
            this.workFlowList.TabIndex = 1;
            this.workFlowList.Text = "Assign Authorization Privileges";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Workflow";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(450, 390);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.arrowTemplate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 348);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.SubmitButton);
            this.panel2.Controls.Add(this.CancelButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 38);
            this.panel2.TabIndex = 0;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(10, 8);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(90, 8);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // arrowTemplate
            // 
            this.arrowTemplate.Image = global::FormsProject.Properties.Resources.downArrow;
            this.arrowTemplate.Location = new System.Drawing.Point(208, 191);
            this.arrowTemplate.Name = "arrowTemplate";
            this.arrowTemplate.Size = new System.Drawing.Size(26, 22);
            this.arrowTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrowTemplate.TabIndex = 8;
            this.arrowTemplate.TabStop = false;
            this.arrowTemplate.Visible = false;
            // 
            // WorkFlowSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(450, 390);
            this.ControlBox = false;
            this.Controls.Add(this.Add1);
            this.Controls.Add(this.workFlowPanel);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkFlowSelector";
            this.Text = "Workflow Selector";
            this.workFlowPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arrowTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add1;
        private System.Windows.Forms.Panel workFlowPanel;
        private System.Windows.Forms.ComboBox workFlowList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.PictureBox arrowTemplate;
    }
}