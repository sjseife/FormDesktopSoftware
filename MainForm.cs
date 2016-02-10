using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LoginForms
{
    public partial class MainForm : Form
    {
        public MySqlConnection Connection;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //string getUsers = "SELECT username FROM user_accounts";
            //string addUser = "INSERT INTO user_accounts (username, password, salt, f_name, l_name, address_street, address_number, address_city, address_state, address_zip, primary_phone) VALUES ('TestUser','password', 'salt', 'John', 'Smith', 'StreetName', '123', 'Johnson City', 'TN', '37614', '1234567890')";
            //string deleteUser = "DELETE FROM user_accounts WHERE username = 'TestUser'";

            const string serverName = "server=einstein.etsu.edu";
            const string databaseName = "database=schaum";
            const string username = "uid=schaum";
            const string password = "pwd=12345";

            Connection = new MySqlConnection(string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));

            try
            {
                Connection.Open();
                //MessageBox.Show("Connection Open!");

                //MySqlCommand add = new MySqlCommand(addUser, Connection);
                //add.ExecuteNonQuery();

                //MySqlCommand delete = new MySqlCommand(deleteUser, Connection);
                //delete.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Connection Error!");
                Environment.Exit(1);
            }

            LoginForm login = new LoginForm(this);
            login.MdiParent = this;
            login.Dock = DockStyle.Fill;
            login.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }

        public void ShowInfo(int userID)
        {
            InfoForm info = new InfoForm(this, userID);
            info.MdiParent = this;
            info.Dock = DockStyle.Fill;
            info.Show();
        }
    }
}
