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

    public partial class FormCreator : Form
    {
        private MainForm Parent;

        private int indexForText = 0;
        private int indexForUser = 0;
        private int indexForPassword = 0;
        private int[,] radioGroupTracker = new int[100, 1];
        private int indexForRadio = 0;
        private int indexForRadioTitle = 0;
        private int[,] checkGroupTracker = new int[100, 1];
        private int indexForCheck = 0;
        private int indexForCheckTitle = 0;
        private List<TextBox> labelText = new List<TextBox>();
        private List<TextBox> textBox = new List<TextBox>();
        private List<TextBox> radioTextBox = new List<TextBox>();
        private List<TextBox> radioGroupTitleBox = new List<TextBox>();
        private List<TextBox> checkTextBox = new List<TextBox>();
        private List<TextBox> checkGroupTitleBox = new List<TextBox>();
        private string[,] ComboSelection = new string[100, 100];
        private int indexForCombo = 0;
        private ComboSelection cs;
        private WorkFlowSelector wfs = new WorkFlowSelector();
        private List<int> order = new List<int>();


        public FormCreator(MainForm parent)
        {
            Parent = parent;
            InitializeComponent();
        }

        private void Add1_Click(object sender, EventArgs e)
        {
            string label;
            //dynamically generates form objects based on user selection
            if (NewObjectCombo.SelectedIndex == 1)//username
            {
                order.Add(NewObjectCombo.SelectedIndex);
                indexForUser = indexForText;
                label = "User Name: ";
                textBoxSelected(label);
                indexForText++;

            }
            else if (NewObjectCombo.SelectedIndex == 2)//password
            {
                order.Add(NewObjectCombo.SelectedIndex);
                indexForPassword = indexForText;
                label = "Password: ";
                textBoxSelected(label);
                indexForText++;

            }
            else if (NewObjectCombo.SelectedIndex == 3)//text box
            {
                label = "(Enter Label Here)";
                order.Add(NewObjectCombo.SelectedIndex);
                textBoxSelected(label);
                indexForText++;

            }
            else if (NewObjectCombo.SelectedIndex == 4)//combobox
            {
                //addCombo.Location = new Point(Add1.Location.X, Add1.Location.Y);
                order.Add(NewObjectCombo.SelectedIndex);
                Add1.Visible = false;
                NewObjectCombo.Visible = false;
                radioLabel.Visible = true;

                cs = new ComboSelection();
                ComboDone.Location = new Point(Add1.Location.X - 42, Add1.Location.Y + 16);
                ComboChange.Location = new Point(Add1.Location.X - 42, Add1.Location.Y - 6);
                ComboDone.Visible = true;
                ComboChange.Visible = true;
                radioLabel.Text = "Press done when finished adding selections";
                radioLabel.Location = new Point(Add1.Location.X - 260, Add1.Location.Y);

                cs.ShowDialog();
            }
            else if (NewObjectCombo.SelectedIndex == 5)//radio button
            {
                order.Add(NewObjectCombo.SelectedIndex);
                addRadio.Location = new Point(Add1.Location.X, Add1.Location.Y);
                numberCombo.Location = new Point(Add1.Location.X - 50, Add1.Location.Y);
                radioLabel.Location = new Point(Add1.Location.X - 220, Add1.Location.Y);
                radioLabel.Text = "Number of Buttons to Add";
                addRadio.Visible = true;
                Add1.Visible = false;
                NewObjectCombo.Visible = false;
                radioLabel.Visible = true;
                numberCombo.Visible = true;
            }
            else if (NewObjectCombo.SelectedIndex == 6)//checkbox
            {
                order.Add(NewObjectCombo.SelectedIndex);
                addCheckBox.Location = new Point(Add1.Location.X, Add1.Location.Y);
                numberCombo.Location = new Point(Add1.Location.X - 50, Add1.Location.Y);
                radioLabel.Location = new Point(Add1.Location.X - 220, Add1.Location.Y);
                radioLabel.Text = "Number of CheckBoxes to Add";
                addCheckBox.Visible = true;
                Add1.Visible = false;
                NewObjectCombo.Visible = false;
                radioLabel.Visible = true;
                numberCombo.Visible = true;
            }
        }

        private void textBoxSelected(string label) //adds text box to form
        {
            labelText.Add(new TextBox());
            labelText[indexForText].Text = label;
            labelText[indexForText].TextAlign = HorizontalAlignment.Center;
            labelText[indexForText].Location = new Point(Add1.Location.X - 175, Add1.Location.Y);

            textBox.Add(new TextBox());
            textBox[indexForText].Enabled = false;
            textBox[indexForText].Location = new Point(Add1.Location.X - 240, Add1.Location.Y + 27);
            textBox[indexForText].Size = new Size(225, 60);

            ButtonSplitter.Panel2.Controls.Add(labelText[indexForText]);
            ButtonSplitter.Panel2.Controls.Add(textBox[indexForText]);
            //ButtonSplitter.Panel2.Controls.Add(labelText[indexForText]);
            //ButtonSplitter.Panel2.Controls.Add(textBox[indexForText]);

            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
            //comboBox1.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 75);
            NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 75);
            NewObjectCombo.SelectedIndex = 0;
        }

        private void FormCreator_Load(object sender, EventArgs e)
        {

        }

        private void addRadio_Click(object sender, EventArgs e)
        {
            int locChange;

            if (numberCombo.SelectedIndex >= 0)
            {
                radioGroupTracker[indexForRadioTitle, 0] = numberCombo.SelectedIndex + 1; //grabs number of radio buttons to be added
                radioGroupTitleBox.Add(new TextBox());

                radioGroupTitleBox[indexForRadioTitle].Location = new Point(Add1.Location.X - 295, Add1.Location.Y);
                radioGroupTitleBox[indexForRadioTitle].Text = "(Group Label)";
                ButtonSplitter.Panel2.Controls.Add(radioGroupTitleBox[indexForRadioTitle]);


                for (int i = 0; i < radioGroupTracker[indexForRadioTitle, 0]; i++) //generates total number of radio buttons selected by user
                {
                    locChange = i * 91;
                    RadioButton dynamicRadio = new RadioButton();
                    dynamicRadio.Size = new Size(14, 13);
                    dynamicRadio.Location = new Point(Add1.Location.X - (315 - locChange), Add1.Location.Y + 30);
                    radioTextBox.Add(new TextBox());
                    radioTextBox[indexForRadio].Size = new Size(64, 20);
                    radioTextBox[indexForRadio].Text = "(Label " + (i + 1) + ")";
                    radioTextBox[indexForRadio].Location = new Point(Add1.Location.X - (295 - locChange), Add1.Location.Y + 27);
                    ButtonSplitter.Panel2.Controls.Add(dynamicRadio);
                    ButtonSplitter.Panel2.Controls.Add(radioTextBox[indexForRadio]);
                    indexForRadio++;
                }


                Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
                NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 75);
                NewObjectCombo.SelectedIndex = 0;
                Add1.Visible = true;
                NewObjectCombo.Visible = true;
                radioLabel.Visible = false;
                numberCombo.Visible = false;
                addRadio.Visible = false;

                indexForRadioTitle++;
            }//if
                
            


            //Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
            //comboBox1.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 75);
            //panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 75);
            //comboBox1.SelectedIndex = 0;
            //Add1.Visible = true;
            //comboBox1.Visible = true;
        }

        private void addCheckBox_Click(object sender, EventArgs e)
        {
            int locChange;

            if (numberCombo.SelectedIndex >= 0)
            {
                checkGroupTracker[indexForCheckTitle, 0] = numberCombo.SelectedIndex + 1; //grabs number of check buttons to be added
                checkGroupTitleBox.Add(new TextBox());

                checkGroupTitleBox[indexForCheckTitle].Location = new Point(Add1.Location.X - 295, Add1.Location.Y);
                checkGroupTitleBox[indexForCheckTitle].Text = "(Group Label)";
                ButtonSplitter.Panel2.Controls.Add(checkGroupTitleBox[indexForCheckTitle]);

                for (int i = 0; i < checkGroupTracker[indexForCheckTitle, 0]; i++)
                {
                    locChange = i * 91;
                    CheckBox dynamicCheck = new CheckBox();
                    dynamicCheck.Size = new Size(14, 13);
                    dynamicCheck.Location = new Point(Add1.Location.X - (315 - locChange), Add1.Location.Y + 30);
                    checkTextBox.Add(new TextBox());
                    checkTextBox[indexForCheck].Size = new Size(64, 20);
                    checkTextBox[indexForCheck].Text = "(Label " + (i + 1) + ")";
                    checkTextBox[indexForCheck].Location = new Point(Add1.Location.X - (295 - locChange), Add1.Location.Y + 27);
                    ButtonSplitter.Panel2.Controls.Add(dynamicCheck);
                    ButtonSplitter.Panel2.Controls.Add(checkTextBox[indexForCheck]);
                    indexForCheck++;
                }


                Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
                NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 75);
                NewObjectCombo.SelectedIndex = 0;
                Add1.Visible = true;
                NewObjectCombo.Visible = true;
                radioLabel.Visible = false;
                numberCombo.Visible = false;
                addCheckBox.Visible = false;

                
                indexForCheckTitle++;
            }
        }

        private void addCombo_Click(object sender, EventArgs e)
        {
            

        }

        private void ComboChange_Click(object sender, EventArgs e) //opens form to fill out collection
        {
            cs.ShowDialog();
        }

        private void ComboDone_Click(object sender, EventArgs e) //generates combobox after user has finished filling out the collection
        {
            string[] temp = (string []) cs.getResult().Clone();

            ComboBox dynamicCombo = new ComboBox();
            dynamicCombo.Location = new Point(radioLabel.Location.X + 70, radioLabel.Location.Y);
            for (int i = 0; i < temp.Length; i++)
            {
                ComboSelection[indexForCombo, i] = temp[i];
                dynamicCombo.Items.Add(temp[i]);
                
            }
            indexForCombo++;
            cs.Close();
            dynamicCombo.SelectedIndex = 0;

            ButtonSplitter.Panel2.Controls.Add(dynamicCombo);
            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
            NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 75);
            NewObjectCombo.SelectedIndex = 0;
            Add1.Visible = true;
            NewObjectCombo.Visible = true;
            ComboDone.Visible = false;
            ComboChange.Visible = false;
            radioLabel.Visible = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HTMLConverter html = new HTMLConverter();
            int indexText = 0;
            int indexRadioTitle = 0;
            int indexRadio = 0;
            int indexCheck = 0;
            int indexCheckTitle = 0;
            int indexCombo = 0;
            html.setTitle(Title.Text);
            foreach(int i in order)
            {
                if(i == 1)
                {
                    html.createTextBox(labelText[indexText].Text);
                        indexText++;
                }
                else if(i == 2)
                {
                    html.createPassword(labelText[indexText].Text);
                    indexText++;
                }
                else if (i == 3)
                {
                    html.createTextBox(labelText[indexText].Text);
                    indexText++;
                }
                else if (i == 4)
                {
                    List<string> comboList = new List<string>();
                    for(int x = 0; x < 100; x++)
                    {
                        if (ComboSelection[indexCombo, x] == null)
                            continue;
                        else
                        comboList.Add(ComboSelection[indexCombo, x]);
                    }//for
                    html.createListBox(comboList);
                    indexCombo++;
                }
                else if (i == 5)
                {
                    string[] radioArr = new string[radioGroupTracker[indexRadioTitle, 0]];

                    for (int x = 0; x < radioGroupTracker[indexRadioTitle, 0]; x++)
                    {
                        radioArr[x] = radioTextBox[indexRadio].Text;
                        indexRadio++;
                    }//for
                    html.createRadio(radioGroupTitleBox[indexRadioTitle].Text, radioArr);
                    indexRadioTitle++;
                }
                else if (i == 6)
                {
                    string[] checkBoxArr = new string[checkGroupTracker[indexCheckTitle, 0]];

                    for (int x = 0; x < checkGroupTracker[indexCheckTitle, 0]; x++)
                    {
                        checkBoxArr[x] = checkTextBox[indexCheck].Text;
                        indexCheck++;
                    }
                    html.createCheckBox(checkGroupTitleBox[indexCheckTitle].Text, checkBoxArr);
                    indexCheckTitle++;
                }
            }

            html.save();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Parent.ExitInfo();
            this.Close();
            wfs.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            HTMLConverter html = new HTMLConverter();
            int indexText = 0;
            int indexRadioTitle = 0;
            int indexRadio = 0;
            int indexCheck = 0;
            int indexCheckTitle = 0;
            int indexCombo = 0;
            if(wfs.checkAssignment())
            { 

                html.setTitle(Title.Text);
                foreach (int i in order)
                {
                    if (i == 1)
                    {
                        html.createTextBox(labelText[indexText].Text);
                        indexText++;
                    }
                    else if (i == 2)
                    {
                        html.createPassword(labelText[indexText].Text);
                        indexText++;
                    }
                    else if (i == 3)
                    {
                        html.createTextBox(labelText[indexText].Text);
                        indexText++;
                    }
                    else if (i == 4)
                    {
                        List<string> comboList = new List<string>();
                        for (int x = 0; x < 100; x++)
                        {
                            if (ComboSelection[indexCombo, x] == null)
                                continue;
                            else
                                comboList.Add(ComboSelection[indexCombo, x]);
                        }//for
                        html.createListBox(comboList);
                        indexCombo++;
                    }
                    else if (i == 5)
                    {
                        string[] radioArr = new string[radioGroupTracker[indexRadioTitle, 0]];

                        for (int x = 0; x < radioGroupTracker[indexRadioTitle, 0]; x++)
                        {
                            radioArr[x] = radioTextBox[indexRadio].Text;
                            indexRadio++;
                        }//for
                        html.createRadio(radioGroupTitleBox[indexRadioTitle].Text, radioArr);
                        indexRadioTitle++;
                    }
                    else if (i == 6)
                    {
                        string[] checkBoxArr = new string[checkGroupTracker[indexCheckTitle, 0]];

                        for (int x = 0; x < checkGroupTracker[indexCheckTitle, 0]; x++)
                        {
                            checkBoxArr[x] = checkTextBox[indexCheck].Text;
                            indexCheck++;
                        }
                        html.createCheckBox(checkGroupTitleBox[indexCheckTitle].Text, checkBoxArr);
                        indexCheckTitle++;
                    }
                }
                
            

                DateTime date = DateTime.Now;
                string newdate = date.ToString("yyyy-MM-dd");

                string htmlString = html.GetHTML();
                byte[] rawData = Encoding.UTF8.GetBytes(htmlString);

                string SQL = String.Format("INSERT INTO form_template(form_name, form_file, form_creation_date) VALUES(@form_name, @form_file, @form_creation_date)");
                string getID = String.Format("SELECT MAX(form_id)AS form_id FROM form_template"); // Gets the most recently created table

                MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(SQL, Parent.Connection);

                cmd.Parameters.AddWithValue("@form_name", Title.Text);
                cmd.Parameters.AddWithValue("@form_file", rawData);
                cmd.Parameters.AddWithValue("@form_creation_date", newdate);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("File Inserted into database successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Insert the data from the from into the form_element table
                try
                {
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(getID, Parent.Connection);            
                    object form_id = cmd.ExecuteScalar();
                    Parent.ExitInfo();
                    this.Close();

                    html.form_elementPopulator.send(form_id.ToString());
                    wfs.send(form_id.ToString());
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Assign Workflow First", "Error!");
            }

           
        }

        private void AddWorkflow_Click(object sender, EventArgs e)
        {
            if(!wfs.isListPopulated())
                wfs.assignChoices();

            wfs.ShowDialog();
        }
    }
}
