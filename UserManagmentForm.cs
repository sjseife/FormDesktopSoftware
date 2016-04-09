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
    public partial class UserManagmentForm : Form
    {
        MainForm Parent;
        List<string> UserNames;
        List<int> UserIDs;

        public UserManagmentForm(MainForm parent)
        {
            Parent = parent;
            InitializeComponent();
        }

        private void UserManagmentForm_Load(object sender, EventArgs e)
        {
            Parent.StopDrawing();

            UserNames = new List<string>();
            UserIDs = new List<int>();

            string getUsers = "SELECT username, user_id FROM user_accounts";
            MySqlCommand command = new MySqlCommand(getUsers, Parent.Connection);
            using (MySqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    UserNames.Add(rdr[0].ToString());
                    UserIDs.Add(int.Parse(rdr[1].ToString()));
                }
                rdr.Close();
            }

            for (int i = 0; i < UserNames.Count; i++)
            {
                Label username = new Label();
                username.Text = UserNames[i];
                username.Font = new Font(username.Font.FontFamily, 12);
                username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                username.AutoSize = true;

                Button editbutton = new Button();
                editbutton.Text = "Edit";
                editbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                editbutton.UseVisualStyleBackColor = true;
                editbutton.Click += Edit_Click;

                Button deletebutton = new Button();
                deletebutton.Text = "Delete";
                deletebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                deletebutton.UseVisualStyleBackColor = true;
                deletebutton.Click += Delete_Click;

                FlowLayoutPanel temp = new FlowLayoutPanel();
                temp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                temp.AutoSize = true;
                temp.Controls.Add(editbutton);
                temp.Controls.Add(deletebutton);

                UserTable.RowCount = UserTable.RowCount + 1;
                UserTable.Controls.Add(username, 0, UserTable.RowCount - 1);
                UserTable.Controls.Add(temp, 1, UserTable.RowCount - 1);
            }

            Parent.ResumeDrawing();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            TableLayoutPanelCellPosition position = UserTable.GetPositionFromControl((sender as Control).Parent);
            int row = position.Row;
            string username = UserTable.GetControlFromPosition(0, row).Text;

            int index = UserNames.IndexOf(username);
            EditUser(UserIDs[index]);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            TableLayoutPanelCellPosition position = UserTable.GetPositionFromControl((sender as Control).Parent);
            int row = position.Row;
            string username = UserTable.GetControlFromPosition(0, row).Text;

            DeleteUser(username, row);
        }

        private void EditUser(int userID)
        {
            Parent.EditInfo(this, userID, false);
        }

        private void DeleteUser(string username, int rowIndex)
        {
            string deleteUser = "DELETE FROM user_accounts WHERE username = '" + username + "'";
            MySqlCommand cmd = new MySqlCommand(deleteUser, Parent.Connection);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted " + username + " from database");
            remove_row(UserTable, rowIndex);
        }

        public void RefreshTable()
        {
            Parent.StopDrawing();
            int count = UserTable.RowCount - 2;

            for (int i = 0; i < count; i++)
            {
                remove_row(UserTable, 2);
            }
            Parent.ResumeDrawing();

            UserManagmentForm_Load(null, null);
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

        private void UserManagmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parent.ExitUserManagement();
        }

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            Parent.EditInfo(this, 0, true);
        }
    }
}
