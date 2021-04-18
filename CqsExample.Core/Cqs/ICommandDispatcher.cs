using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public interface ICommandDispatcher
    {
        ICommandResult Execute<TIn>(TIn command) where TIn: ICommand;
    }
}
