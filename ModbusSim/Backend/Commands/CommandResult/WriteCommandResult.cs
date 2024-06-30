using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.CommandResult
{
    public class WriteCommandResult : ICommandResult
    {
        public bool IsSuccess { get; set; }
        public string Message {get;set;}
        public WriteCommandResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }   
    }
}
