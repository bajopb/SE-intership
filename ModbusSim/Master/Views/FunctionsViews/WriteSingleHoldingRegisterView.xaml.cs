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
    /// Interaction logic for WriteSingleHoldingRegisterView.xaml
    /// </summary>
    public partial class WriteSingleHoldingRegisterView : Window
    {

        public byte UnitID {get;set;}
        public ushort Address{get;set;}
        public ushort Value{get;set;}
        public WriteSingleHoldingRegisterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (byte.TryParse(tbUnitId.Text, out byte unitId) && ushort.TryParse(tbAddress.Text, out ushort address) &&
                ushort.TryParse(tbValue.Text, out ushort value))
            {
                UnitID = unitId;
                Address = address;
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
