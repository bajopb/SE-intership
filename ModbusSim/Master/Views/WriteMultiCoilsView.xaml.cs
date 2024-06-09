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
    /// Interaction logic for WriteMultiCoilsView.xaml
    /// </summary>
    public partial class WriteMultiCoilsView : Window
    {

        public byte UnitId{get;set;}
        public ushort StartAddress {get;set;}
        public bool[] Values {get;set;}
        public WriteMultiCoilsView()
        {
            InitializeComponent();
        }

        private void tbNumberOfCoils_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tbNumberOfCoils.Text, out int numberOfCoils) && numberOfCoils > 0)
            {
                if (numberOfCoils > 123)
                {
                    MessageBox.Show("Number of coils must be less than 123.");
                }
                spCoils.Children.Clear();

                for (int i = 1; i <= numberOfCoils; i++)
                {
                    StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

                    TextBlock textBlock = new TextBlock
                    {
                        Text = $"Slava {i}",
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(5)
                    };

                    ComboBox comboBox = new ComboBox
                    {
                        Width = 200,
                        Margin = new Thickness(5)
                    };

                    comboBox.Items.Add("true");
                    comboBox.Items.Add("false");

                    stackPanel.Children.Add(textBlock);
                    stackPanel.Children.Add(comboBox);

                    spCoils.Children.Add(stackPanel);
                }
            }
            else
            {
                spCoils.Children.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (byte.TryParse(tbUnitId.Text, out byte unitId))
            {
                UnitId = unitId;
            }
            else
            {
                MessageBox.Show("Enter valid value for UnitID.");
                return;
            }

            int numberOfCoils = spCoils.Children.Count;
            Values = new bool[numberOfCoils];

            if (numberOfCoils <= 0) {
                MessageBox.Show("Enter valid value for Number of Coils");
                return;
            }

            for (int i = 0; i < numberOfCoils; i++)
            {
                if (spCoils.Children[i] is StackPanel stackPanel)
                {
                    ComboBox comboBox = stackPanel.Children.OfType<ComboBox>().FirstOrDefault();
                    if (comboBox != null)
                    {
                        string selectedValue = comboBox.SelectedItem as string;
                        if (bool.TryParse(selectedValue, out bool boolValue))
                        {
                            Values[i] = boolValue;
                        }
                        else
                        {
                            MessageBox.Show($"Invalid value for slave {i + 1}.");
                            return;
                        }
                    }
                }
            }

            if (ushort.TryParse(tbStartAddress.Text, out ushort address))
            {
                StartAddress = address;
            }
            else
            {
                MessageBox.Show("Enter valid value for Address.");
                return;
            }

            this.DialogResult = true;
        }

      
    }
}
