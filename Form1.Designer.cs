namespace AdminFormCreationInterface
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.submitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Add1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numberCombo = new System.Windows.Forms.ComboBox();
            this.addRadio = new System.Windows.Forms.Button();
            this.radioLabel = new System.Windows.Forms.Label();
            this.addCheckBox = new System.Windows.Forms.Button();
            this.addCombo = new System.Windows.Forms.Button();
            this.ComboDone = new System.Windows.Forms.Button();
            this.ComboChange = new System.Windows.Forms.Button();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AcceptsReturn = true;
            this.Title.Location = new System.Drawing.Point(283, 27);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(200, 20);
            this.Title.TabIndex = 0;
            this.Title.Tag = "Title";
            this.Title.Text = "Insert Title Here";
            this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.submitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // submitToolStripMenuItem
            // 
            this.submitToolStripMenuItem.Name = "submitToolStripMenuItem";
            this.submitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.submitToolStripMenuItem.Text = "Submit";
            this.submitToolStripMenuItem.Click += new System.EventHandler(this.submitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.navigateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // navigateToolStripMenuItem
            // 
            this.navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formSelectionToolStripMenuItem,
            this.formCreationToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1});
            this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            this.navigateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.navigateToolStripMenuItem.Text = "Navigate";
            // 
            // formSelectionToolStripMenuItem
            // 
            this.formSelectionToolStripMenuItem.Name = "formSelectionToolStripMenuItem";
            this.formSelectionToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.formSelectionToolStripMenuItem.Text = "Form Selection";
            // 
            // formCreationToolStripMenuItem
            // 
            this.formCreationToolStripMenuItem.Name = "formCreationToolStripMenuItem";
            this.formCreationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.formCreationToolStripMenuItem.Text = "Form Creation";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem1.Text = "Administration";
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Select Form Object to Add",
            "Add Username",
            "Add Password",
            "Add Text Box",
            "Add List Box",
            "Add Radio Buttons",
            "Add Checkboxes"});
            this.comboBox1.Location = new System.Drawing.Point(21, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(263, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Select Form Object to Add";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(221, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 66);
            this.panel1.TabIndex = 1;
            // 
            // numberCombo
            // 
            this.numberCombo.FormattingEnabled = true;
            this.numberCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.numberCombo.Location = new System.Drawing.Point(635, 453);
            this.numberCombo.Name = "numberCombo";
            this.numberCombo.Size = new System.Drawing.Size(36, 21);
            this.numberCombo.TabIndex = 3;
            this.numberCombo.Visible = false;
            // 
            // addRadio
            // 
            this.addRadio.BackColor = System.Drawing.SystemColors.Control;
            this.addRadio.Location = new System.Drawing.Point(677, 453);
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
            this.radioLabel.Location = new System.Drawing.Point(541, 458);
            this.radioLabel.Name = "radioLabel";
            this.radioLabel.Size = new System.Drawing.Size(77, 13);
            this.radioLabel.TabIndex = 4;
            this.radioLabel.Text = "Select Number";
            this.radioLabel.Visible = false;
            // 
            // addCheckBox
            // 
            this.addCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.addCheckBox.Location = new System.Drawing.Point(677, 481);
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
            this.addCombo.Location = new System.Drawing.Point(677, 509);
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
            this.ComboDone.Location = new System.Drawing.Point(635, 537);
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
            this.ComboChange.Location = new System.Drawing.Point(635, 565);
            this.ComboChange.Name = "ComboChange";
            this.ComboChange.Size = new System.Drawing.Size(64, 22);
            this.ComboChange.TabIndex = 19;
            this.ComboChange.Text = "Change";
            this.ComboChange.UseVisualStyleBackColor = false;
            this.ComboChange.Visible = false;
            this.ComboChange.Click += new System.EventHandler(this.ComboChange_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // FormCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(25, 25);
            this.ClientSize = new System.Drawing.Size(784, 619);
            this.Controls.Add(this.ComboChange);
            this.Controls.Add(this.ComboDone);
            this.Controls.Add(this.addCombo);
            this.Controls.Add(this.addCheckBox);
            this.Controls.Add(this.radioLabel);
            this.Controls.Add(this.numberCombo);
            this.Controls.Add(this.addRadio);
            this.Controls.Add(this.Add1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormCreator";
            this.Text = "Form Creation";
            this.Load += new System.EventHandler(this.FormCreator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem submitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button Add1;
        private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem formCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox numberCombo;
        private System.Windows.Forms.Button addRadio;
        private System.Windows.Forms.Label radioLabel;
        private System.Windows.Forms.Button addCheckBox;
        private System.Windows.Forms.Button addCombo;
        private System.Windows.Forms.Button ComboDone;
        private System.Windows.Forms.Button ComboChange;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

