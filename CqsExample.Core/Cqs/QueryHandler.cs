using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public abstract class QueryHandler<TIn, TOut>
        : IQueryHandler<TIn, TOut>
        where TIn : IQuery
        where TOut : IQueryResult
    {
        public TOut Handle(TIn query)
        {
            return ExecuteQuery(query);
        }

        protected abstract TOut ExecuteQuery(TIn query);
    }
}
