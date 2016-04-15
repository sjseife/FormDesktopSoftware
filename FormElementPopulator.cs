using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace FormsProject
{
    class FormElementPopulator
    {
        private Regex rgx = new Regex("[^a-zA-Z0-9 -]");

        List<string> element_type;  // List that will hold the element_type field
        List<string> element_text;  // List that will hold the element text of each corresponding element type

        public FormElementPopulator()
        {
            element_type = new List<string>();
            element_text = new List<string>();
        }

        // All element_type functions
        public void textBox_type()
        {
            element_type.Add("text");
        }

        public void password_type()
        {
            element_type.Add("password");
        }

        public void dropdown_type()
        {
            element_type.Add("dropdown");
        }

        public void radio_type()
        {
            element_type.Add("radio");
        }

        public void check_type()
        {
            element_type.Add("check");
        }

        public void multiLineText_type()
        {
            element_type.Add("multiLineText");
        }

        public void radio_text(string[] radioIn, string label)
        {
            string output = label + ",";
            output += string.Join(",", radioIn);
            element_text.Add(output);
        }

        public void dropdown_text(List<string> listIn, string label)
        {
            string output = label + ",";
            output += string.Join(",", listIn.ToArray());
            element_text.Add(output);
        }

        public void checkBox_text(string[] checkBoxIn, string label)
        {
            string output = label + ",";
            output += string.Join(",", checkBoxIn);
            element_text.Add(output);
        }

        public void textBox_text(string input)
        {
            element_text.Add(input);
        }

        public void password_text(string input)
        {
            element_text.Add(input);
        }

        public void mulitiLineText_text(string input)
        {
            element_text.Add(input);
        }

        public void send(string form_id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(); ;
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();

            string serverName = "server=einstein.etsu.edu";
            string databaseName = "database=schaum";
            string username = "uid=schaum";
            string password = "pwd=12345";

            conn.ConnectionString = (string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));

            try
            {
                conn.Open();
                cmd.Connection = conn;

                for (int i = 0; i < element_type.Count; i++)
                {
                    cmd.CommandText = "INSERT INTO form_element(form_id, element_type, element_text) VALUES(@form_id, @element_type, @element_text);";
                    cmd.Parameters.AddWithValue("@element_type", element_type[i]);
                    cmd.Parameters.AddWithValue("@element_text", element_text[i]);
                    cmd.Parameters.AddWithValue("@form_id", form_id);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//send()
    }
}
