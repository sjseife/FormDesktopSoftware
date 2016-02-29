using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsProject
{
    public partial class FormViewer : Form
    {
        private delegate void BeforeNavigate2(object pDisp, ref string url, ref int Flags, ref string TargetFrameName, ref byte[] PostData, ref string Headers, ref bool Cancel);

        MainForm Parent;
        string FormName;
        bool ContinueSaved;
        int UserID;
        int FormID;
        bool ready; // When HTMLViewer.DocumentText changes, the Navigating event is fired twice. This variable keeps requests from repeating. Set to false before you do something.

        public FormViewer(MainForm parent, string formname, bool cont, int user)
        {
            Parent = parent;
            FormName = formname;
            ContinueSaved = cont;
            UserID = user;
            InitializeComponent();
        }

        private void FormViewer_Load(object sender, EventArgs e)
        {
            string getFormData = "SELECT form_id, form_file FROM form_template WHERE form_name = '" + FormName + "'";
            MySqlCommand cmd = new MySqlCommand(getFormData, Parent.Connection);
            string HTML = string.Empty;

            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    FormID = Convert.ToInt32(rdr[0].ToString());
                    object data = rdr[1];
                    HTML = Encoding.UTF8.GetString((byte[])data);
                }
                rdr.Close();
            }
            
            HTMLViewer.DocumentText = HTML;
            ready = false;
        }

        private void HTMLViewer_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            dynamic d = HTMLViewer.ActiveXInstance;

            d.BeforeNavigate2 += new BeforeNavigate2((object pDisp, ref string url, ref int Flags, ref string TargetFrameName, ref byte[] PostData, ref string Headers, ref bool Cancel) =>
            {
                string post = string.Empty;
                if (PostData != null)
                {
                    post = Encoding.ASCII.GetString(PostData).Trim('\0');
                }

                if (url == "about:submit_form")
                {
                    if (ready)
                    {
                        ready = false;

                        string[] data = post.Split('&');

                        if (data[data.Length - 1] == "cancel=Cancel")
                        {
                            Parent.ExitInfo();
                            this.Close();
                        }
                        else if (data[data.Length - 1] == "save=Save")
                        {
                            // Add form not complete
                            Parent.ExitInfo();
                            this.Close();
                        }
                        else
                        {
                            if (ValidateForm(post))
                            {
                                string submission = string.Empty;

                                for (int i = 0; i < data.Length - 2; i++)
                                {
                                    submission += data[i] + "&";
                                }
                                submission += data[data.Length - 2];

                                string insertForm = "INSERT INTO user_forms (user_id, form_id, filled_form_file, incomplete, date_of_completion, authorization_complete) VALUES ({0}, {1}, ?formData, 0, '{2}', 1)";

                                DateTime date = DateTime.Now;
                                string newdate = date.ToString("yyyy-MM-dd");
                                insertForm = string.Format(insertForm, UserID, FormID, newdate);

                                MySqlCommand cmd = new MySqlCommand(insertForm, Parent.Connection);

                                byte[] dataBytes = Encoding.ASCII.GetBytes(submission);
                                MySqlParameter formData = new MySqlParameter("?formData", MySqlDbType.Blob, dataBytes.Length);
                                formData.Value = dataBytes;

                                cmd.Parameters.Add(formData);

                                cmd.ExecuteNonQuery();

                                Parent.ExitInfo();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Missing Required Fields");
                                Cancel = true;
                                url = "about:blank";
                                ready = true;
                            }
                        }
                    } 
                }

                //if (url == "about:index")
                //{
                //    if (ready)
                //    {
                //        ready = false;

                //        string text = File.ReadAllText("");
                //        HTMLViewer.DocumentText = text;
                //    }
                //}
            });
        }

        private bool ValidateForm(string post)
        {
            bool valid = true;

            string[] input = post.Split('&');
            Dictionary<string, string> data = new Dictionary<string, string>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] split = input[i].Split('=');
                try
                {
                    data.Add(split[0], split[1]);
                }
                catch
                {
                    // Take first only
                }
            }

            string[] names = data.Keys.ToArray();
            string[] values = data.Values.ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].EndsWith("_required") && values[i] == string.Empty)
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }

        private void HTMLViewer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ready = true;
        }
    }
}
