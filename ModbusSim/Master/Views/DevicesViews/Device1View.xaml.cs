using Master.Views.Events;
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

namespace Master.Views.DevicesViews
{
    /// <summary>
    /// Interaction logic for Device1View.xaml
    /// </summary>
    public partial class Device1View : Window
    {
        public event EventHandler<TemperatureSetEventArgs> TemperatureSet;
        public event EventHandler<TimeSetEventArgs> TimeSet;
        public event EventHandler<MethodSetEventArgs> MethodSet;

        public Device1View()//ushort currentGrindingTemperature, ushort currentGrindingTime, ushort currentGrindingMethod,
        //    ushort currentSaharificationTemperature, ushort currentSaharificationTime, ushort currentSaharificationMethod,
        //    ushort currentMashoutTemperature, ushort currentMashoutTime,
        //    ushort currentFilteringTemperature, ushort currentFilteringTime)
        {
            InitializeComponent();
            //tbCurrentGrindingMethod.Text= currentGrindingMethod.ToString();
            //tbCurrentGrindingTime.Text= currentGrindingTime.ToString();
            //tbCurrentGrindingTemperature.Text= currentGrindingTemperature.ToString();

            //tbCurrentSaharificationMethod.Text = currentSaharificationMethod.ToString();
            //tbCurrentSaharificationTime.Text = currentSaharificationTime.ToString();
            //tbCurrentSaharificationTemperature.Text = currentSaharificationTemperature.ToString();

            //tbCurrentMashoutTime.Text = currentMashoutTime.ToString();
            //tbCurrentMashoutTemperature.Text = currentMashoutTemperature.ToString();

            //tbCurrentFilteringTime.Text = currentFilteringTime.ToString();
            //tbCurrentFilteringTemperature.Text = currentFilteringTemperature.ToString();
        }

        //private void btnSetGrindingTemperature_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetGrindingTemperature.Text, out ushort temperature))
        //    {
        //        if (temperature>0 && temperature<120) {
        //            TemperatureSet?.Invoke(this, new TemperatureSetEventArgs(temperature, 1));
        //            tbSetGrindingTemperature.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Temperature must be within 0-120.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid temperature.");
        //    }
        //}

        //private void btnSetSaharificationTemperature_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetSaharificationTemperature.Text, out ushort temperature))
        //    {
        //        if (temperature > 0 && temperature < 120)
        //        {
        //            TemperatureSet?.Invoke(this, new TemperatureSetEventArgs(temperature, 2));
        //            tbSetSaharificationTemperature.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Temperature must be within 0-120.");
        //        }
        //        }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid temperature.");
        //    }
        //}

        //private void btnSetMashoutTemperature_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetMashoutTemperature.Text, out ushort temperature))
        //    {
        //        if (temperature > 0 && temperature < 120)
        //        {
        //            TemperatureSet?.Invoke(this, new TemperatureSetEventArgs(temperature, 3));
        //            tbSetMashoutTemperature.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Temperature must be within 0-120.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid temperature.");
        //    }
        //}

        //private void btnSetFilteringTemperature_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetFilteringTemperature.Text, out ushort temperature))
        //    {
        //    if (temperature > 0 && temperature < 120)
        //    {
        //        TemperatureSet?.Invoke(this, new TemperatureSetEventArgs(temperature, 4));
        //        tbSetFilteringTemperature.Text = string.Empty; 
        //    }
        //    else
        //    {
        //        MessageBox.Show("Temperature must be within 0-120.");
        //    }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid temperature.");
        //    }
        //}

        //private void btnSetGrindingTime_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetGrindingTime.Text, out ushort time))
        //    {
        //        if (time > 0 && time < 180)
        //        {
        //            TimeSet?.Invoke(this, new TimeSetEventArgs(time, 1));
        //            tbSetGrindingTime.Text = string.Empty;
        //        }
        //        else {
        //            MessageBox.Show("Time must be within 0-180.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid time.");
        //    }
        //}

        //private void btnSetSaharificationTime_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetSaharificationTime.Text, out ushort time))
        //    {
        //        if (time > 0 && time < 180)
        //        {
        //            TimeSet?.Invoke(this, new TimeSetEventArgs(time, 2));
        //            tbSetSaharificationTime.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Time must be within 0-180.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid time.");
        //    }
        //}

        //private void btnSetMashoutTime_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetMashoutTime.Text, out ushort time))
        //    {
        //        if (time > 0 && time < 180)
        //        {
        //            TimeSet?.Invoke(this, new TimeSetEventArgs(time, 3));
        //            tbSetMashoutTime.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Time must be within 0-180.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid time.");
        //    }
        //}

        //private void btnSetFilteringTime_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetFilteringTime.Text, out ushort time))
        //    {
        //        if (time > 0 && time < 180)
        //        {
        //            TimeSet?.Invoke(this, new TimeSetEventArgs(time, 4));
        //            tbSetFilteringTime.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Time must be within 0-180.");
        //        }
        //}
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid time.");
        //    }
        //}

        //private void btnSetGrindingMethod_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetGrindingMethod.Text, out ushort method))
        //    {
        //        if (method > 0 && method < 16)
        //        {
        //            MethodSet?.Invoke(this, new MethodSetEventArgs(method, 1));
        //            tbSetGrindingMethod.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Method value must be within 0-16.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid method.");
        //    }
        //}

        //private void btnSetSaharificationMethod_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ushort.TryParse(tbSetSaharificationMethod.Text, out ushort method))
        //    {
        //        if (method > 0 && method < 16)
        //        {
        //            MethodSet?.Invoke(this, new MethodSetEventArgs(method, 2));
        //            tbSetSaharificationMethod.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Method value must be within 0-16.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please enter a valid method.");
        //    }
        //}
    }
}
