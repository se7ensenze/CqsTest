using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public class CommandDispatcher
        : ICommandDispatcher
    {
        private readonly IContainer _container;

        public CommandDispatcher(IContainer container)
        {
            _container = container;
        }
        public ICommandResult Execute<TIn>(TIn command) where TIn: ICommand
        {
            try
            {
                var handler = _container.Resolve<ICommandHandler<TIn>>();
                handler.Handle(command);

                return new CommandResult { IsCompleted = true };
            }
            catch (Exception ex)
            {
                return new CommandResult { 
                    IsCompleted = false,
                    Exception = ex
                };
            }
        }

    }
}
