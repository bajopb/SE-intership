using Backend.Commands.CommandResult;
using Backend.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands
{
    public class ConnectCommand : ICommandBase
    {
        private readonly IConnection _connection;
        private string address;
        private int port;
        public ConnectCommand(string address, int port) {
            this.port = port;
            this.address = address;
        }
        public bool CanExecute()
        {
            return true;
        }

        public ICommandResult Execute()
        {
            _connection.Connect(address, port);
            return new ConnectCommandResult(_connection.Client.Connected?"":"", _connection.Client.Connected);
        }
    }
}
