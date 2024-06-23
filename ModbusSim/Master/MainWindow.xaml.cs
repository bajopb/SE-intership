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
using NModbus;
using NModbus.Device;
using NModbus.Message;
using System.Diagnostics.Metrics;
using Master.Models;
using System.Runtime.CompilerServices;
using Master.ViewModels;
using Backend.Models.Enums;
using System.Reflection.Metadata;

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

        private void OnExpanderExpanded(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;
            if (expander != null)
            {
                var setPointPair = (KeyValuePair<ProcessType, SetPoint>)expander.DataContext;
                var viewModel = DataContext as MainViewModel;
                if (viewModel != null && viewModel.LoadIRValueCommand.CanExecute(setPointPair.Value))
                {
                    viewModel.LoadIRValueCommand.Execute(setPointPair.Value);
                }
            }
        }
    }
    
}
