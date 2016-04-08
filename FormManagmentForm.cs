using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsProject
{
    public partial class FormManagmentForm : Form
    {
        MainForm Parent;
        List<string> FormNames;

        public FormManagmentForm(MainForm parent)
        {
            Parent = parent;
            InitializeComponent();
        }

        private void FormManagmentForm_Load(object sender, EventArgs e)
        {
            Parent.StopDrawing();

            FormNames = new List<string>();

            string getForms = "SELECT form_name FROM form_template";
            MySqlCommand command = new MySqlCommand(getForms, Parent.Connection);
            using (MySqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    FormNames.Add(rdr[0].ToString());
                }
                rdr.Close();
            }

            for (int i = 0; i < FormNames.Count; i++)
            {
                Label formname = new Label();
                formname.Text = FormNames[i];
                formname.Font = new Font(formname.Font.FontFamily, 12);
                formname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                formname.AutoSize = true;

                Button deletebutton = new Button();
                deletebutton.Text = "Delete";
                deletebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                deletebutton.UseVisualStyleBackColor = true;
                deletebutton.Click += Delete_Click;

                FlowLayoutPanel temp = new FlowLayoutPanel();
                temp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                temp.AutoSize = true;
                temp.Controls.Add(deletebutton);

                FormTable.RowCount = FormTable.RowCount + 1;
                FormTable.Controls.Add(formname, 0, FormTable.RowCount - 1);
                FormTable.Controls.Add(temp, 1, FormTable.RowCount - 1);
            }

            Parent.ResumeDrawing();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            TableLayoutPanelCellPosition position = FormTable.GetPositionFromControl((sender as Control).Parent);
            int row = position.Row;
            string formname = FormTable.GetControlFromPosition(0, row).Text;

            DeleteForm(formname, row);
        }

        private void DeleteForm(string formname, int rowIndex)
        {
            string deleteForm = "DELETE FROM form_template WHERE form_name = '" + formname + "'";
            MySqlCommand cmd = new MySqlCommand(deleteForm, Parent.Connection);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted " + formname + " from database");
            remove_row(FormTable, rowIndex);
        }

        public void RefreshTable()
        {
            Parent.StopDrawing();
            int count = FormTable.RowCount - 2;

            for (int i = 0; i < count; i++)
            {
                remove_row(FormTable, 2);
            }
            Parent.ResumeDrawing();

            FormManagmentForm_Load(null, null);
        }

        public void remove_row(TableLayoutPanel panel, int row_index_to_remove)
        {
            if (row_index_to_remove >= panel.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, row_index_to_remove);
                panel.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = row_index_to_remove + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    var control = panel.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        panel.SetRow(control, i - 1);
                    }
                }
            }

            // remove last row
            panel.RowCount--;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormManagmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parent.ExitFormManagement();
        }

        private void CreateFormButton_Click(object sender, EventArgs e)
        {
            Parent.CreateForm(this);
        }
    }
}
