using Backend.Commands.CommandResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Commands
{
    public interface ICommandBase
    {
        bool CanExecute();
        ICommandResult Execute();
    }
}
