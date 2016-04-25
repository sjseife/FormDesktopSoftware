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
        private int indexForMultiLineText = 0;
        private int indexForDate = 0;
        private int indexForUser = 0;
        private int indexForPassword = 0;
        private int[,] radioGroupTracker = new int[100, 1];
        private int indexForRadio = 0;
        private int indexForRadioTitle = 0;
        private int[,] checkGroupTracker = new int[100, 1];
        private int indexForCheck = 0;
        private int indexForCheckTitle = 0;
        private int indexForHeader = 0;
        private int indexForRadioButton = 0;
        private int indexForCheckButton = 0;
        private int indexForComboList = 0;
        private List<TextBox> labelText = new List<TextBox>();
        private List<TextBox> textBox = new List<TextBox>();
        private List<TextBox> multiLineTextBox = new List<TextBox>();
        private List<TextBox> multiLineLabelText = new List<TextBox>();
        private List<TextBox> dateTextLabel = new List<TextBox>();
        private List<TextBox> dateTextBox = new List<TextBox>();
        private List<TextBox> radioTextBox = new List<TextBox>();
        private List<TextBox> radioGroupTitleBox = new List<TextBox>();
        private List<TextBox> checkTextBox = new List<TextBox>();
        private List<TextBox> checkGroupTitleBox = new List<TextBox>();
        private List<TextBox> dynamicComboTitleBox = new List<TextBox>();
        private List<TextBox> headerText = new List<TextBox>();
        private List<ComboBox> dynamicCombo = new List<ComboBox>();
        private List<RadioButton> dynamicRadio = new List<RadioButton>();
        private List<CheckBox> dynamicCheck = new List<CheckBox>();
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
                showDeleteButton();

                textBoxSelected(label);
                indexForText++;

            }
            else if (NewObjectCombo.SelectedIndex == 2)//password
            {
                order.Add(NewObjectCombo.SelectedIndex);
                indexForPassword = indexForText;
                label = "Password: ";
                showDeleteButton();
                textBoxSelected(label);
                indexForText++;

            }
            else if (NewObjectCombo.SelectedIndex == 3)//text box
            {
                label = "(Enter Label Here)";
                order.Add(NewObjectCombo.SelectedIndex);
                showDeleteButton();
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
                deleteButton.Visible = false;

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
            else if (NewObjectCombo.SelectedIndex == 7)//date
            {
                order.Add(NewObjectCombo.SelectedIndex);
                label = "Date: ";
                dateSelected(label);
                indexForDate++;
            }
            else if (NewObjectCombo.SelectedIndex == 8)//text field
            {
                label = "(Enter Label Here)";
                order.Add(NewObjectCombo.SelectedIndex);
                multiLineTextBoxSelected(label);
                indexForMultiLineText++;
            }
            else if (NewObjectCombo.SelectedIndex == 9)//Header
            {
                label = "(Enter Header Here)";
                order.Add(NewObjectCombo.SelectedIndex);
                headerSelected(label);
                indexForHeader++;
            }
        }

        private void showDeleteButton()
        {
            deleteButton.Location = new Point(Add1.Location.X, Add1.Location.Y);
            deleteButton.Visible = true;
        }//showDeleteButton

        private void headerSelected(string input)
        {
            headerText.Add(new TextBox());
            headerText[indexForHeader].Text = input;
            headerText[indexForHeader].TextAlign = HorizontalAlignment.Center;
            headerText[indexForHeader].Location = new Point(Add1.Location.X - 175, Add1.Location.Y);

            ButtonSplitter.Panel2.Controls.Add(headerText[indexForHeader]);

            showDeleteButton();
            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 50);
            NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 50);
            NewObjectCombo.SelectedIndex = 0;
        }//headerSelected(string)

        private void multiLineTextBoxSelected(string label) //adds text box to form
        {
            multiLineLabelText.Add(new TextBox());
            multiLineLabelText[indexForMultiLineText].Text = label;
            multiLineLabelText[indexForMultiLineText].TextAlign = HorizontalAlignment.Center;
            multiLineLabelText[indexForMultiLineText].Location = new Point(Add1.Location.X - 175, Add1.Location.Y);

            multiLineTextBox.Add(new TextBox());
            multiLineTextBox[indexForMultiLineText].Enabled = false;
            multiLineTextBox[indexForMultiLineText].Multiline = true;
            multiLineTextBox[indexForMultiLineText].Location = new Point(Add1.Location.X - 240, Add1.Location.Y + 27);
            multiLineTextBox[indexForMultiLineText].Size = new Size(225, 60);

            ButtonSplitter.Panel2.Controls.Add(multiLineLabelText[indexForMultiLineText]);
            ButtonSplitter.Panel2.Controls.Add(multiLineTextBox[indexForMultiLineText]);
            //ButtonSplitter.Panel2.Controls.Add(labelText[indexForText]);
            //ButtonSplitter.Panel2.Controls.Add(textBox[indexForText]);

            showDeleteButton();
            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 125);
            //comboBox1.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 75);
            NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 125);
            NewObjectCombo.SelectedIndex = 0;
        }
        private void dateSelected(string label) //adds text box for date
        {
            dateTextLabel.Add(new TextBox());
            dateTextLabel[indexForDate].Text = label;
            dateTextLabel[indexForDate].TextAlign = HorizontalAlignment.Center;
            dateTextLabel[indexForDate].Location = new Point(Add1.Location.X - 175, Add1.Location.Y);

            dateTextBox.Add(new TextBox());
            dateTextBox[indexForDate].Enabled = false;
            dateTextBox[indexForDate].Location = new Point(Add1.Location.X - 240, Add1.Location.Y + 27);
            dateTextBox[indexForDate].Size = new Size(225, 60);

            ButtonSplitter.Panel2.Controls.Add(dateTextLabel[indexForDate]);
            ButtonSplitter.Panel2.Controls.Add(dateTextBox[indexForDate]);
            //ButtonSplitter.Panel2.Controls.Add(labelText[indexForText]);
            //ButtonSplitter.Panel2.Controls.Add(textBox[indexForText]);

            showDeleteButton();
            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
            //comboBox1.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 75);
            NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y + 75);
            NewObjectCombo.SelectedIndex = 0;
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
                    dynamicRadio.Add(new RadioButton());
                    dynamicRadio[indexForRadioButton].Size = new Size(14, 13);
                    dynamicRadio[indexForRadioButton].Location = new Point(Add1.Location.X - (315 - locChange), Add1.Location.Y + 30);
                    radioTextBox.Add(new TextBox());
                    radioTextBox[indexForRadio].Size = new Size(64, 20);
                    radioTextBox[indexForRadio].Text = "(Label " + (i + 1) + ")";
                    radioTextBox[indexForRadio].Location = new Point(Add1.Location.X - (295 - locChange), Add1.Location.Y + 27);
                    ButtonSplitter.Panel2.Controls.Add(dynamicRadio[indexForRadioButton]);
                    ButtonSplitter.Panel2.Controls.Add(radioTextBox[indexForRadio]);
                    indexForRadio++;
                    indexForRadioButton++;
                }

                showDeleteButton();
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
                    dynamicCheck.Add(new CheckBox());
                    dynamicCheck[indexForCheckButton].Size = new Size(14, 13);
                    dynamicCheck[indexForCheckButton].Location = new Point(Add1.Location.X - (315 - locChange), Add1.Location.Y + 30);
                    checkTextBox.Add(new TextBox());
                    checkTextBox[indexForCheck].Size = new Size(64, 20);
                    checkTextBox[indexForCheck].Text = "(Label " + (i + 1) + ")";
                    checkTextBox[indexForCheck].Location = new Point(Add1.Location.X - (295 - locChange), Add1.Location.Y + 27);
                    ButtonSplitter.Panel2.Controls.Add(dynamicCheck[indexForCheckButton]);
                    ButtonSplitter.Panel2.Controls.Add(checkTextBox[indexForCheck]);
                    indexForCheck++;
                    indexForCheckButton++;
                }

                showDeleteButton();
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

            dynamicCombo.Add(new ComboBox());
            dynamicCombo[indexForComboList].Location = new Point(radioLabel.Location.X + 70, radioLabel.Location.Y);
            dynamicComboTitleBox.Add(new TextBox());

            dynamicComboTitleBox[indexForCombo].Location = new Point(Add1.Location.X - 295, Add1.Location.Y);
            dynamicComboTitleBox[indexForCombo].Text = "(Group Label)";
            ButtonSplitter.Panel2.Controls.Add(dynamicComboTitleBox[indexForCombo]);
            for (int i = 0; i < temp.Length; i++)
            {
                ComboSelection[indexForCombo, i] = temp[i];
                dynamicCombo[indexForComboList].Items.Add(temp[i]);
                
            }
            indexForCombo++;
            cs.Close();
            dynamicCombo[indexForComboList].SelectedIndex = 0;

            ButtonSplitter.Panel2.Controls.Add(dynamicCombo[indexForComboList]);
            indexForComboList++;

            showDeleteButton();
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
            int indexForMultiLineText = 0;
            int indexForDate = 0;
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
                    html.createListBox(comboList, dynamicComboTitleBox[indexCombo].Text);
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
                else if (i==7)
                {
                    html.createDateTextBox(dateTextLabel[indexForDate].Text);
                    indexForDate++;
                }
                else if (i == 8)
                {
                    html.createMulitLineTextBox(multiLineLabelText[indexForMultiLineText].Text);
                    indexForMultiLineText++;
                }
                else if (i == 9)
                {
                    html.createHeader(headerText[indexForHeader].Text);
                    indexForHeader++;
                }

            }

            html.save();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Parent.ExitFormCreater();
            this.Close();
            wfs.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            HTMLConverter html = new HTMLConverter();
            int indexText = 0;
            int indexForMultiLineText = 0;
            int indexForDate = 0;
            int indexRadioTitle = 0;
            int indexRadio = 0;
            int indexCheck = 0;
            int indexCheckTitle = 0;
            int indexCombo = 0;
            int indexHeader = 0;

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

                    html.createListBox(comboList, dynamicComboTitleBox[indexCombo].Text);
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
                else if (i == 7)
                {
                    html.createDateTextBox(dateTextLabel[indexForDate].Text);
                    indexForDate++;
                }
                else if (i == 8)
                {
                    html.createMulitLineTextBox(multiLineLabelText[indexForMultiLineText].Text);
                    indexForMultiLineText++;
                }
                else if (i == 9)
                {
                    html.createHeader(headerText[indexHeader].Text);
                    indexHeader++;
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
                Parent.ExitFormCreater();
                this.Close();

                html.form_elementPopulator.send(form_id.ToString());
                if (wfs.checkAssignment())
                {
                    wfs.send(form_id.ToString());
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddWorkflow_Click(object sender, EventArgs e)
        {
            if(!wfs.isListPopulated())
                wfs.assignChoices();

            wfs.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if ((order.Last() > 0) && (order.Last() < 4))
                deleteTextBox();
            else if (order.Last() == 4)
                deleteCombo();
            else if (order.Last() == 5)
                deleteRadio();
            else if (order.Last() == 6)
                deleteCheck();
            else if (order.Last() == 7)
                deleteDate();
            else if (order.Last() == 8)
                deleteMultiLineText();
            else if (order.Last() == 9)
                deleteHeader();



        }//deleteButton_Click

        private void deleteTextBox()
        {
            moveContainerBack(75);
            indexForText--;
            ButtonSplitter.Panel2.Controls.Remove(labelText[indexForText]);
            ButtonSplitter.Panel2.Controls.Remove(textBox[indexForText]);

        }

        private void deleteCombo()
        {
            moveContainerBack(75);
            indexForCombo--;
            indexForComboList--;

            ButtonSplitter.Panel2.Controls.Remove(dynamicComboTitleBox[indexForCombo]);
            ButtonSplitter.Panel2.Controls.Remove(dynamicCombo[indexForComboList]);
        }

        private void deleteRadio()
        {
            moveContainerBack(75);
            indexForRadioTitle--;
            ButtonSplitter.Panel2.Controls.Remove(radioGroupTitleBox[indexForRadioTitle]);
            for (int i = 0; i < radioGroupTracker[indexForRadioTitle, 0]; i++) //generates total number of radio buttons selected by user
            {
                indexForRadio--;
                indexForRadioButton--;
                ButtonSplitter.Panel2.Controls.Remove(dynamicRadio[indexForRadioButton]);
                ButtonSplitter.Panel2.Controls.Remove(radioTextBox[indexForRadio]);
            }
        }

        private void deleteCheck()
        {
            moveContainerBack(75);
            indexForCheckTitle--;
            ButtonSplitter.Panel2.Controls.Remove(checkGroupTitleBox[indexForCheckTitle]);
            for (int i = 0; i < checkGroupTracker[indexForCheckTitle, 0]; i++) //generates total number of radio buttons selected by user
            {
                indexForCheck--;
                indexForCheckButton--;
                ButtonSplitter.Panel2.Controls.Remove(dynamicCheck[indexForCheckButton]);
                ButtonSplitter.Panel2.Controls.Remove(checkTextBox[indexForCheck]);
            }
        }

        private void deleteDate()
        {
            moveContainerBack(75);
            indexForDate--;
            ButtonSplitter.Panel2.Controls.Remove(dateTextLabel[indexForDate]);
            ButtonSplitter.Panel2.Controls.Remove(dateTextBox[indexForDate]);
        }

        private void deleteMultiLineText()
        {
            moveContainerBack(125);
            indexForMultiLineText--;
            ButtonSplitter.Panel2.Controls.Remove(multiLineLabelText[indexForMultiLineText]);
            ButtonSplitter.Panel2.Controls.Remove(multiLineTextBox[indexForMultiLineText]);
        }
        
        private void deleteHeader()
        {
            moveContainerBack(50);
            indexForHeader--;
            ButtonSplitter.Panel2.Controls.Remove(headerText[indexForHeader]);

        }

        private void moveContainerBack(int panelLoc)
        {
            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y - panelLoc);
            NewObjectContainer.Location = new Point(NewObjectContainer.Location.X, NewObjectContainer.Location.Y - panelLoc);
            NewObjectCombo.SelectedIndex = 0;
            if (order.Count > 1)
            {
                if(order[order.Count - 2] == 8)
                    deleteButton.Location = new Point(Add1.Location.X, Add1.Location.Y - 125);
                else if(order[order.Count - 2] == 9)
                    deleteButton.Location = new Point(Add1.Location.X, Add1.Location.Y - 50);
                else
                    deleteButton.Location = new Point(Add1.Location.X, Add1.Location.Y - 75);
            }
            else
            {
                deleteButton.Visible = false;
            }

            order.Remove(order.Last());
        }
    }
}
