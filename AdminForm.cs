using AdminFormCreationInterface;
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
    public partial class AdminForm : Form
    {
        MainForm Parent;    // Main form
        int UserID;
        string Username;
        int UserLevel;

        public AdminForm(MainForm parent, int userID, string username, int userLevel)
        {
            Parent = parent;
            UserID = userID;
            Username = username;
            UserLevel = userLevel;
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text = "Logged in as " + Username;

            if (UserLevel < 2) // Hide these if not superadmin
            {
                EditUserInfoButton.Visible = false;
                AddUserButton.Visible = false;
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Parent.LogOut();
        }

        public void ResetForm()
        {
            InitializeComponent();
        }

        private void EditUserInfoButton_Click(object sender, EventArgs e)
        {
            Parent.GetUsers(this);
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            Parent.EditInfo(this, 0, true);
        }

        private void CreateFormButton_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            //this.Close();
        }

        public static void ThreadProc()
        {
           // launch form creator
            Application.Run(new FormCreator());
        }
    }
    
}
