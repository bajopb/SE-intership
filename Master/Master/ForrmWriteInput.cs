using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master
{
    public partial class ForrmWriteInput : Form
    {
        public ushort Address { get; private set; }
        public bool Value { get; private set; }

        public ForrmWriteInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ushort.TryParse(tbAddress.Text, out ushort address) && bool.TryParse(comboBox1.Text, out bool value))
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
