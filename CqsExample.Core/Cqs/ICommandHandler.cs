using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public interface ICommandHandler<TIn> where TIn : ICommand
    {
        void Handle(TIn command);
    }
}
