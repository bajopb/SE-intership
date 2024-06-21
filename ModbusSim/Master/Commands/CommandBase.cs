using Master.Commands.CommandParameters;
using Master.Commands.CommandResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Master.Commands
{
    public abstract class CommandBase : ICommandBase
    {
        public event EventHandler CanExecuteChanged;
        public virtual bool CanExecute()
        {
            return true;
        }
        public abstract ICommandResult Execute(ICommandParameters parameters);
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
