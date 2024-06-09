using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Master.Views
{
    /// <summary>
    /// Interaction logic for WriteSingleCoilView.xaml
    /// </summary>
    public partial class WriteSingleCoilView : Window
    {
        public byte UnitID{ get; set; }
        public ushort StartAddress{ get; set; }
        public bool Value { get; set; }
        public WriteSingleCoilView()
        {
            InitializeComponent();
            cbValue.Items.Add("true");
            cbValue.Items.Add("false");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (byte.TryParse(tbUnitId.Text, out byte unitId) && ushort.TryParse(tbStartAddress.Text, out ushort startAddress) &&
                bool.TryParse(cbValue.Text, out bool value))
            {
                UnitID = unitId;
                StartAddress = startAddress;
                Value = value;
                this.DialogResult = true; this.Close();
            }
            else
            {
                MessageBox.Show("Enter valid values");
            }
        }
    }
}
