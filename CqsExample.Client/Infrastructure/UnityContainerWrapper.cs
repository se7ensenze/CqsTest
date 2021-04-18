using CqsExample.Client.Extensions;
using CqsExample.Core.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace CqsExample.Client.Infrastructure
{
    public class UnityContainerWrapper : IContainer
    {
        readonly UnityContainer _container;

        public UnityContainerWrapper()
        {
            _container = new UnityContainer();
            _container.AddExtension(new Diagnostic());
            _container.AddNewExtension<OpenGenericExtension>()
                .Configure<IOpenGenericExtension>()
                .RegisterTypes(typeof(ICommandHandler<>), typeof(CommandHandler<>))
                .RegisterTypes(typeof(IQueryHandler<,>), typeof(QueryHandler<,>))
                .RegisterTypes(typeof(IRepository<>), TypeLifetime.Singleton); 

            _container.RegisterInstance<IContainer>(this, InstanceLifetime.Singleton);
            //_container.RegisterType<IRepository<Foo>, FooRepository>(TypeLifetime.Singleton);
            _container.RegisterType<ICommandDispatcher, CommandDispatcher>();
            _container.RegisterType<IQueryDispatcher, QueryDispatcher>();

            //add one by one
            //_container.RegisterType<ICommandHandler<AddFooCommandParameter>, AddFooCommandHandler>();
            //_container.RegisterType<IQueryHandler<GetAllFooQuery, GetAllFooQueryResult>, GetAllFooQueryHandler>();

            //add all impletemented
    
        }

        public T Resolve<T>()
        {
            System.Diagnostics.Debug.Print("Resolve : " + typeof(T).Name);
            return _container.Resolve<T>();
        }
    }
}
