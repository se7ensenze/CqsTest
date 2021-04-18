using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Core.Cqs
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IContainer _container;

        public QueryDispatcher(IContainer container)
        {
            _container = container;
        }
        public TResult Query<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult : IQueryResult
        {
            var handler = _container.Resolve<IQueryHandler<TQuery, TResult>>();

            return handler.Handle(query);
        }
    }
}
