using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client
{
    public class GetAllFooQueryHandler
        : QueryHandler<GetAllFooQuery, GetAllFooQueryResult>
    {
        private readonly IRepository<Foo> _repository;

        public GetAllFooQueryHandler(IRepository<Foo> repository)
        {
            _repository = repository;
        }
        protected override GetAllFooQueryResult ExecuteQuery(GetAllFooQuery query)
        {
            return new GetAllFooQueryResult {
                Records = _repository.Find(f => true)
            };
        }
    }
}
