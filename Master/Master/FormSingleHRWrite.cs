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
    public partial class FormSingleHRWrite : Form
    {
        public ushort Address { get; private set; }
        public ushort Value { get; private set; }

        public FormSingleHRWrite()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (ushort.TryParse(tbAddress.Text, out ushort address) && ushort.TryParse(tbValue.Text, out ushort value))
            {
                Address = address;
                Value = value;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Enter valid values for Address and Value");

            }
        }
    }
}
