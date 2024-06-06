using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master
{
    public partial class FormWriteMultiHr : Form
    {
        public bool[] Values { get; private set; }
        public FormWriteMultiHr()
        {
            InitializeComponent();
            Values = new bool[3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bool.TryParse(comboBox1.Text, out bool value1) && bool.TryParse(comboBox2.Text, out bool value2) &&
                bool.TryParse(comboBox3.Text, out bool value3))
            {
                Values[0] = value1;
                Values[1] = value2;
                Values[2] = value3;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Enter valid values for Address and Value");
            }
        }
    }
}
