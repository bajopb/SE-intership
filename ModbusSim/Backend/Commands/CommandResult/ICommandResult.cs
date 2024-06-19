using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands.CommandResult
{
    public interface ICommandResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
