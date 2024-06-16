using Slave.Interfaces;
using Slave.Services;
using Slave.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Slave
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IConnectionService _connectionService;
        private ISlaveFactory _factory;
        public App()
        {
            _connectionService = new ConnectionService();
            _factory=new SlaveFactoryService();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_connectionService, _factory)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
