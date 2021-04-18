using CqsExample.Client.Infrastructure;
using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup DI
            var container = Bootstrapper.Bootstrap();

            //create command dispatcher
            ICommandDispatcher commandDispatcher = container.Resolve<ICommandDispatcher>();

            //execute query
            commandDispatcher.Execute(new AddFooCommandParameter()
            {
                NewFoo = new Foo { Id = 1, Name = "XRP" }
            }); 
            
            commandDispatcher.Execute(new AddFooCommandParameter()
            {
                NewFoo = new Foo { Id = 2, Name = "ETH" }
            });


            Console.WriteLine("Add foo result is completed");

            //create query dispatcher
            IQueryDispatcher queryDispatcher = container.Resolve<IQueryDispatcher>();

            var result = queryDispatcher.Query<GetAllFooQuery, GetAllFooQueryResult>(new GetAllFooQuery());

            result.Records.ToList()
                .ForEach(f => Console.WriteLine($"Foo := {f.Name}"));

            Console.Read();

        }
    }
}
