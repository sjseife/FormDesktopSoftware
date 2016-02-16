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
        public MySqlConnection Connection;  // Connection to MySQL Server
        private LoginForm Login;            // Login form
        private AdminForm Admin;            // Admin form
        public Form TempForm;               // Temporary Storage form to hold hidden forms

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
            }
            catch
            {
                MessageBox.Show("Connection Error!");
                Environment.Exit(1);
            }

            Login = new LoginForm(this);
            Login.MdiParent = this;
            Login.Dock = DockStyle.Fill;
            Login.Show();
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

        public void LogIn(int userID)
        {
            Login.Close();

            string getUserInfo = "SELECT username, (user_level + 0) FROM user_accounts WHERE user_id = " + userID; // The (user_level + 0) part is to ensure that user_level is processed as an int, instead of the default (boolean)
            string username = string.Empty;
            int userLevel = 0;

            MySqlCommand command = new MySqlCommand(getUserInfo, Connection);

            using (MySqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    username = rdr[0].ToString();
                    userLevel = Convert.ToInt32(rdr[1]);
                }
                rdr.Close();
            }

            if (userLevel == 0)
            {
                // ADD USER INTERFACE CODE HERE
            }
            else if (userLevel > 0)
            {
                Admin = new AdminForm(this, userID, username, userLevel);
                Admin.MdiParent = this;
                Admin.Dock = DockStyle.Fill;
                Admin.Show();
            }
            else
            {
                MessageBox.Show("UserLevel Error!");
                Environment.Exit(1);
            }
        }

        public void LogOut()
        {
            if (Admin != null)
            {
                Admin.Close();
            }
            //else if (User != null)
            //{
            //    User.Close(); // Example code once User Interface is implemented
            //}

            Login = new LoginForm(this);
            Login.MdiParent = this;
            Login.Dock = DockStyle.Fill;
            Login.Show();
        }

        public void EditInfo(Form hide, int userID, bool createNew)
        {
            TempForm = hide; // Save currently open form, then show info edit/add form

            InfoEditForm editMyInfo = new InfoEditForm(this, userID, createNew);
            editMyInfo.MdiParent = this;
            editMyInfo.Dock = DockStyle.Fill;
            hide.Visible = false;
            editMyInfo.Show();
        }

        public void ExitInfo()
        {
            TempForm.Visible = true;
            RedrawForm();
        }

        public void GetUsers(Form hide)
        {
            TempForm = hide; // Save currently open form, then show user selection form

            ViewUsers viewUsers = new ViewUsers(this);
            viewUsers.MdiParent = this;
            viewUsers.Dock = DockStyle.Fill;
            hide.Visible = false;
            viewUsers.Show();
        }

        public void RedrawForm()
        {
            // Changing the form size seems to be the only way to redraw it. I tried EVERYTHING before this finally worked
            this.Size = new System.Drawing.Size(this.Size.Width + 1, this.Size.Height);
            this.Size = new System.Drawing.Size(this.Size.Width - 1, this.Size.Height);
        }
    }
}
