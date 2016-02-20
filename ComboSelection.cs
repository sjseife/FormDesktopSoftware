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
    public partial class ComboSelection : Form
    {
        private static string[] result;
        public ComboSelection()
        {
            InitializeComponent();
        }

        private void ComboSelection_Load(object sender, EventArgs e)
        {

        }

        private void addCombo_Click(object sender, EventArgs e)
        {
            string collection = textCollectionBox.Text;
            result = collection.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            ActiveForm.Hide();
        }
        public string[] getResult()
        {
            return result;
        }
    }
}
