using Master.Commands.CommandParameters;
using Master.Commands.CommandResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Master.Commands
{
    public interface ICommandBase
    {
        event EventHandler CanExecuteChanged;
        bool CanExecute();
        ICommandResult Execute(ICommandParameters parameters);
    }
}
