using Master.Interfaces;
using Master.Models;
using Master.Services;
using Master.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Master
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IConnectionService _connectionService;
        private IMasteraFactoryService _factoryService;
        Device _device1;
        public App() {
            _connectionService = new ConnectionService();
            _factoryService=new MasterFactoryService();
            _device1 = new Device(_factoryService, 1, "127.0.0.1", 13);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_connectionService, _factoryService, _device1)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
