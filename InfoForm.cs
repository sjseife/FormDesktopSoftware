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
    public partial class InfoForm : Form
    {
        MainForm Parent;
        int UserID;

        public InfoForm(MainForm parent, int userID)
        {
            Parent = parent;
            UserID = userID;
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            string validateUser = "SELECT user_id, username, f_name, l_name, address_number, address_street, address_city, address_state, address_zip, primary_phone FROM user_accounts WHERE user_id = " + UserID;

            MySqlCommand command = new MySqlCommand(validateUser, Parent.Connection);
            MySqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                UserInfoTextBox.Text = String.Format("User ID: {0}\r\n" + 
                                                     "Username: {1}\r\n" + 
                                                     "Name: {2} {3}\r\n" + 
                                                     "Address: {4} {5}, {6}, {7} {8}\r\n" + 
                                                     "Phone: {9}", rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
            }
            rdr.Close();
        }
    }
}
