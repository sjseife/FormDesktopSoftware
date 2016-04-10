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
    public partial class LoginForm : Form
    {
        MainForm Parent;

        public LoginForm(MainForm parentForm)
        {
            Parent = parentForm;
            InitializeComponent();
            this.BackColor = System.Drawing.Color.White;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string user = UsernameTextbox.Text;
            string pass = PasswordTextbox.Text;

            string hashpass = GetUserHash(user, pass);

            string validateUser = "SELECT user_id FROM user_accounts WHERE BINARY username = '" + user + "' AND BINARY password = '" + hashpass + "'";

            MySqlCommand command = new MySqlCommand(validateUser, Parent.Connection);

            int value = Convert.ToInt32(command.ExecuteScalar());

            if (value != 0)
            {
                int userId;
                using (MySqlDataReader rdr = command.ExecuteReader())
                {
                    rdr.Read();
                    userId = int.Parse(rdr.GetString(0));
                    rdr.Close();
                }

                this.Hide();
                Parent.LogIn(userId);
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }

        private string GetUserHash(string username, string password)
        {
            string saltString = string.Empty;

            string getSalt = "SELECT salt FROM user_accounts WHERE BINARY username = '" + username + "'";
            MySqlCommand command = new MySqlCommand(getSalt, Parent.Connection);
            using (MySqlDataReader rdr = command.ExecuteReader())
            {
                rdr.Read();
                saltString = rdr.GetString(0);
                rdr.Close();
            }

            return Parent.HashPasswordAndSalt(password, saltString);
        }

        private void UsernameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // If Enter key, attempt login
            {
                LoginButton_Click(null, null);
            }
        }

        private void PasswordTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // If Enter key, attempt login
            {
                LoginButton_Click(null, null);
            }
        }
    }
}
