using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public class CommandResult : ICommandResult
    {
        public Guid RequestId { get; set; }
        public bool IsCompleted { get; set; }
        public Exception Exception { get; set; }
    }
}
