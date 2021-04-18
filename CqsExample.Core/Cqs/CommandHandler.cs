using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public abstract class CommandHandler<TIn>
        : ICommandHandler<TIn> where TIn : ICommand
    {
        public void Handle(TIn command)
        {
            ExecuteCommand(command);
        }

        protected abstract void ExecuteCommand(TIn command);
    }
}
