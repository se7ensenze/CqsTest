using System;

namespace CqsExample.Core.Cqs
{
    public interface ICommandResult
    {
        Exception Exception { get; set; }
        bool IsCompleted { get; set; }
        Guid RequestId { get; set; }
    }
}