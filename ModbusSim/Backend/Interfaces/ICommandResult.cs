using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    internal interface ICommandResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
