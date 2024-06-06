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
    public partial class FormInput : Form
    {
        public ushort StartAddress { get; private set; }
        public ushort NumberOfPoints { get; private set; }
        public FormInput()
        {
            InitializeComponent();
        }

        private void btnFormInputRead_Click(object sender, EventArgs e)
        {
            if(ushort.TryParse(tbStartAddress.Text, out ushort startAddress) && ushort.TryParse(tbNumOfPoints.Text, out ushort  numberOfPoints)) {
                StartAddress = startAddress;
                NumberOfPoints = numberOfPoints;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Enter valid values for Start Address and Number of Points");
            }
        }
    }
}
