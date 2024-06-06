using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Connection
{
    internal class Connection : IConnection
    {
        private readonly IPEndPoint _endpoint;
        private readonly TcpListener _listener;

        public Connection() { 
            _endpoint= new IPEndPoint(IPAddress.Any, 13);
            _listener=new TcpListener(_endpoint);
        }
        public async Task<TcpListener> Connect()
        {
            try
            {
                _listener.Start();
                return _listener;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void Disconnect()
        {
            _listener.Stop();
        }
    }
}
