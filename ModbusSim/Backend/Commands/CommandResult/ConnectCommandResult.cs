﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.CommandResult
{
    public class ConnectCommandResult : ICommandResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ConnectCommandResult(string message, bool success) {
            Message = message;
            IsSuccess = success;
        }
    }
}
