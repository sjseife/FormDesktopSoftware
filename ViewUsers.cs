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

namespace LoginForms
{
    public partial class ViewUsers : Form
    {
        MainForm Parent;
        Dictionary<string, string> Users; // username, user_id

        public ViewUsers(MainForm parent)
        {
            Parent = parent;
            InitializeComponent();
        }

        private void UserList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.UserList.IndexFromPoint(e.Location);   // Determine index from clicked location
            if (index != System.Windows.Forms.ListBox.NoMatches)    // If it exists, open the EditInfo form
            {
                int userID = int.Parse(Users.Values.ToArray()[index]);
                Parent.EditInfo(Parent.TempForm, userID, false);
                this.Close();
            }
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            Users = new Dictionary<string, string>();

            string getUsers = "SELECT username, user_id FROM user_accounts";
            MySqlCommand command = new MySqlCommand(getUsers, Parent.Connection);
            using (MySqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Users.Add(rdr[0].ToString(), rdr[1].ToString());
                }
                rdr.Close();
            }

            UserList.Items.AddRange(Users.Keys.ToArray<string>());

            UserList.SelectedIndex = 0;
        }
    }
}
