using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsProject
{
    public partial class WorkFlowSelector : Form
    {
        private List<Label> labels = new List<Label>();
        private List<string> workFlow = new List<string>();
        private List<string> jobTitles = new List<string>();
        private List<PictureBox> arrows = new List<PictureBox>();
        private int indexForArrows = 0;
        private int indexForLabel = 0;
        private bool assigned = false; //user assigned workflow
        private bool listPopulated = false; //combo box has been populated already

        public WorkFlowSelector()
        {
            InitializeComponent();
        }

        public void assignChoices()
        {
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(); ;

            string serverName = "server=einstein.etsu.edu";
            string databaseName = "database=schaum";
            string username = "uid=schaum";
            string password = "pwd=12345";
            string getJobTitles = "SELECT DISTINCT user_title FROM user_accounts";
            conn.ConnectionString = (string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));

            try
            {
                conn.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getJobTitles, conn);
                using (MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        jobTitles.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                }
                
                conn.Close();

                foreach (string jobby in jobTitles)
                {
                    workFlowList.Items.Add(jobby);
                }
                listPopulated = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            
                               
        }//assignChoices()
        
        public bool checkAssignment()
        {
            return assigned;
        }//checkAssignment()

        public bool isListPopulated()
        {
            return listPopulated;
        }
        private void Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add1_Click(object sender, EventArgs e)
        {
            int index = workFlowList.SelectedIndex;
            if (index != 0)
            {
                labels.Add(new Label());
                workFlow.Add(workFlowList.SelectedItem.ToString());
                labels[indexForLabel].Text = workFlow[indexForLabel];
                labels[indexForLabel].Location = new Point(Add1.Location.X - 175, Add1.Location.Y - 60);
                labels[indexForLabel].BringToFront();
                labels[indexForLabel].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;  
                labels[indexForLabel].TextAlign = ContentAlignment.MiddleCenter;
                labels[indexForLabel].Visible = true;
                workFlowList.Items.RemoveAt(workFlowList.SelectedIndex);
                panel1.Controls.Add(labels[indexForLabel]);
                if(indexForLabel > 0)
                {
                    arrows.Add(arrowTemplate.Clone());
                    arrows[indexForArrows].Location = new Point(labels[indexForLabel].Location.X + 35, labels[indexForLabel].Location.Y - 22);
                    arrows[indexForArrows].Visible = true;
                    panel1.Controls.Add(arrows[indexForArrows]);
                    indexForArrows++;
                }
                indexForLabel++;

                Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 45);
                workFlowPanel.Location = new Point(workFlowPanel.Location.X, workFlowPanel.Location.Y + 45);
                workFlowList.SelectedIndex = 0;



            }
            else
            {
                MessageBox.Show("Must select an authorizer", "No Authorizer Selected");
            }
        }

        private void NewObjectContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (workFlow.Count > 0)
            {
               assigned = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Must Choose at Least One Authorizer", "Error!");
            }
        }

        public void send(string form_id)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(); ;

            string serverName = "server=einstein.etsu.edu";
            string databaseName = "database=schaum";
            string username = "uid=schaum";
            string password = "pwd=12345";
            int userLevel = 0;



            conn.ConnectionString = (string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));
            
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand();

            try
            {
                conn.Open();
                cmd1.Connection = conn;

                foreach (string userTitle in workFlow)
                {
                    userLevel = isAdmin(userTitle);

                    cmd1.CommandText = "INSERT INTO workflow(form_id, user_title, user_level_required) VALUES(@form_id, @user_title, @user_level_required);";
                    cmd1.Parameters.AddWithValue("@user_title", userTitle);
                    cmd1.Parameters.AddWithValue("@user_level_required", userLevel);
                    cmd1.Parameters.AddWithValue("@form_id", form_id);
                    cmd1.ExecuteNonQuery();
                    cmd1.Parameters.Clear();
                }

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//send()

        private int isAdmin(string input)
        {
            int output = 0;
            string normalized = Regex.Replace(input, @"\s", "");

            if (String.Equals(normalized, "admin", StringComparison.OrdinalIgnoreCase))
                output = 1;
            if (String.Equals(normalized, "superadmin", StringComparison.OrdinalIgnoreCase))
                output = 2;

            return output;

        }//isEqual()

    }//WorkFlowSelector class

    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }
    }
}
