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
    public partial class LoginForm : Form
    {
        MainForm Parent;

        public LoginForm(MainForm parentForm)
        {
            Parent = parentForm;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string user = UsernameTextbox.Text;
            string pass = PasswordTextbox.Text;

            string validateUser = "SELECT user_id FROM user_accounts WHERE username = '" + user + "' AND password = '" + pass + "'";

            MySqlCommand command = new MySqlCommand(validateUser, Parent.Connection);

            int value = Convert.ToInt32(command.ExecuteScalar());

            if (value != 0)
            {
                MySqlDataReader rdr = command.ExecuteReader();
                rdr.Read();
                int userId = int.Parse(rdr.GetString(0));
                rdr.Close();

                this.Hide();
                Parent.ShowInfo(userId);
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }
    }
}
