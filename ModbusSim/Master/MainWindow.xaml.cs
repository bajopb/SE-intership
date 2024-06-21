using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Master.Interfaces;
using Master.Services;
using NModbus;
using NModbus.Device;
using NModbus.Message;
using System.Diagnostics.Metrics;
using Master.Views;
using Master.Models;
using Master.Views.DevicesViews;
using System.Runtime.CompilerServices;
using Master.Views.Events;
using Master.ViewModels;

namespace Master
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Device1View cw = new Device1View(dgDevices.SelectedItem as Device1ViewModel);
            cw.Owner = this;
            cw.ShowDialog();
        }
    }
}
