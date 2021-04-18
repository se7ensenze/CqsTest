using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqsExample.Client
{
    public class AddFooCommandParameter
        : Command
    { 
        public AddFooCommandParameter() { }
        public Foo NewFoo { get; set; }
    }
}
