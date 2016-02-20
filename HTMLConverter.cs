﻿using System;
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

namespace AdminFormCreationInterface
{
    class HTMLConverter
    {
        private string top = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset = 'utf-8'>\n";
        private string title;
        private string action = "<form action=\"action_page.php\" method=\"post\">\n";
        private string formBody;
        private string fieldset = "<fieldset style=\"display:inline-block\">\n";
        private Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        private string bottom = "<input type=\"submit\" value=\"Submit\">\n<input type = \"reset\" value=\"Reset!\">\n</form>\n</body>\n</html>";

        public void setTitle(string input)
        {
            title = input;
            top += String.Format("<title> {0} </title>\n</head>\n<body>\n<h1>\n{0}\n</h1>\n", input);
        }//setTitle(string)

        public void createTextBox(string input)
        {
            string formattedInput = formatString(input);
            string output = String.Format("{0}<br>\n<input type=\"text\" name=\"{1}\"><br><br>\n", input, formattedInput);
            formBody += output;
        }//createTextBox(string)

        public void createPassword(string input)
        {
            string formattedInput = formatString(input);
            string output = String.Format("{0}<br>\n<input type=\"password\" name=\"{1}\"><br><br>\n", input, formattedInput);
            formBody += output;
        }//createTextBox(string)

        public void createRadio(string titleIn, string[] radioIn)
        {
            string output = fieldset;
            string loop;
            string group = String.Format("<legend>{0}</legend>\n", titleIn);
            string formattedTitle = formatString(titleIn);

            output += group;

            loop = String.Format("<input type=\"radio\" name=\"{0}\" value=\"{1}\" checked> {2}\n", formattedTitle, formatString(radioIn[0]), radioIn[0]); //makes first choice selected 
            output += loop;

            foreach (string i in radioIn.Skip(1))
            {
                loop = String.Format("<input type=\"radio\" name=\"{0}\" value=\"{1}\"> {2}\n", formattedTitle, formatString(i), i);
                output += loop;
            }
            output += "</fieldset>\n<br><br>\n";
            formBody += output;

        }//createRadio(string,string)

        public void createCheckBox(string titleIn, string[] checkBoxIn)
        {
            string output = fieldset;
            string loop;
            string group = String.Format("<legend>{0}</legend>\n", titleIn);
            string formattedTitle = formatString(titleIn);

            output += group;

            foreach (string i in checkBoxIn)
            {
                loop = String.Format("<input type=\"checkbox\" name=\"{0}\" value=\"{1}\"> {2}\n", formattedTitle, formatString(i), i);
                output += loop;
            }
            output += "</fieldset>\n<br><br>\n";
            formBody += output;

        }//createRadio(string,string)

        public void createListBox(List<string> listIn)
        {
            string loop = "<select name=\"list\">\n";

            foreach(string i in listIn)
            {
                loop += String.Format("<option value=\"{0}\">{1}</option>\n", formatString(i), i);
            }

            loop += "</select>\n<br><br>\n";
            formBody += loop;
        }//createListBox(string)

        private string formatString(string input)
        {
            string output = rgx.Replace(input, "");
            output = output.Replace(" ", String.Empty);
            output = char.ToLower(output[0]) + output.Substring(1);
            return output;
        }//formatString(string)

        public void save()
        {
            string output = top + action + formBody + bottom;
            string fileName = String.Format("{0}.htm", formatString(title));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) //combine into html
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(output);
                }
            }

            MessageBox.Show("Form has been successfully saved!");
        }//save()

        public void send()
        {
            string output = top + action + formBody + bottom;
            string fileName = String.Format("{0}.htm", formatString(title));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) //combine into html
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(output);
                }
            }
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();
            DateTime date = DateTime.Now;
            string newdate = date.ToString("yyyy-MM-dd");
            string SQL;
            int FileSize;
            byte[] rawData;
            FileStream fs1;
            string serverName = "server=einstein.etsu.edu";
            string databaseName = "database=schaum";
            string username = "uid=schaum";
            string password = "pwd=12345";

                conn.ConnectionString = (string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));
            // MySqlCommand cmd = new MySqlCommand(
            //  "SELECT form_id, form_file FROM form_template", conn);

            // Writes the BLOB to a file (*.bmp).
            try
            {
                fs1 = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                FileSize = (int)fs1.Length;

                rawData = new byte[FileSize];
                fs1.Read(rawData, 0, FileSize);
                fs1.Close();

                conn.Open();

                SQL = String.Format("INSERT INTO form_template(form_name, form_file, form_creation_date) VALUES(@form_name, @form_file, @form_creation_date)");
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@form_name", formatString(title));
               // cmd.Parameters.AddWithValue("@FileSize", FileSize);
                cmd.Parameters.AddWithValue("@form_file", rawData);
                cmd.Parameters.AddWithValue("@form_creation_date", newdate);

                cmd.ExecuteNonQuery();

                MessageBox.Show("File Inserted into database successfully!",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
