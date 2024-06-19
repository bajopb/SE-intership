using Backend.Commands;
using Backend.Commands.CommandResult;
using Backend.Interfaces;
using Backend.MasterServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CommandExecutor
{
    internal interface ICommandExecutor
    {
        IMasterService MasterService { get; }
        Dictionary<int, IDevice> DeviceCollection { get; }
        ICommandResult Execute(ICommandBase command);
    }
}
