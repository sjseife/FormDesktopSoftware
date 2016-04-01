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
    public partial class UserForm : Form
    {
        MainForm Parent;    // Main form
        int UserID;
        string Username;
        bool NewFormCollapsed;
        bool SavedFormCollapsed;

        public UserForm(MainForm parent, int userID, string username)
        {
            Parent = parent;
            UserID = userID;
            Username = username;
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text = "Logged in as " + Username;
            NewFormCollapsed = false;
            SavedFormCollapsed = false;

            List<string> savedForms = new List<string>();
            List<string> newForms = new List<string>();

            string getNewForms = "SELECT form_name FROM form_template";
            
            MySqlCommand command = new MySqlCommand(getNewForms, Parent.Connection);

            using (MySqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    newForms.Add(rdr[0].ToString());
                }
                rdr.Close();
            }

            for (int i = 0; i < newForms.Count; i++)
            {
                GroupBox group = new GroupBox();
                group.Text = string.Empty;
                group.AutoSize = true;
                group.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

                Label formName = new Label();
                formName.Text = newForms[i];
                formName.Font = new System.Drawing.Font(formName.Font.FontFamily, 15);
                formName.AutoSize = true;
                //formName.Dock = DockStyle.Left;

                group.Controls.Add(formName);
                formName.Location = new Point(formName.Location.X + 10, formName.Location.Y + 10);

                Button button = new Button();
                button.Text = "Create Form";
                group.Controls.Add(button);
                button.Location = new Point(button.Location.X + 250, button.Location.Y + 10);
                button.Click += button_Click;
                //button.Dock = DockStyle.Top;

                NewFormContainer.Controls.Add(group);
            }

            NewFormsLabel.Text = "New Forms: " + newForms.Count;
        }

        void button_Click(object sender, EventArgs e)
        {
            NewForm((sender as Button).Parent.Controls[0].Text);
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

        private void CollapseSavedFormsButton_Click(object sender, EventArgs e)
        {
            if (SavedFormCollapsed)
            {
                SavedFormCollapsed = false;
                CollapseSavedFormsButton.Text = "Λ";
                FormTypeSeperator.RowStyles[3].SizeType = SizeType.AutoSize;
            }
            else
            {
                SavedFormCollapsed = true;
                CollapseSavedFormsButton.Text = "V";
                FormTypeSeperator.RowStyles[3].SizeType = SizeType.Absolute;
                FormTypeSeperator.RowStyles[3].Height = 0;
            }
        }

        private void CollapseNewFormsButton_Click(object sender, EventArgs e)
        {
            if (NewFormCollapsed)
            {
                NewFormCollapsed = false;
                CollapseNewFormsButton.Text = "Λ";
                FormTypeSeperator.RowStyles[1].SizeType = SizeType.AutoSize;
            }
            else
            {
                NewFormCollapsed = true;
                CollapseNewFormsButton.Text = "V";
                FormTypeSeperator.RowStyles[1].SizeType = SizeType.Absolute;
                FormTypeSeperator.RowStyles[1].Height = 0;
            }
        }

        private void NewForm(string formName)
        {
            //Parent.NewForm(this, formName, UserID);
        }
    }
}
