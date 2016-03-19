using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FormsProject
{
    public partial class InfoEditForm : Form
    {
        MainForm Parent;
        int UserID;
        bool NewUser;
        

        public InfoEditForm(MainForm parent, int userID, bool createNew)
        {
            Parent = parent;
            UserID = userID;
            NewUser = createNew;
            InitializeComponent();
            this.BackColor = System.Drawing.Color.White;
        }

        private void InfoEditForm_Load(object sender, EventArgs e)
        {
            if (NewUser) // Creating a new user
            {
                SaveButton.Text = "Create User";
            }
            else
            {
                // Editing an existing user, fill in saved info

                UsernameTextbox.Enabled = false;
                PasswordTextBox.Enabled = false;
                PasswordTextBox.Text = "00000000000";

                string getUserInfo = "SELECT username, email, f_name, l_name, address_street, address_number, address_city, address_state, address_zip, primary_phone, user_title, (user_level + 0) FROM user_accounts WHERE user_id = " + UserID;

                MySqlCommand command = new MySqlCommand(getUserInfo, Parent.Connection);
                using (MySqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        UsernameTextbox.Text = rdr[0].ToString();
                        EmailTextbox.Text = rdr[1].ToString();
                        FNameTextbox.Text = rdr[2].ToString();
                        LNameTextbox.Text = rdr[3].ToString();
                        StreetNameTextbox.Text = rdr[4].ToString();
                        StreetNumberTextbox.Text = rdr[5].ToString();
                        CityTextbox.Text = rdr[6].ToString();
                        StateTextbox.Text = rdr[7].ToString();
                        ZipTextbox.Text = rdr[8].ToString();

                        string phone = rdr[9].ToString();
                        string[] phoneSections = phone.Split('-');
                        PhoneAreaTextbox.Text = phoneSections[0];
                        PhoneFirst3Textbox.Text = phoneSections[1];
                        PhoneLast4Textbox.Text = phoneSections[2];

                        TitleTextbox.Text = rdr[10].ToString();
                        LevelDropdown.SelectedIndex = Convert.ToInt32(rdr[11]);
                    }
                    rdr.Close();
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string checkExistingUser = "SELECT COUNT(username) FROM user_accounts WHERE username = '" + UsernameTextbox.Text + "'";
            string createUserWithTitle = string.Format("INSERT INTO user_accounts (username, password, f_name, l_name, address_street, address_number, address_city, address_state, address_zip, primary_phone, user_title, user_level, email) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11}, '{12}')", UsernameTextbox.Text, PasswordTextBox.Text, FNameTextbox.Text, LNameTextbox.Text, StreetNameTextbox.Text, StreetNumberTextbox.Text, CityTextbox.Text, StateTextbox.Text, ZipTextbox.Text, PhoneAreaTextbox.Text + "-" + PhoneFirst3Textbox.Text + "-" + PhoneLast4Textbox.Text, TitleTextbox.Text, LevelDropdown.SelectedIndex, EmailTextbox.Text);
            string createUserWithoutTitle = string.Format("INSERT INTO user_accounts (username, password, f_name, l_name, address_street, address_number, address_city, address_state, address_zip, primary_phone, user_level, email) VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', {10}, '{11}')", UsernameTextbox.Text, PasswordTextBox.Text, FNameTextbox.Text, LNameTextbox.Text, StreetNameTextbox.Text, StreetNumberTextbox.Text, CityTextbox.Text, StateTextbox.Text, ZipTextbox.Text, PhoneAreaTextbox.Text + "-" + PhoneFirst3Textbox.Text + "-" + PhoneLast4Textbox.Text, LevelDropdown.SelectedIndex, EmailTextbox.Text);
            string updateUser = string.Format("UPDATE user_accounts SET f_name = '{0}', l_name = '{1}', address_street = '{2}', address_number = '{3}', address_city = '{4}', address_state = '{5}', address_zip = '{6}', primary_phone = '{7}', user_title = '{8}', user_level = {9}, email = '{10}' WHERE user_id = {11}", FNameTextbox.Text, LNameTextbox.Text, StreetNameTextbox.Text, StreetNumberTextbox.Text, CityTextbox.Text, StateTextbox.Text, ZipTextbox.Text, PhoneAreaTextbox.Text + "-" + PhoneFirst3Textbox.Text + "-" + PhoneLast4Textbox.Text, TitleTextbox.Text, LevelDropdown.SelectedIndex, EmailTextbox.Text, UserID);
            
            if (NewUser)
            {
                MySqlCommand checkExists = new MySqlCommand(checkExistingUser, Parent.Connection);

                object test = checkExists.ExecuteScalar();
                int value = Convert.ToInt32(test);

                if (value == 0) // Username does not already exist
                {
                    MySqlCommand addUser;
                    if (TitleTextbox.Text != string.Empty)
                    {
                        addUser = new MySqlCommand(createUserWithTitle, Parent.Connection);
                    }
                    else
                    {
                        addUser = new MySqlCommand(createUserWithoutTitle, Parent.Connection);
                    }
                    addUser.ExecuteNonQuery();

                    this.Parent.Visible = true;
                    this.Close();
                }
                else
                {
                    UsernameError.Visible = true;
                }
            }
            else
            {
                MySqlCommand update = new MySqlCommand(updateUser, Parent.Connection);
                update.ExecuteNonQuery();

                Parent.ExitInfo();
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parent.ExitInfo();
        }

        private void PhoneAreaTextbox_KeyPress(object sender, KeyPressEventArgs e) // These three methods make it so only numbers can be entered
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PhoneFirst3Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PhoneLast4Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void InfoEditForm_Shown(object sender, EventArgs e)
        {
            Parent.RedrawForm();
        }
    }
}
