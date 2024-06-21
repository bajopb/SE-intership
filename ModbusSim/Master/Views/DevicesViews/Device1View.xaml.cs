﻿using Master.ViewModels;
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
        public Device1View()
        {
            InitializeComponent();
        }
        public Device1View(Device1ViewModel dataContext):this()
        {
            this.DataContext = dataContext;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StepView cw = new StepView(dgSteps.SelectedItem as StepViewModel);
            cw.Owner = this;
            cw.ShowDialog();
        }
    }
}
