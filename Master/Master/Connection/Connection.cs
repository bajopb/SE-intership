using Master.Factory;
using NModbus;
using NModbus.Device;
using NModbus.IO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Connection
{
    public class Connection : IConnection
    {
        private readonly TcpClient _client;
        private readonly IPEndPoint _endpoint;
        IMasterFactory _factory;
        IModbusMaster _master;

        public Connection() {
            _endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13);
            _client = new TcpClient();
            _factory = new MasterFactory();
        }

        public async Task<IModbusMaster> Connect()
        {   
            await _client.ConnectAsync(_endpoint);
            if (_client != null && _client.Connected)
            {
                _master = _factory.CreateTcpMaster(_client);
            }
            return _master;
        }

        public void Disconnect()
        {
            _master.Dispose();
        }
    }
}
