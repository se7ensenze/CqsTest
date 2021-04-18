using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace CqsExample.Client.Extensions
{
    public class OpenGenericExtension : UnityContainerExtension, IOpenGenericExtension
    {
        public IOpenGenericExtension RegisterClosedImpl(Type interefaceType, Type baseClassType)
        {
            //System.Diagnostics.Debug.Print($"Target BaseType := {baseClassType.FullName}");
            //System.Diagnostics.Debug.Print($"Target BaseType GenericTypeDefination := {baseClassType.GetGenericTypeDefinition()}");

            typeof(OpenGenericExtension).Assembly
                .DefinedTypes
                .Where(t => t.BaseType != null && 
                    t.BaseType.IsGenericType && 
                    t.BaseType.GetGenericTypeDefinition() == baseClassType &&
                    t.BaseType.GetInterfaces().Any(inf => inf.GetGenericTypeDefinition() == interefaceType))
                .ToList()
                .ForEach(t => {
                    //System.Diagnostics.Debug.Print($"Type := {t.Name}");
                    //System.Diagnostics.Debug.Print($"BaseType := {t.BaseType.FullName}");
                    //System.Diagnostics.Debug.Print($"BaseType is Closed Type = {t.BaseType.ContainsGenericParameters}");
                    //System.Diagnostics.Debug.Print($"BaseType GenericTypeDefination := {t.BaseType.GetGenericTypeDefinition()}");
                    //var inf = t.BaseType.GetInterfaces().First();

                    //System.Diagnostics.Debug.Print($"BaseInterface := {inf.FullName}");
                    //System.Diagnostics.Debug.Print($"BaseInterface is Closed Type = {inf.ContainsGenericParameters}");
                    //System.Diagnostics.Debug.Print($"BaseInterface GenericTypeDefination := {inf.GetGenericTypeDefinition()}");

                    Container.RegisterType(t.BaseType.GetInterfaces()
                            .Where(inf => inf.GetGenericTypeDefinition() == interefaceType)
                            .First(), t);
                });

            //var typeList = typeof(OpenGenericExtension).Assembly
            //    .DefinedTypes
            //    .Where(t => t.BaseType != null && t.BaseType.FullName == baseClassType.FullName)
            //    .ToList();

            //typeList.ForEach(t => {
            //        var baseInterface = t.BaseType.GetInterfaces()
            //            .Where(b => b == interefaceType)
            //            .First();

            //        System.Diagnostics.Debug.Print($"Type := {t.Name}");
            //        System.Diagnostics.Debug.Print($"Interface Type := {baseInterface.Name}");
            //        Container.RegisterType(baseInterface, t);
                    
            //    });
            //closedType.GetInterfaces()
            //    .Where(x => x.IsGenericType)
            //    .Where(x => x.GetGenericTypeDefinition() == openInterface)
            //    .ToList()
            //    .ForEach(x => Container.RegisterType(x, closedType));

            return this;
        }

        protected override void Initialize()
        {
            
        }
    }

    public interface IOpenGenericExtension : IUnityContainerExtensionConfigurator
    {
        IOpenGenericExtension RegisterClosedImpl(Type interefaceType, Type baseClassType);
    }
}
