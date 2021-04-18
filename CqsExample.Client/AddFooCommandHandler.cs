using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client
{
    public class AddFooCommandHandler
        : CommandHandler<AddFooCommandParameter>
    {
        private readonly IRepository<Foo> _repository;

        public AddFooCommandHandler(IRepository<Foo> repository)
            :base()
        {
            _repository = repository;
        }

        protected override void ExecuteCommand(AddFooCommandParameter command)
        {
            _repository.Add(command.NewFoo);
        }

    }
}
