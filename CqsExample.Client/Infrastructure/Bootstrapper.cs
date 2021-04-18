using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Injection;

namespace CqsExample.Client.Infrastructure
{
    public static class Bootstrapper
    {
        public static IContainer Bootstrap()
        {
            var container = new UnityContainerWrapper();
            return container;
        }
    }
}
