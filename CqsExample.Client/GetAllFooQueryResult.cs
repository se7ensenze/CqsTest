using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client
{
    public class GetAllFooQueryResult: QueryResult
    {
        public GetAllFooQueryResult() { 
        
        }

        public IEnumerable<Foo> Records { get; set; }
    }
}
