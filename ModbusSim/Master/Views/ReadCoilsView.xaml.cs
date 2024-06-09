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
    /// Interaction logic for ReadCoilsView.xaml
    /// </summary>
    public partial class ReadCoilsView : Window
    {
        public byte UnitId { get; set; }
        public ushort StartAddress { get; set; }
        public ushort NumberOfPoints { get; set; }
        public ReadCoilsView()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            if(byte.TryParse(tbUnitID.Text, out byte unitId) && ushort.TryParse(tbStartAddress.Text, out ushort startAddress) && 
                ushort.TryParse(tbNumberOfPoints.Text, out ushort numberOfPoints)) {
                UnitId= unitId;
                StartAddress= startAddress;
                NumberOfPoints= numberOfPoints;
                this.DialogResult = true; this.Close();
            }
            else
            {
                MessageBox.Show("Enter valid values");
            }
        }
    }
}
