namespace FormsProject
{
    partial class FormCreator
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
            this.Title = new System.Windows.Forms.TextBox();
            this.Add1 = new System.Windows.Forms.Button();
            this.NewObjectCombo = new System.Windows.Forms.ComboBox();
            this.NewObjectContainer = new System.Windows.Forms.Panel();
            this.numberCombo = new System.Windows.Forms.ComboBox();
            this.addRadio = new System.Windows.Forms.Button();
            this.radioLabel = new System.Windows.Forms.Label();
            this.addCheckBox = new System.Windows.Forms.Button();
            this.addCombo = new System.Windows.Forms.Button();
            this.ComboDone = new System.Windows.Forms.Button();
            this.ComboChange = new System.Windows.Forms.Button();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonSplitter = new System.Windows.Forms.SplitContainer();
            this.AddWorkflow = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.NewObjectContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSplitter)).BeginInit();
            this.ButtonSplitter.Panel1.SuspendLayout();
            this.ButtonSplitter.Panel2.SuspendLayout();
            this.ButtonSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AcceptsReturn = true;
            this.Title.Location = new System.Drawing.Point(288, 24);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(200, 20);
            this.Title.TabIndex = 0;
            this.Title.Tag = "Title";
            this.Title.Text = "Insert Title Here";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Add1
            // 
            this.Add1.BackColor = System.Drawing.SystemColors.Control;
            this.Add1.Location = new System.Drawing.Point(512, 87);
            this.Add1.Name = "Add1";
            this.Add1.Size = new System.Drawing.Size(22, 22);
            this.Add1.TabIndex = 2;
            this.Add1.Text = "+";
            this.Add1.UseVisualStyleBackColor = false;
            this.Add1.Click += new System.EventHandler(this.Add1_Click);
            // 
            // NewObjectCombo
            // 
            this.NewObjectCombo.FormattingEnabled = true;
            this.NewObjectCombo.Items.AddRange(new object[] {
            "Select Form Object to Add",
            "Add Username",
            "Add Password",
            "Add Text Box",
            "Add Dropdown",
            "Add Radio Buttons",
            "Add Checkboxes",
            "Add Date",
            "Add Multi-Line Textbox"});
            this.NewObjectCombo.Location = new System.Drawing.Point(21, 17);
            this.NewObjectCombo.Name = "NewObjectCombo";
            this.NewObjectCombo.Size = new System.Drawing.Size(263, 21);
            this.NewObjectCombo.TabIndex = 1;
            this.NewObjectCombo.Text = "Select Form Object to Add";
            // 
            // NewObjectContainer
            // 
            this.NewObjectContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewObjectContainer.Controls.Add(this.NewObjectCombo);
            this.NewObjectContainer.Location = new System.Drawing.Point(221, 69);
            this.NewObjectContainer.Name = "NewObjectContainer";
            this.NewObjectContainer.Size = new System.Drawing.Size(326, 66);
            this.NewObjectContainer.TabIndex = 1;
            // 
            // numberCombo
            // 
            this.numberCombo.FormattingEnabled = true;
            this.numberCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.numberCombo.Location = new System.Drawing.Point(635, 432);
            this.numberCombo.Name = "numberCombo";
            this.numberCombo.Size = new System.Drawing.Size(36, 21);
            this.numberCombo.TabIndex = 3;
            this.numberCombo.Visible = false;
            // 
            // addRadio
            // 
            this.addRadio.BackColor = System.Drawing.SystemColors.Control;
            this.addRadio.Location = new System.Drawing.Point(677, 432);
            this.addRadio.Name = "addRadio";
            this.addRadio.Size = new System.Drawing.Size(22, 22);
            this.addRadio.TabIndex = 5;
            this.addRadio.Text = "+";
            this.addRadio.UseVisualStyleBackColor = false;
            this.addRadio.Visible = false;
            this.addRadio.Click += new System.EventHandler(this.addRadio_Click);
            // 
            // radioLabel
            // 
            this.radioLabel.AutoSize = true;
            this.radioLabel.Location = new System.Drawing.Point(541, 437);
            this.radioLabel.Name = "radioLabel";
            this.radioLabel.Size = new System.Drawing.Size(77, 13);
            this.radioLabel.TabIndex = 4;
            this.radioLabel.Text = "Select Number";
            this.radioLabel.Visible = false;
            // 
            // addCheckBox
            // 
            this.addCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.addCheckBox.Location = new System.Drawing.Point(677, 460);
            this.addCheckBox.Name = "addCheckBox";
            this.addCheckBox.Size = new System.Drawing.Size(22, 22);
            this.addCheckBox.TabIndex = 16;
            this.addCheckBox.Text = "+";
            this.addCheckBox.UseVisualStyleBackColor = false;
            this.addCheckBox.Visible = false;
            this.addCheckBox.Click += new System.EventHandler(this.addCheckBox_Click);
            // 
            // addCombo
            // 
            this.addCombo.BackColor = System.Drawing.SystemColors.Control;
            this.addCombo.Location = new System.Drawing.Point(677, 488);
            this.addCombo.Name = "addCombo";
            this.addCombo.Size = new System.Drawing.Size(22, 22);
            this.addCombo.TabIndex = 17;
            this.addCombo.Text = "+";
            this.addCombo.UseVisualStyleBackColor = false;
            this.addCombo.Visible = false;
            this.addCombo.Click += new System.EventHandler(this.addCombo_Click);
            // 
            // ComboDone
            // 
            this.ComboDone.BackColor = System.Drawing.SystemColors.Control;
            this.ComboDone.Location = new System.Drawing.Point(635, 516);
            this.ComboDone.Name = "ComboDone";
            this.ComboDone.Size = new System.Drawing.Size(64, 22);
            this.ComboDone.TabIndex = 18;
            this.ComboDone.Text = "Done";
            this.ComboDone.UseVisualStyleBackColor = false;
            this.ComboDone.Visible = false;
            this.ComboDone.Click += new System.EventHandler(this.ComboDone_Click);
            // 
            // ComboChange
            // 
            this.ComboChange.BackColor = System.Drawing.SystemColors.Control;
            this.ComboChange.Location = new System.Drawing.Point(635, 544);
            this.ComboChange.Name = "ComboChange";
            this.ComboChange.Size = new System.Drawing.Size(64, 22);
            this.ComboChange.TabIndex = 19;
            this.ComboChange.Text = "Change";
            this.ComboChange.UseVisualStyleBackColor = false;
            this.ComboChange.Visible = false;
            this.ComboChange.Click += new System.EventHandler(this.ComboChange_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // ButtonSplitter
            // 
            this.ButtonSplitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ButtonSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonSplitter.IsSplitterFixed = true;
            this.ButtonSplitter.Location = new System.Drawing.Point(0, 0);
            this.ButtonSplitter.Name = "ButtonSplitter";
            this.ButtonSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ButtonSplitter.Panel1
            // 
            this.ButtonSplitter.Panel1.Controls.Add(this.AddWorkflow);
            this.ButtonSplitter.Panel1.Controls.Add(this.SubmitButton);
            this.ButtonSplitter.Panel1.Controls.Add(this.CancelButton);
            // 
            // ButtonSplitter.Panel2
            // 
            this.ButtonSplitter.Panel2.AutoScroll = true;
            this.ButtonSplitter.Panel2.Controls.Add(this.Add1);
            this.ButtonSplitter.Panel2.Controls.Add(this.ComboDone);
            this.ButtonSplitter.Panel2.Controls.Add(this.ComboChange);
            this.ButtonSplitter.Panel2.Controls.Add(this.Title);
            this.ButtonSplitter.Panel2.Controls.Add(this.addRadio);
            this.ButtonSplitter.Panel2.Controls.Add(this.numberCombo);
            this.ButtonSplitter.Panel2.Controls.Add(this.radioLabel);
            this.ButtonSplitter.Panel2.Controls.Add(this.addCheckBox);
            this.ButtonSplitter.Panel2.Controls.Add(this.addCombo);
            this.ButtonSplitter.Panel2.Controls.Add(this.NewObjectContainer);
            this.ButtonSplitter.Size = new System.Drawing.Size(784, 619);
            this.ButtonSplitter.SplitterDistance = 43;
            this.ButtonSplitter.TabIndex = 20;
            // 
            // AddWorkflow
            // 
            this.AddWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddWorkflow.Location = new System.Drawing.Point(626, 8);
            this.AddWorkflow.Name = "AddWorkflow";
            this.AddWorkflow.Size = new System.Drawing.Size(125, 23);
            this.AddWorkflow.TabIndex = 2;
            this.AddWorkflow.Text = "Add Workflow";
            this.AddWorkflow.UseVisualStyleBackColor = true;
            this.AddWorkflow.Click += new System.EventHandler(this.AddWorkflow_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(8, 8);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 1;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(88, 8);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FormCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(25, 25);
            this.ClientSize = new System.Drawing.Size(784, 619);
            this.Controls.Add(this.ButtonSplitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCreator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCreator_Load);
            this.NewObjectContainer.ResumeLayout(false);
            this.ButtonSplitter.Panel1.ResumeLayout(false);
            this.ButtonSplitter.Panel2.ResumeLayout(false);
            this.ButtonSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSplitter)).EndInit();
            this.ButtonSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Button Add1;
        private System.Windows.Forms.ComboBox NewObjectCombo;
        private System.Windows.Forms.Panel NewObjectContainer;
        private System.Windows.Forms.ComboBox numberCombo;
        private System.Windows.Forms.Button addRadio;
        private System.Windows.Forms.Label radioLabel;
        private System.Windows.Forms.Button addCheckBox;
        private System.Windows.Forms.Button addCombo;
        private System.Windows.Forms.Button ComboDone;
        private System.Windows.Forms.Button ComboChange;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.SplitContainer ButtonSplitter;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AddWorkflow;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

