using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Interfaces
{
    interface IConnectionService
    {
        TcpClient Client { get; }
        Task Connect();
        void Disconect();
    }
}
