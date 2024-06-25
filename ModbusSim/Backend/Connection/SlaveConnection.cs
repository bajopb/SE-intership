using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Connection
{
    public class SlaveConnection : IConnection
    {
        public TcpListener Listener { get; set; }

        public async Task Connect(string address, int port)
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            Listener = new(ipEndPoint);
            Listener.Start();
            Listener.AcceptTcpClientAsync();
        }

        public void Disconnect()
        {
            if(Listener!=null)
                Listener.Stop();
        }

        public bool IsConnected()
        {
            return Listener != null;
        }
    }
}
