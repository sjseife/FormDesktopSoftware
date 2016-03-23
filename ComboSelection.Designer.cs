namespace FormsProject
{
    partial class ComboSelection
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
            this.components = new System.ComponentModel.Container();
            this.textCollectionBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCombo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textCollectionBox
            // 
            this.textCollectionBox.Location = new System.Drawing.Point(52, 25);
            this.textCollectionBox.Multiline = true;
            this.textCollectionBox.Name = "textCollectionBox";
            this.textCollectionBox.Size = new System.Drawing.Size(360, 210);
            this.textCollectionBox.TabIndex = 0;
            this.textCollectionBox.Text = "(one selection per line)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // addCombo
            // 
            this.addCombo.BackColor = System.Drawing.SystemColors.Control;
            this.addCombo.Location = new System.Drawing.Point(434, 109);
            this.addCombo.Name = "addCombo";
            this.addCombo.Size = new System.Drawing.Size(22, 22);
            this.addCombo.TabIndex = 18;
            this.addCombo.Text = "+";
            this.addCombo.UseVisualStyleBackColor = false;
            this.addCombo.Click += new System.EventHandler(this.addCombo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter strings in collection (one per line)";
            // 
            // ComboSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 252);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addCombo);
            this.Controls.Add(this.textCollectionBox);
            this.Name = "ComboSelection";
            this.Text = "Dropdown Creation";
            this.Load += new System.EventHandler(this.ComboSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textCollectionBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button addCombo;
        private System.Windows.Forms.Label label1;
    }
}