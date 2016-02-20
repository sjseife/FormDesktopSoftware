using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminFormCreationInterface
{

    public partial class FormCreator : Form
    {
        private static int indexForText = 0;
        private static int indexForUser = 0;
        private static int indexForPassword = 0;
        private static int[,] radioGroupTracker = new int[100, 1];
        private static int indexForRadio = 0;
        private static int indexForRadioTitle = 0;
        private static int[,] checkGroupTracker = new int[100, 1];
        private static int indexForCheck = 0;
        private static int indexForCheckTitle = 0;
        private static List<TextBox> labelText = new List<TextBox>();
        private static List<TextBox> textBox = new List<TextBox>();
        private static List<TextBox> radioTextBox = new List<TextBox>();
        private static List<TextBox> radioGroupTitleBox = new List<TextBox>();
        private static List<TextBox> checkTextBox = new List<TextBox>();
        private static List<TextBox> checkGroupTitleBox = new List<TextBox>();
        private static string[,] ComboSelection = new string[100, 100];
        private static int indexForCombo = 0;
        private static ComboSelection cs;
        private static List<int> order = new List<int>();

        public FormCreator()
        {
            InitializeComponent();
        }

        private void Add1_Click(object sender, EventArgs e)
        {
            string label;
            //dynamically generates form objects based on user selection
            if (comboBox1.SelectedIndex == 1)//username
            {
                order.Add(comboBox1.SelectedIndex);
                indexForUser = indexForText;
                label = "User Name: ";
                textBoxSelected(label);
                indexForText++;

            }
            else if (comboBox1.SelectedIndex == 2)//password
            {
                order.Add(comboBox1.SelectedIndex);
                indexForPassword = indexForText;
                label = "Password: ";
                textBoxSelected(label);
                indexForText++;

            }
            else if (comboBox1.SelectedIndex == 3)//text box
            {
                label = "(Enter Label Here)";
                order.Add(comboBox1.SelectedIndex);
                textBoxSelected(label);
                indexForText++;

            }
            else if (comboBox1.SelectedIndex == 4)//combobox
            {
                //addCombo.Location = new Point(Add1.Location.X, Add1.Location.Y);
                order.Add(comboBox1.SelectedIndex);
                Add1.Visible = false;
                comboBox1.Visible = false;
                radioLabel.Visible = true;

                cs = new ComboSelection();
                ComboDone.Location = new Point(Add1.Location.X - 42, Add1.Location.Y + 16);
                ComboChange.Location = new Point(Add1.Location.X - 42, Add1.Location.Y - 6);
                ComboDone.Visible = true;
                ComboChange.Visible = true;
                radioLabel.Text = "Press done when finished adding selections";
                radioLabel.Location = new Point(Add1.Location.X - 260, Add1.Location.Y);

                cs.Show();
            }
            else if (comboBox1.SelectedIndex == 5)//radio button
            {
                order.Add(comboBox1.SelectedIndex);
                addRadio.Location = new Point(Add1.Location.X, Add1.Location.Y);
                numberCombo.Location = new Point(Add1.Location.X - 50, Add1.Location.Y);
                radioLabel.Location = new Point(Add1.Location.X - 220, Add1.Location.Y);
                radioLabel.Text = "Number of Buttons to Add";
                addRadio.Visible = true;
                Add1.Visible = false;
                comboBox1.Visible = false;
                radioLabel.Visible = true;
                numberCombo.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 6)//checkbox
            {
                order.Add(comboBox1.SelectedIndex);
                addCheckBox.Location = new Point(Add1.Location.X, Add1.Location.Y);
                numberCombo.Location = new Point(Add1.Location.X - 50, Add1.Location.Y);
                radioLabel.Location = new Point(Add1.Location.X - 220, Add1.Location.Y);
                radioLabel.Text = "Number of CheckBoxes to Add";
                addCheckBox.Visible = true;
                Add1.Visible = false;
                comboBox1.Visible = false;
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

            ActiveForm.Controls.Add(labelText[indexForText]);
            ActiveForm.Controls.Add(textBox[indexForText]);

            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
            //comboBox1.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + 75);
            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 75);
            comboBox1.SelectedIndex = 0;
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
                ActiveForm.Controls.Add(radioGroupTitleBox[indexForRadioTitle]);


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
                    ActiveForm.Controls.Add(dynamicRadio);
                    ActiveForm.Controls.Add(radioTextBox[indexForRadio]);
                    indexForRadio++;
                }


                Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 75);
                comboBox1.SelectedIndex = 0;
                Add1.Visible = true;
                comboBox1.Visible = true;
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
                ActiveForm.Controls.Add(checkGroupTitleBox[indexForCheckTitle]);

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
                    ActiveForm.Controls.Add(dynamicCheck);
                    ActiveForm.Controls.Add(checkTextBox[indexForCheck]);
                    indexForCheck++;
                }


                Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 75);
                comboBox1.SelectedIndex = 0;
                Add1.Visible = true;
                comboBox1.Visible = true;
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
            cs.Show();
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

            ActiveForm.Controls.Add(dynamicCombo);
            Add1.Location = new Point(Add1.Location.X, Add1.Location.Y + 75);
            panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + 75);
            comboBox1.SelectedIndex = 0;
            Add1.Visible = true;
            comboBox1.Visible = true;
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            t.Start();
            this.Close();
        }

        public static void ThreadProc()
        {
           // FormCreator f;
            Application.Run(new FormCreator());
        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HTMLConverter html = new HTMLConverter();
            int indexText = 0;
            int indexRadioTitle = 0;
            int indexRadio = 0;
            int indexCheck = 0;
            int indexCheckTitle = 0;
            int indexCombo = 0;
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

            html.send();
        }
    }
}
