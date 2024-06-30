using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.CommandResult
{
    public class ReadCommandResult : ICommandResult
    {
        public bool IsSuccess {get;set;}
        public string Message { get; set; }
        public ushort Value { get; set; }
        public ReadCommandResult(bool isSuccesc, string message, ushort value) {
            IsSuccess = isSuccesc;
            Message = message;
            Value = value;
        }
        public ReadCommandResult(bool isSuccesc, string message) {
            IsSuccess = isSuccesc;
            Message = message;
        }
    }
}
